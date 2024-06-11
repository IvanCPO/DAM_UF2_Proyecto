using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleSystem : MonoBehaviour
{
    
    
    [SerializeField] PictureBattle player;
    [SerializeField] BattleHud playerLive;
    [SerializeField] PictureBattle enemy;
    [SerializeField] BattleHud enemyLive;
    [SerializeField] OptionsController options;
    [SerializeField] DialogCombat messageCombat;
    [SerializeField] NewMoveController newMove;
    [SerializeField] LostPokemonController lostPokemon;
    [SerializeField] PictureVieiraController barVieira;

    StatusPlayer playerStatus;
    StatusRival rivalStatus;
    private Pokemon rival;
    private Pokemon pokemon;
    private bool timeText;
    private bool firstTurn;
    private bool timeAttack;
    private bool changePokemon;
    private bool capturePokemon;
    private bool invokeOptions;
    private HitsController hitsController;

    void Start()
    {
        hitsController = HitsController.GetInstance();
        invokeOptions = true;
        timeText = true;
        timeAttack = false;
        changePokemon = false;
        capturePokemon = false;
        firstTurn = true;
        playerStatus = StatusPlayer.getInstance();
        rivalStatus = StatusRival.GetRival();
        SetupBattleInit();
    }

    private void CheckSelectNewMove(){
        if (newMove.IsDecided())
        {
            if (newMove.IsChange())
            {
                Debug.Log("It's log correct");
                UpdateData();
            }else{
                Debug.Log("It's log correct. You don't change nothing");
            }
            Debug.Log("Ayudame dios");
            newMove.Clear();
            messageCombat.OcultarMostrarDialog();
            ChangeTurn();
        }
    }

    private void CheckLostPokemon()
    {
        if (lostPokemon.Decision)
        {
            if (lostPokemon.Change)
            {
                options.OpenTeam();
            }
            else
            {
                Exit();
            }
            lostPokemon.Decision = false;
        }
        if (lostPokemon.Change)
        {
            if (options.IsTake())
            {
                lostPokemon.ClearDecision();
                changePokemon = true;
                timeText = false;
            }
        }
    }

    private void Update()
    {
        CheckLostPokemon();
        CheckSelectNewMove();

        if (!timeText)
        {
            int allTeamHP = playerStatus.GetTotalHPTeam();
            int allRivalHP = rivalStatus.TotalRivalHP();
            if (allRivalHP == 0 || allTeamHP == 0)
            {
                FinishGame();
                timeText = true;
                timeAttack = false;
            }
            else
            {
                if (changePokemon && !options.Exit)
                {
                    Debug.Log("Change Pokemon SUUUUUUU");
                    ChangePokemon();
                    firstTurn = false;
                    timeText = true;
                    changePokemon = false;
                    Invoke("ChangeTurn", 2f);

                }
                else
                {
                    if (invokeOptions)
                    {
                        Debug.Log("Invoke Options SUUUUUUU");
                        options.ChangeDialog();
                        invokeOptions = false;
                    }
                    if (options.IsTake())
                    {
                        TakeDecision();
                    }
                }
            }
        }
        else
        {
            GetDecision();
        }

    }

    private void TakeDecision()
    {
        if (options.IsAttack())
        {
            Debug.Log("GOLPEA");
            timeAttack = true;
        }else
        {
            if (options.Exit)
            {
                Debug.Log("Escapa??");
                Exit();
            }
            else{
                if (options.Capture)
                {
                    capturePokemon = true;
                }
                else{
                    changePokemon = true;
                }
            }
        }
        timeText = true;
    }

    private void GetDecision()
    {
        if (timeAttack)
        {
            invokeOptions = true;
            timeAttack = false;
            options.OcultAllDialog();
            DecideTurnHit(firstTurn);
        }
        if (changePokemon)
        {
            invokeOptions = true;
            changePokemon = false;
            options.OcultAllDialog();
            ChangePokemonHit();
        }
        if (capturePokemon)
        {
            invokeOptions = true;
            capturePokemon = false;
            options.OcultAllDialog();
            CapturePokemonHit();
        }
    }

    private void DecideTurnHit(bool turn){
        if (turn){
            if (hitsController.Player.Speed>=hitsController.Rival.Speed)
            {
                MakePlayerAttack();
            }
            else
            {
                MakeEnemyAttack();
            }
        }
        else
        {
            if (hitsController.Player.HP!=0 && hitsController.Rival.HP!=0)
            {
                if (hitsController.Player.Speed<hitsController.Rival.Speed)
                {
                    MakePlayerAttack();
                }
                else
                {
                    MakeEnemyAttack();
                }
            }else
                ChangeTurn();
        }
    }

    private void ChangeTurn(){
        if(firstTurn){
            firstTurn=false;
            timeAttack = true;
        }else{
            Debug.Log ("Change Turn pokemon last hit");
            if (hitsController.Player.HP==0 && pokemon != null)
            {
                NextPokemonPlayer();
            }else
            if (hitsController.Rival.HP==0 && rival != null)
            {
                NextPokemonRival();
            }else{
                timeText = false;
                firstTurn = true;
                timeAttack = false;
            }
        }
        messageCombat.OcultarMostrarDialog();
        UpdateData();
    }

    private void MakePlayerAttack()
    {
        Debug.Log("Decision player");
        messageCombat.GenerateTextPlayer("Tu " + hitsController.Player.Base.Name + " ha utilizado " + hitsController.MovePlayer.Base.Name + " contra el rival!!!");
        player.ThrowAnimationAttack();
        Invoke("HitPlayer", 3.00f);
    }

    private void MakeEnemyAttack()
    {
        hitsController.GenerateMoveRandom();
        Debug.Log("Decision enemy");
        messageCombat.GenerateTextEnemy(hitsController.Rival.Base.Name + " ha utilizado " + hitsController.GetMoveRival().Base.Name + " contra ti!!!");
        enemy.ThrowAnimationAttack();
        Invoke("HitRival", 3.00f);
    }

    private void ChangePokemonHit()
    {
        ChangePokemon();
        Invoke("UpdateData", 2f);

        Invoke("MakeEnemyAttack", 2f);
        firstTurn = false;
    }

    private void ChangePokemon()
    {
        Debug.Log("Decision player (change pokemon)");
        string valueMessage = "VUELVE JEFE! AHORA PELEA!! [Has cambiado de " + hitsController.Player.Base.Name;
        hitsController.Player = options.GetPokemonChange();
        valueMessage += " por tu " + hitsController.Player.Base.Name + "]";
        messageCombat.GenerateTextPlayer(valueMessage);
    }
    









    
    private void CapturePokemonHit()
    {
        TryCapturePokemon();
        Invoke("UpdateData", 2f);

        Invoke("MakeEnemyAttack", 2f);
        firstTurn = false;
    }
    










    public void TryCapturePokemon(){
        Debug.Log("Decision player (capture pokemon)");
        string valueMessage = "Lanza PokeVieira!!";
        messageCombat.GenerateTextPlayer(valueMessage);
    }

    private void HitPlayer(){
        pokemon = hitsController.HitPlayer();
        ChangeTurn();
    }

    private void HitRival(){
        hitsController.HitRival();
        ChangeTurn();
    }

    private int exp = 0;
    private void NextPokemonRival()
    {
        exp = ObtenerExperience();
        messageCombat.GenerateTextInfo("Debilitaste a tu rival, "+hitsController.Player.Base.Name);
        rival = null;
        Invoke("DeathNote",3f);
        messageCombat.OcultarMostrarDialog();
        foreach (Pokemon p in rivalStatus.Team)
        {
            // Debug.Log("The pokemon enemy "+rival.Base.Name+" is like "+p.Base.Name+" of her team? "+(rival==p));
            if (p.HP>0)
            {
                rival = p;
                break;
            }
        }
    }

    MoveBase move;
    private void DeathNote()
    {
        
        if(pokemon.LevelUp(exp)){
            // messageCombat.OcultarMostrarDialog();
            // Debug.Log("The rival is death. you obtein "+exp+" of experience");
            messageCombat.GenerateTextInfo("Tu Pokemon ha subido de nivel");
            move = pokemon.isLearning();
            if (move!=null)
            {
                Invoke("LearnMoves",3f);
            }else
            { Invoke("ChangeTurn",3f); }
        }
        else{
            ChangeTurn();
        }
        if (rival != null)
        {
            hitsController.Rival = rival;
        }
    }

    private void LearnMoves(){
        if (pokemon.LearnAlone(move))
        {
            // Debug.Log("The rival is death. you obtein "+exp+" of experience");
            messageCombat.GenerateTextInfo("Tu "+pokemon.Base.Name+" ha aprendido "+move.Name);
        }else{
            messageCombat.GenerateTextInfo("Tu pokemon, intenta aprender "+move.Name);
            Invoke("LearnMove",3f);
        }
    }

    private void LearnMove(){
        newMove.LearnMove(pokemon, move);
        messageCombat.OcultarMostrarDialog();
    }

    private void NextPokemonPlayer()
    {
        messageCombat.GenerateTextInfo("Tu pokemon ha sido debilitado.");
        messageCombat.OcultarMostrarDialog();
        Invoke("LostPokemon",3f);
    }

    private void LostPokemon(){
        pokemon = null;
        if (playerStatus.GetTotalHPTeam()>0)
        {
            lostPokemon.SetData(hitsController.Player, rivalStatus.IsWild);
        }else{
            ChangeTurn();
        }
    }

    private int ObtenerExperience()
    {
        return Convert.ToInt32(hitsController.Rival.Base.ExpBase*hitsController.Rival.Level/5*Math.Pow((2*hitsController.Rival.Level+10d)/(hitsController.Rival.Level+hitsController.Player.Level+10),2.5)+1);
    }


    private void UpdateData(){
        
        player.Setup(hitsController.Player);
        enemy.Setup(hitsController.Rival);
        playerLive.SetData(hitsController.Player);
        enemyLive.SetData(hitsController.Rival);
        options.SetMoves(hitsController.Player);
        barVieira.SetData(rivalStatus.Team);

    }

    private void SetupBattleInit()
    {
        if (playerStatus.GetTeam().Count==0)
        {
            pokemon = new Pokemon(PokemonBase.GetPokemonBase(4),14);
            pokemon.LevelUp(pokemon.MaxExp-4);
            // pokemon.HP = 1;
            playerStatus.GetTeam().Add(pokemon);
            pokemon = new Pokemon(PokemonBase.GetPokemonBase(1),6);
            pokemon.HP = 1;
            playerStatus.GetTeam().Add(pokemon);
            rival = new Pokemon(PokemonBase.GetPokemonBase(7),3);
            rivalStatus.SetDataWild(rival);
            rival = new Pokemon(PokemonBase.GetPokemonBase(14),3);
            rivalStatus.SetDataWild(rival);
        }

        // JUEGO PREPARADO
        pokemon = playerStatus.FirstPokemon();
        rival = rivalStatus.Team[0];

        player.Setup(pokemon);
        playerLive.SetData(pokemon);
        enemy.Setup(rival);
        enemyLive.SetData(rival);
        options.SetMoves(pokemon);
        barVieira.ActiveBar(rivalStatus.IsWild);
        barVieira.SetData(rivalStatus.Team);
        
        messageCombat.StartGame();
        hitsController.Rival = rival;
        hitsController.Player = pokemon;
    }

    public void Exit(){
        options.OcultAllDialog();
        lostPokemon.gameObject.SetActive(false);
        if(hitsController.TryEscape()){
            messageCombat.GenerateTextInfo("Has HUIDO");
            Invoke("ReturnWorld",1f);
        }else{
            messageCombat.GenerateTextInfo("Careces del suficiente intelecto como para escapar en este momento");
            Invoke("FalleRun",4f);
            hitsController.IncreaseTry();
            firstTurn = false;
        }
    }

    private void FalleRun(){
        if (lostPokemon.WasPressedEscape)
        {
            lostPokemon.gameObject.SetActive(true);
            lostPokemon.ChangePokemon();
        }else{
            UpdateData();
            invokeOptions = true;
            timeAttack = false;
            MakeEnemyAttack();
        }
    }
    
    private void FinishGame(){
        if (rivalStatus.TotalRivalHP()==0)
        {
            if (!rivalStatus.IsWild)
            {
                messageCombat.GenerateTextInfo(rivalStatus.NameRival+" ha perdido. Ganas "+rivalStatus.Money+"€");
                playerStatus.AddMoney(rivalStatus.Money);
            }else
                messageCombat.GenerateTextInfo("El rival ha sido debilitado");
        }
        else
        {
            if (!rivalStatus.IsWild)
            {
                messageCombat.GenerateTextInfo(rivalStatus.NameRival+" ha ganado. Pierdes "+rivalStatus.Money/2+"€");
                playerStatus.RemoveMoney(rivalStatus.Money);
            }else
                messageCombat.GenerateTextInfo("Todos tus pokemons están debilitados. Vuelves llorando a casa");
        }
            Invoke("ReturnWorld",3f);
    }

    private void ReturnWorld(){
        rivalStatus.Clear();
        SceneManager.LoadScene(playerStatus.getUbicationActual().SceneId);
    }

    public void FinishDialog(){
        timeText = false;
    }
}

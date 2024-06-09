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

    StatusPlayer playerStatus;
    private Pokemon rival;
    private Pokemon pokemon;
    private bool timeText;
    private bool firstTurn;
    private bool timeAttack;
    private bool changePokemon;
    private bool invokeOptions;
    private HitsController hitsController;

    void Start()
    {
        hitsController = HitsController.GetInstance();
        invokeOptions = true;
        timeText = true;
        timeAttack = false;
        changePokemon = false;
        firstTurn = true;
        playerStatus = StatusPlayer.getInstance();
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

    private void Update(){
        CheckSelectNewMove();
        
        if (!timeText)
        {
            int allTeamHP = playerStatus.GetTotalHPTeam();
            int allRivalHP = playerStatus.GetRivalHPTeam();
            if (allRivalHP==0||allTeamHP==0)
            {
                FinishGame();
                timeText=true;
                timeAttack=false;
            }else{
                if (invokeOptions)
                {
                    options.ChangeDialog();
                    invokeOptions = false;
                }
                if (options.IsTake())
                {
                    TakeDecision();
                }
            }
        }else
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
            changePokemon = true;
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
    }

    private void DecideTurnHit(bool turn){
        if (turn){
            if (pokemon.Speed>=rival.Speed)
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
                if (pokemon.Speed<rival.Speed)
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
        Debug.Log("Decision player (change pokemon)");
        string valueMessage = "VUELVE JEFE! AHORA PELEA!! [Has cambiado de "+hitsController.Player.Base.Name;
        hitsController.Player = options.GetPokemonChange();
        valueMessage+= " por tu "+hitsController.Player.Base.Name+"]";
        messageCombat.GenerateTextPlayer(valueMessage);
        Invoke("UpdateData",2f);

        Invoke("MakeEnemyAttack",2f);
        firstTurn=false;
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
        messageCombat.GenerateTextInfo("Debilitaste a tu rival, "+hitsController.Rival.Base.Name);
        rival = null;
        Invoke("DeathNote",3f);
        messageCombat.OcultarMostrarDialog();
        foreach (Pokemon p in playerStatus.Rival)
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
            Debug.Log("hola, "+rival.Base.Name);
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


    private void UpdateData(){
        
        player.Setup(hitsController.Player);
        enemy.Setup(hitsController.Rival);
        playerLive.SetData(hitsController.Player);
        enemyLive.SetData(hitsController.Rival);
        options.SetMoves(hitsController.Player);

    }
    private void FinishGame(){
        if (playerStatus.GetRivalHPTeam()==0)
        {
            messageCombat.GenerateTextInfo("El rival ha sido debilitado");
        }
        else
        {
            messageCombat.GenerateTextInfo("Todos tus pokemons están debilitados. Vuelves llorando a casa");
        }
        Invoke("ReturnWorld",3f);
    }

    private int ObtenerExperience()
    {
        return Convert.ToInt32(hitsController.Rival.Base.ExpBase*hitsController.Rival.Level/5*Math.Pow((2*hitsController.Rival.Level+10d)/(hitsController.Rival.Level+hitsController.Player.Level+10),2.5)+1);
    }



    private void SetupBattleInit()
    {
        if (playerStatus.GetTeam().Count==0)
        {
            pokemon = new Pokemon(PokemonBase.GetPokemonBase(4),14);
            pokemon.LevelUp(pokemon.MaxExp-4);
            playerStatus.GetTeam().Add(pokemon);
            pokemon = new Pokemon(PokemonBase.GetPokemonBase(1),6);
            playerStatus.GetTeam().Add(pokemon);
            rival = new Pokemon(PokemonBase.GetPokemonBase(7),3);
            playerStatus.Rival.Add(rival);
            rival = new Pokemon(PokemonBase.GetPokemonBase(14),3);
            playerStatus.Rival.Add(rival);
        }

        // JUEGO PREPARADO
        pokemon = playerStatus.FirstPokemon();
        rival = playerStatus.Rival[0];

        player.Setup(pokemon);
        playerLive.SetData(pokemon);
        enemy.Setup(rival);
        enemyLive.SetData(rival);
        options.SetMoves(pokemon);
        
        messageCombat.StartGame(playerStatus.Rival);
        hitsController.Rival = rival;
        hitsController.Player = pokemon;
    }


    private void ReturnWorld(){
        playerStatus.ClearRival();
        SceneManager.LoadScene(3);
    }


    public void FinishDialog(){
        timeText = false;
    }
}

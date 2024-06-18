using System;
using System.Collections.Generic;
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
    [SerializeField] BallController ballController;

    StatusPlayer playerStatus;
    StatusRival rivalStatus;
    private Pokemon rival;
    private Pokemon pokemon;
    private bool timeText;
    private bool firstTurn;
    private bool timeAttack;
    private bool timeNewPokemon;
    private bool changePokemon;
    private bool capturePokemon;
    private bool invokeOptions;
    private HitsController hitsController;
    private ListEvolutionsController evolutionsList;

    void Start()
    {
        hitsController = HitsController.GetInstance();
        invokeOptions = true;
        timeText = true;
        timeAttack = false;
        changePokemon = false;
        capturePokemon = false;
        timeNewPokemon = false;
        firstTurn = true;
        playerStatus = StatusPlayer.getInstance();
        rivalStatus = StatusRival.GetRival();
        SetupBattleInit();
        evolutionsList = ListEvolutionsController.GetListInstance();
    }

    private void CheckSelectNewMove(){
        if (newMove.IsDecided())
        {
            if (newMove.IsChange())
            {
                Debug.Log("It's log correct");
                if (!timeNewPokemon)
                {
                    UpdateData();
                }
                
            }else{
                Debug.Log("It's log correct. You don't change nothing");
            }
            newMove.Clear();
            messageCombat.OcultarMostrarDialog();
            if (timeNewPokemon)
            {
                ReturnWorld();
            }else
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
        messageCombat.GenerateTextPlayer("Tu " + hitsController.Player.Base.Name + " utilizou " + hitsController.MovePlayer.Base.Name + " contra o rival!!!");
        player.ThrowAnimationAttack();
        Invoke("HitPlayer", 3.00f);
    }

    private void MakeEnemyAttack()
    {
        hitsController.GenerateMoveRandom();
        Debug.Log("Decision enemy");
        messageCombat.GenerateTextEnemy(hitsController.Rival.Base.Name + " utilizou " + hitsController.GetMoveRival().Base.Name + " contra ti!!!");
        enemy.ThrowAnimationAttack();
        Invoke("HitRival", 3.00f);
    }

    private void HitPlayer(){
        pokemon = hitsController.HitPlayer();
        ChangeTurn();
    }

    private void HitRival(){
        hitsController.HitRival();
        ChangeTurn();
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
        string valueMessage = "VOLVE COMPAÑEIRO! AGORA PELEA!! [Cambiaches de " + hitsController.Player.Base.Name;
        hitsController.Player = options.GetPokemonChange();
        valueMessage += " polo teu " + hitsController.Player.Base.Name + "]";
        messageCombat.GenerateTextPlayer(valueMessage);
    }











    private void CapturePokemonHit()
    {
        Debug.Log ("CaptureMoment");
        float delayInvoke = 3f;
        hitsController.TryCap();
        delayInvoke += hitsController.GetCountMoveBall();
        TryCapturePokemon();
        if (hitsController.GetCountMoveBall()!=4)
        {
            Invoke("UpdateData", delayInvoke+0.2f);
            Invoke("MakeEnemyAttack", delayInvoke+0.2f);
            firstTurn = false;
        }
        else{
            playerStatus.GetTeam().Add(rival);
        }
    }

    private void TryCapturePokemon(){
        ballController.AnimationThrowBall();
        Debug.Log("Decision player (capture pokemon)");
        string valueMessage = "Lanza PokeVieira!!";
        messageCombat.GenerateTextPlayer(valueMessage);
        Invoke("PictureCloseOpen",2.3f);
    }

    private void PictureCloseOpen(){
        ballController.StopAnimationThrow();
        Debug.Log("Quitar Pokemon");
        enemy.ActiveDisact();
        ballController.BallMoveActivation();
        if ( hitsController.GetCountMoveBall()>=1){
            MoveBall();
            string valueMessage = "Intento";
            messageCombat.GenerateTextPlayer(valueMessage);
        }
        for (float i = 2; i <= hitsController.GetCountMoveBall(); i++)
        {
            if(i==4){
                Invoke("CaptureFinish",i);
            }
            else
                Invoke("MoveBall",i);
        }
        Invoke("DisactiveBall",hitsController.GetCountMoveBall());
        if(hitsController.GetCountMoveBall()!=4){
            Invoke("WildPokemonEscape",hitsController.GetCountMoveBall());
        }
    }

    private void MoveBall(){
        Debug.Log("Move ball Vieira");
        ballController.AnimationMoveBall();
    }

    private void CaptureFinish(){
        Debug.Log("Decision player (capture pokemon)");
        ballController.Stop();
        string valueMessage = "Capturaches ao pokemon salvaxe "+hitsController.Rival.Base.Name;
        exp = ObtenerExperience()/2;
        Invoke("DeathNote",3f);
        timeNewPokemon = true;
        messageCombat.GenerateTextPlayer(valueMessage);
    }

    private void DisactiveBall(){
        ballController.BallMoveActivation();
    }

    private void WildPokemonEscape(){
        string valueMessage = "O pokemon salvaxe, "+hitsController.Rival.Base.Name+", escapou";
        messageCombat.GenerateTextPlayer(valueMessage);
    }











    private int exp = 0;
    private void NextPokemonRival()
    {
        exp = ObtenerExperience();
        messageCombat.GenerateTextInfo("Debilitaste ao teu rival, "+hitsController.Rival.Base.Name);
        rival = null;
        Invoke("DeathNote",3f);
        messageCombat.OcultarMostrarDialog();
        rival = rivalStatus.FirstPokemonLive();
    }

    MoveBase move;
    private void DeathNote()
    {

        if(pokemon.LevelUp(exp)){
            // messageCombat.OcultarMostrarDialog();
            // Debug.Log("The rival is death. you obtein "+exp+" of experience");
            messageCombat.GenerateTextInfo("Subiches de nivel");

            move = pokemon.isLearning();
            if (move!=null)
            {
                Invoke("LearnMoves",3f);
            }else
            { Invoke("ChangeTurn",3f); }
        }
        else{
            if (timeNewPokemon)
            {
                ReturnWorld();
                
            }else{
                ChangeTurn();
            }
        }
        if (rival != null)
        {
            playerStatus.MeetPokemon(rival.Base.PokedexID);
            hitsController.Rival = rival;
        }
    }
    private bool learn;
    private void LearnMoves(){
        learn = pokemon.LearnAlone(move);
        if (learn)
            messageCombat.GenerateTextInfo("Teu "+pokemon.Base.Name+" aprendeu "+move.Name);
        else
            messageCombat.GenerateTextInfo("Teu pokemon, intenta aprender "+move.Name);
        Invoke("LearnMove",3f);
    }

    private void LearnMove(){
        if (learn)
        {
            newMove.LearnAlone();
            messageCombat.OcultarMostrarDialog();
        }else{
            newMove.LearnMove(pokemon, move);
            messageCombat.OcultarMostrarDialog();
        }
    }

    private void NextPokemonPlayer()
    {
        messageCombat.GenerateTextInfo("Teu pokemon foi debilitado.");
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
            pokemon = new Pokemon(PokemonBase.GetPokemonBase(4),15);
            pokemon.LevelUp(pokemon.MaxExp-4);
            Debug.Log("Level evolution pokemon "+pokemon.Base.levelPokemon);
            playerStatus.GetTeam().Add(pokemon);
            // pokemon = new Pokemon(PokemonBase.GetPokemonBase(1),6);
            // playerStatus.GetTeam().Add(pokemon);

            // Si quiero testear el entrenador: 
            // rival = new Pokemon(PokemonBase.GetPokemonBase(10),5);
            // rival.HP = 1;
            // var list = new List<Pokemon>();
            // list.Add(rival);
            // list.Add(new Pokemon(PokemonBase.GetPokemonBase(14),3));
            // rivalStatus.SetData(list,3333333,"Jose",400);

            // Si quiero testear un pokemon salvaje: 
            rival = new Pokemon(PokemonBase.GetPokemonBase(10),3);
            rival.HP = 1;
            rivalStatus.SetDataWild(rival);
        }

        // JUEGO PREPARADO
        pokemon = playerStatus.FirstPokemon();
        rival = rivalStatus.FirstPokemonLive();

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
        playerStatus.MeetPokemon(rival.Base.PokedexID);
    }

    public void Exit(){
        options.OcultAllDialog();
        lostPokemon.gameObject.SetActive(false);
        if(hitsController.TryEscape()){
            messageCombat.GenerateTextInfo("ESCAPACHES");
            Invoke("ReturnWorld",1f);
        }else{
            messageCombat.GenerateTextInfo("Careces do suficiente intelecto como para escapar neste momento");
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
        foreach (Pokemon pokemon in playerStatus.GetTeam())
        {
            if (pokemon.Level >= pokemon.Base.levelPokemon)
            {
                evolutionsList.AddPokemon(pokemon);
            }
        }
        if (rivalStatus.TotalRivalHP()==0)
        {
            if (!rivalStatus.IsWild)
            {
                messageCombat.GenerateTextInfo(rivalStatus.NameRival+" perdeu. Gañaches "+rivalStatus.Money+"€");
                playerStatus.AddMoney(rivalStatus.Money);
                playerStatus.AddIdTrainer(rivalStatus.IDTrainer);
            }else
                messageCombat.GenerateTextInfo("O rival foi debilitado");
        }
        else
        {
            if (!rivalStatus.IsWild)
            {
                messageCombat.GenerateTextInfo(rivalStatus.NameRival+" ganou. Perdes "+rivalStatus.Money/2+"€");
                playerStatus.RemoveMoney(rivalStatus.Money);
            }else
                messageCombat.GenerateTextInfo("Todos os teus pokemons foron debilitados. Volves chorando a casa");
        }
        Invoke("ReturnWorld",3f);
    }

    private void ReturnWorld(){
        rivalStatus.Clear();
        if (playerStatus.GetTotalHPTeam()!=0){
            if (evolutionsList.GetPokemons().Count>0)
                SceneManager.LoadScene(7);
            else
                SceneManager.LoadScene(playerStatus.getUbicationActual().SceneId);
        }else{
            SceneManager.LoadScene(playerStatus.getUbicationRest().SceneId);
        }
    }

    public void FinishDialog(){
        timeText = false;
    }
}

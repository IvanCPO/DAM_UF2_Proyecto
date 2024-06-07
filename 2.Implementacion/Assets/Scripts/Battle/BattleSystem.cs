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
        SetupBattle();
    }

    private void Update(){
        if (true)
        {
            
        }
        
        if (!timeText)
        {
            int allTeamHP = TotalHPTeam();
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
        }else{
            if (timeAttack)
            {
                invokeOptions = true;
                timeAttack=false;
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

    private void DecideTurnHit(bool turn){
        if (turn){
            if (pokemon.Speed>=rival.Speed)
            {
                Debug.Log("Golpe jugador");
                messageCombat.GenerateTextPlayer("Tu "+hitsController.Player.Base.Name+" ha utilizado "+ hitsController.MovePlayer.Base.Name +" contra el rival!!!");
                player.ThrowAnimationAttack();
                Invoke("HitPlayer",3.00f);
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
                    Debug.Log("Decision player");
                    messageCombat.GenerateTextPlayer("Tu "+hitsController.Player.Base.Name+" ha utilizado "+ hitsController.MovePlayer.Base.Name +" contra el rival!!!");
                    player.ThrowAnimationAttack();
                    Invoke("HitPlayer",3.00f);
                }
                else
                {
                    MakeEnemyAttack();
                }
            }else
                ChangeTurn();
        }
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

    private void MakeEnemyAttack()
    {
        hitsController.GenerateMoveRandom();
        Debug.Log("Decision enemy");
        messageCombat.GenerateTextEnemy(hitsController.Rival.Base.Name + " ha utilizado " + hitsController.GetMoveRival().Base.Name + " contra ti!!!");
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

    private void ChangeTurn(){
        if(firstTurn){
            firstTurn=false;
            timeAttack = true;
        }else{
            if (hitsController.Rival.HP==0)
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

    private int exp = 0;
    private void NextPokemonRival()
    {
        exp = ObtenerExperience();
        rival = null;
        foreach (Pokemon p in playerStatus.Rival)
        {
            // Debug.Log("The pokemon enemy "+rival.Base.Name+" is like "+p.Base.Name+" of her team? "+(rival==p));
            if (p.HP>0)
            {
                rival = p;
                break;
            }
        }
        DeathNote();
    }

    private void DeathNote()
    {
        if (rival!=null)
        {
            messageCombat.GenerateTextInfo("Has debilitado al enemigo. Enhorabuena!!");
            
        }
        if(pokemon.LevelUp(exp)){
            messageCombat.GenerateTextInfo("Tu Pokemon ha subido de nivel");
            MoveBase move = pokemon.isLearning();
            if (move!=null)
            {
                LearnMoves(move);
            }
        }
    }

    private void LearnMoves(MoveBase move){
        if (pokemon.LearnAlone(move))
        {
            messageCombat.GenerateTextInfo("Tu "+pokemon.Base.Name+" ha aprendido "+move.Name);
        }else{
            newMove.LearnMove(pokemon, move);
        }
    }
    private void UpdateData(){
        
        player.Setup(hitsController.Player);
        enemy.Setup(hitsController.Rival);
        playerLive.SetData(hitsController.Player);
        enemyLive.SetData(hitsController.Rival);
        options.SetMoves(hitsController.Player);

    }
    private void FinishGame(){
        if (rival.HP==0)
        {
            pokemon.LevelUp(ObtenerExperience());
            messageCombat.GenerateTextPlayer("El rival ha sido debilitado");
        }
        else
        {
            messageCombat.GenerateTextPlayer("Todos tus pokemons están debilitados. Vuelves llorando a casa");
        }
        Invoke("ReturnWorld",5f);
    }

    private int ObtenerExperience()
    {
        return Convert.ToInt32(rival.Base.ExpBase*rival.Level/5*Math.Pow((2*rival.Level+10d)/(rival.Level+pokemon.Level+10),2.5)+1);
    }

    private int TotalHPTeam(){
        return playerStatus.GetTotalHPTeam();
    }

    private void SetupBattle()
    {
        if (playerStatus.GetTeam().Count==0)
        {
            pokemon = new Pokemon(PokemonBase.GetPokemonBase(4),6);
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

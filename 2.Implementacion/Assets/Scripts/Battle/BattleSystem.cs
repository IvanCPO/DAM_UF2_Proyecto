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

    StatusPlayer playerStatus;
    private Pokemon rival;
    private Pokemon pokemon;
    private bool timeText;
    private bool firstTurn;
    private bool timeAttack;
    private bool invokeOptions;
    private HitsController hitsController;

    void Start()
    {
        hitsController = HitsController.GetInstance();
        invokeOptions=true;
        timeText=true;
        timeAttack=false;
        firstTurn=true;
        playerStatus = StatusPlayer.getInstance();
        SetupBattle();
    }

    private void Update(){
        if (!timeText)
        {
            int allTeamHP = TotalHPTeam();
            if (rival.HP==0||allTeamHP==0)
            {
                FinishGame();
            }else{
                if (invokeOptions)
                {
                    options.ChangeDialog();
                    invokeOptions = false;
                }
                if (options.IsTake())
                {
                    timeAttack=true;
                    timeText=true;
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
        }

    }

    private void DecideTurnHit(bool turn){
        if (turn){
            if (pokemon.Speed>=rival.Speed)
            {
                Debug.Log("Golpe jugador");
                messageCombat.GenerateTextPlayer("Tu "+hitsController.Player.Base.Name+" ha utilizado "+ hitsController.MovePlayer.Base.Name +" contra el rival!!!");
                Invoke("HitPlayer",5f);
            }
            else
            {
                hitsController.GenerateMoveRandom();
                Debug.Log("Golpe enemigo");
                messageCombat.GenerateTextEnemy(hitsController.Rival.Base.Name+" ha utilizado "+ hitsController.GetMoveRival().Base.Name +" contra ti!!!");
                Invoke("HitRival",5f);
            }
        }else
        {
            if (hitsController.Player.HP!=0 && hitsController.Rival.HP!=0)
            {
                if (pokemon.Speed<rival.Speed)
                {
                    Debug.Log("Golpe jugador");
                    messageCombat.GenerateTextPlayer("Tu "+hitsController.Player.Base.Name+" ha utilizado "+ hitsController.MovePlayer.Base.Name +" contra el rival!!!");
                    Invoke("HitPlayer",5f);
                }
                else
                {
                    hitsController.GenerateMoveRandom();
                    Debug.Log("Golpe enemigo");
                    messageCombat.GenerateTextEnemy(hitsController.Rival.Base.Name+" ha utilizado "+ hitsController.GetMoveRival().Base.Name +" contra ti!!!");
                    Invoke("HitRival",5f);
                }
            }else
                ChangeTurn();
        }
    }

    private void HitPlayer(){
        hitsController.HitPlayer();
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
            timeText = false;
            firstTurn = true;
            timeAttack = true;
        }
        messageCombat.OcultarMostrarDialog();
        UpdateData();
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
            messageCombat.GenerateTextPlayer("El pokemon a sido debilitado");
            
        }
        else
        {
            messageCombat.GenerateTextPlayer("Todos tus pokemons estan debilitados. Vuelves llorando a casa");
        }
        Invoke("ReturnWorld",5f);
    }
    private int TotalHPTeam(){
        return playerStatus.GetTotalHPTeam();
    }

    private void SetupBattle()
    {
        // JUEGO PREPARADO
        pokemon = playerStatus.FirstPokemon();
        rival = playerStatus.Rival;
        player.Setup(pokemon);
        playerLive.SetData(pokemon);
        enemy.Setup(rival);
        enemyLive.SetData(rival);
        options.SetMoves(pokemon);
        
        messageCombat.StartGame(rival);
        hitsController.Rival = rival;
        hitsController.Player = pokemon;
    }

    private void ReturnWorld(){
        SceneManager.LoadScene(3);
    }
    public void FinishDialog(){
        timeText = false;
    }
}


using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsController : MonoBehaviour
{
    [SerializeField] AudioClip timbre;
    [SerializeField] GameObject initial;
    [SerializeField] GameObject fightOptions;
    [SerializeField] TeamController teamController;
    private Pokemon pokemon;
    private AudioSource reproductor;
    private BattleSystem system;
    private DialogCombat dialog;
    private bool decide;
    private bool attack;
    private HitsController hitsController;
    public bool Exit{get;private set;}
    public bool Capture{get;private set;}
    
    private void Start(){
        dialog = GameObject.FindGameObjectWithTag("DialogMessage").GetComponent<DialogCombat>();
        reproductor = GetComponent<AudioSource>();
        system = GameObject.FindGameObjectWithTag("GameController").GetComponent<BattleSystem>();
        decide = false;
        attack = false;
        Exit = false;
        Capture = false;
        hitsController = HitsController.GetInstance();
    }

    void Update(){
        if (teamController.PokChange()!=null)
        {
            pokemon = teamController.PokChange();
            teamController.Reset();
            decide = true;
            attack = false;
            Exit = false;
            Capture = false;
        }
    }
    public void OpenFight()
    {
        Invoke("ChangeDialog", 0.8f);
        ReproducirTimbre();
    }

    public void OpenTeam()
    {
        Invoke("OpenList", 0.8f);
        ReproducirTimbre();
    }

    private void OpenList(){
        teamController.OpenList(pokemon);
    }


    public void ChangeDialog()
    {
        decide=false;
        if (initial.activeSelf==true)
        {
            initial.SetActive(false);
            fightOptions.SetActive(true);
        }else{
            initial.SetActive(true);
            fightOptions.SetActive(false);
        }
    }

    public void OcultAllDialog()
    {
        decide=false;
        initial.SetActive(false);
        fightOptions.SetActive(false);
    }
    

    public void ExitButton(){
        if (fightOptions.activeSelf==true)
        {
            Debug.Log("Close attacks interface");
            Invoke("ChangeDialog",1f);
        }else
        {
            Debug.Log("Try run");
            Invoke("Run",1f);
        }
        ReproducirTimbre();
    }

    private void Run()
    {
        decide = true;
        Exit = true;
        attack = false;
        Capture = false;
    }

    public void Atack(int option){
        hitsController.MovePlayer= hitsController.Player.Moves[option-1];
        Debug.Log("Active attack "+hitsController.MovePlayer.Base.Name);
        ReproducirTimbre();
        Invoke("Fight",1f);
        
    }

    private void Fight(){
        decide = true;
        attack = true;
        Exit = false;
        Capture = false;
    }
    

    public void TryCapturePokemon()
    {
        ReproducirTimbre();
        Invoke("CaptureBall",1f);

    }

    private void CaptureBall()
    {
        if (StatusRival.GetRival().IsWild && StatusPlayer.getInstance().CheckBalls()>0)
        {
            StatusPlayer.getInstance().RemoveBall();
            decide = true;
            attack = false;
            Exit = false;
            Capture = true;
        }
    }

    internal void SetMoves(Pokemon pokemon)
    {
        this.pokemon = pokemon;
        fightOptions.GetComponent<BattleMoves>().SetMoves(pokemon);
    }
    public bool IsTake(){
        return decide;
    }
    public bool IsAttack(){
        return attack;
    }
    public Pokemon GetPokemonChange(){
        return pokemon;
    }

    private void ReproducirTimbre(){
        reproductor.PlayOneShot(timbre);
    }

    public bool CheckActiveInitial(){
        return initial.gameObject.activeSelf;
    }
}

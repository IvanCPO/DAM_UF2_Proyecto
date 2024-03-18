
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsController : MonoBehaviour
{
    [SerializeField] AudioClip timbre;
    [SerializeField] GameObject initial;
    [SerializeField] GameObject fightOptions;
    private Pokemon pokemon;
    private AudioSource reproductor;
    private BattleSystem system;
    private DialogCombat dialog;
    private bool decide;
    private HitsController hitsController;
    private void Start(){
        dialog = GameObject.FindGameObjectWithTag("DialogMessage").GetComponent<DialogCombat>();
        reproductor = GetComponent<AudioSource>();
        system = GameObject.FindGameObjectWithTag("GameController").GetComponent<BattleSystem>();
        decide = false;
        hitsController = HitsController.GetInstance();
    }

    public void OpenFight()
    {
        Invoke("ChangeDialog", 0.8f);
        ReproducirTimbre();
    }

    public void ChangeDialog()
    {
        decide=false;
        if (initial.active==true)
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
        if (fightOptions.active==true)
        {
            Debug.Log("Se cierra opciones Batalla");
            Invoke("ChangeDialog",1f);
        }else{
            int val =(int) Random.Range(1f,3f);
                OcultAllDialog();
            if(val == 1){
                dialog.GenerateTextInfo("Has HUIDO");
                Invoke("RunCombat",1f);
            }else{
                dialog.GenerateTextInfo("Careces del suficiente intelecto como para escapar en este momento");
                Invoke("FalleRun",4f);
            }
        }
        ReproducirTimbre();
    }

    private void RunCombat(){
        SceneManager.LoadScene(3);
    }
    private void FalleRun(){
        ChangeDialog();
        dialog.OcultarMostrarDialog();
    }

    public void Atack(int option){
        hitsController.MovePlayer= hitsController.Player.Moves[option-1];
        ReproducirTimbre();
        Invoke("Fight",1f);
    }

    private void Fight(){
        decide = true;
    }
    internal void SetMoves(Pokemon pokemon)
    {
        this.pokemon = pokemon;
        fightOptions.GetComponent<BattleMoves>().SetMoves(pokemon);
    }
    public bool IsTake(){
        return decide;
    }

    private void ReproducirTimbre(){
        reproductor.PlayOneShot(timbre);
    }
}

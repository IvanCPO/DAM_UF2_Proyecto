using UnityEngine;

public class EvolutionController : MonoBehaviour
{
    [SerializeField] AudioClip song;
    [SerializeField] GameObject panelButtons;
    private AudioSource reproductor;
    private ListEvolutionsController list;
    private StatusPlayer status;

    public void Start(){
        status = StatusPlayer.getInstance();
        reproductor = gameObject.GetComponent<AudioSource>();
        status = StatusPlayer.getInstance();
        list = ListEvolutionsController.GetListInstance();
    }

    public void CancelEvolution(){
        list.RemovePokemon();
    }  

    public void AcceptEvolution(){
        
    }
}

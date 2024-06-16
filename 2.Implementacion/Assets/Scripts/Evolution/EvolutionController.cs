using UnityEngine;

public class EvolutionController : MonoBehaviour
{
    [SerializeField] AudioClip song;
    [SerializeField] GameObject panelButtons;
    private AudioSource reproductor;
    private StatusPlayer status;

    public void Start(){
        status = StatusPlayer.getInstance();
        reproductor = gameObject.GetComponent<AudioSource>();
        status = StatusPlayer.getInstance();
    }
}

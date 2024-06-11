using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuStartController : MonoBehaviour
{
    [SerializeField] AudioClip song;
    [SerializeField] Button buttonStart;
    private AudioSource reproductor;
    private StatusPlayer status;

    public void Start(){
        status = StatusPlayer.getInstance();
        reproductor = gameObject.GetComponent<AudioSource>();
        buttonStart.gameObject.SetActive(status.ExistJSONFileSave());
        status.LoadData();
        status = StatusPlayer.getInstance();
    }

    public void StartGame()
    {
        AudioSource audio = gameObject.GetComponent<AudioSource>();
        audio.Stop();
        ReproduceSong();
        Invoke("StartSceneGame",1f);
    }

    public void NewGame()
    {
        AudioSource audio = gameObject.GetComponent<AudioSource>();
        audio.Stop();
        ReproduceSong();
        Invoke("InitializeSceneGame",1f);
    }

    public void ExitGame()
    {
        ReproduceSong();
        Invoke("QuitGame",1f);
    }

    private void StartSceneGame()
    {
        Debug.Log("Escena de la ubicación actual: "+status.actual.SceneId+" | ubi: "+status.actual.Ubica);
        Debug.Log("Escena de la ubicación del mundo: "+status.world.SceneId+" | ubi: "+status.world.Ubica);
        SceneManager.LoadScene(status.getUbicationActual().SceneId);
    }

    private void InitializeSceneGame()
    {
        StatusPlayer.getInstance().ClearGame();
        SceneManager.LoadScene(1);
        
    }

    private void QuitGame()
    {
        Application.Quit();
    }

    private void ReproduceSong(){
        reproductor.PlayOneShot(song);
    }
}

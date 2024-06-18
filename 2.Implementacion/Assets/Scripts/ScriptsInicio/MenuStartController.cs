using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuStartController : MonoBehaviour
{
    [SerializeField] AudioClip song;
    [SerializeField] Button buttonStart;
    [SerializeField] GameObject panelNormative;
    private AudioSource reproductor;
    private StatusPlayer status;

    public void Start(){
        reproductor = gameObject.GetComponent<AudioSource>();
        status = StatusPlayer.LoadData();
        buttonStart.gameObject.SetActive(StatusPlayer.ExistJSONFileSave());
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
        Debug.Log("Escena de la ubicación actual: "+status.getUbicationActual().SceneId+" | ubi: "+status.getUbicationActual().Ubica+" | layout: "+status.getUbicationActual().Layout);
        Debug.Log("Escena de la ubicación del mundo: "+status.getUbicationWorld().SceneId+" | ubi: "+status.getUbicationWorld().Ubica+" | layout: "+status.getUbicationWorld().Layout);
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

    public void OpenNormative(){
        ReproduceSong();
        Invoke("NormativePanel",1f);
    }

    private void NormativePanel(){
        panelNormative.SetActive(!panelNormative.activeSelf);
    }
    public void CloseNormative(){
        NormativePanel();
    }
}

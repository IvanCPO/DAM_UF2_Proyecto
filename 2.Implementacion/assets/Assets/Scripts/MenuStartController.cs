using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuStartController : MonoBehaviour
{
    [SerializeField] AudioClip song;
    [SerializeField] GameObject firstPanel;
    [SerializeField] GameObject secondPanel;
    private AudioSource reproductor;

    public void Start(){
        reproductor = gameObject.GetComponent<AudioSource>();
    }

    public void StartGame()
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

    public void OptionsGame()
    {
        ReproduceSong();
        Invoke("PutOptions",1f);
    }

    public void QuitOptions()
    {
        ReproduceSong();
        Invoke("ReturnPrincipal",1f);
    }

    private void InitializeSceneGame()
    {
        SceneManager.LoadScene(1);
    }

    private void PutOptions()
    {
        firstPanel.SetActive(false);
        secondPanel.SetActive(true);
    }

    private void ReturnPrincipal()
    {
        firstPanel.SetActive(true);
        secondPanel.SetActive(false);
    }

    private void QuitGame()
    {
        Application.Quit();
    }

    private void ReproduceSong(){
        reproductor.PlayOneShot(song);
    }
}

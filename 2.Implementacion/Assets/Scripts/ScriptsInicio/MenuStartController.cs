using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuStartController : MonoBehaviour
{
    [SerializeField] AudioClip song;
    [SerializeField] GameObject firstPanel;
    private AudioSource reproductor;

    public void Start(){
        reproductor = gameObject.GetComponent<AudioSource>();
    }

    public void StartGame()
    {
        if (SaveGameController.generateSaveController().ExistGame())
        {
            AudioSource audio = gameObject.GetComponent<AudioSource>();
            audio.Stop();
            ReproduceSong();
            Invoke("StartSceneGame",1f);
        }
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
        SceneManager.LoadScene(2);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsController : MonoBehaviour
{
    [SerializeField] AudioClip song;
    private AudioSource reproductor;

    public void Start(){
        reproductor = gameObject.GetComponent<AudioSource>();
    }

    public void RestartGame()
    {
        AudioSource audio = gameObject.GetComponent<AudioSource>();
        audio.Stop();
        ReproduceSong();
        Invoke("InitializeSceneGame",1f);
    }

    private void InitializeSceneGame()
    {
        SceneManager.LoadScene(0);
    }

    private void ReproduceSong(){
        reproductor.PlayOneShot(song);
    }
}

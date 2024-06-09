using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsInitialController : MonoBehaviour
{
    // Para implementar a futuro:
    //[SerializeField] GameObject man;
    //[SerializeField] GameObject girl;
    [SerializeField] GameObject sure;
    [SerializeField] GameObject name;
    [SerializeField] GameObject start;
    [SerializeField] GameObject controls;
    [SerializeField] AudioClip song;
    private AudioSource reproductor;
    private StatusPlayer player;
    void Start()
    {
        player = StatusPlayer.getInstance();
        ChangeDialog();
        reproductor = gameObject.GetComponent<AudioSource>();
    }
    private void ChangeDialog(){
        if (!start.active)
        {
            start.SetActive(true);
            name.SetActive(false);
        }else{
            start.SetActive(false);
            name.SetActive(true);
        }
    }

    public void ButtonTutorial(){
        ReproduceSong();
        Invoke("ChangeDialog",1f);
    }
    public void IntroduceName(Text nameValue){
        ReproduceSong();
        player.GiveNamePlayer(nameValue.text);
        Invoke("IsSure",1f);
    }
    private void IsSure(){
        if (!sure.active)
        {
            sure.SetActive(true);
        }else{
            sure.SetActive(false);
        }
    }
    public void TakeDecision(string option){
        ReproduceSong();
        switch (option)
        {
            case "Yes":
                Invoke("StartGame",1f);
                break;
            case "Exit":
                Invoke("ReturnInicio",1f);
                break;
            case "Controls":
                Invoke("ChangeViewControls",1f);
                break;
            default:
                Invoke("IsSure",1f);
                break;
        }
    }

    private void ReproduceSong(){
        reproductor.PlayOneShot(song);
    }

    private void StartGame(){
        SceneManager.LoadScene(2);
        
    }

    private void ReturnInicio(){
        SceneManager.LoadScene(0);
    }

    private void ChangeViewControls(){
        if (!controls.active)
        {
            controls.SetActive(true);
        }else
            controls.SetActive(false);
    }
}

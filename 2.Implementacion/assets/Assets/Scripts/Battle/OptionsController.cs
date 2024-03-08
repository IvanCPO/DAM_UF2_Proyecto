using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsController : MonoBehaviour
{
    [SerializeField] AudioClip timbre;
    [SerializeField] GameObject initial;
    [SerializeField] GameObject fightOptions;
    AudioSource reproductor;
    private void Start(){
        reproductor = GetComponent<AudioSource>();
    }

    public void OpenFight()
    {
        Invoke("ChangeDialog", 0.8f);
        ReproducirTimbre();
    }

    private void ChangeDialog()
    {
        if (initial.active==true)
        {
            initial.SetActive(false);
            fightOptions.SetActive(true);
        }else{
            initial.SetActive(true);
            fightOptions.SetActive(false);
        }
    }

    public void ExitButton(){
        if (fightOptions.active==true)
        {
            Debug.Log("Se cierra opciones Batalla");
            Invoke("ChangeDialog",1f);
        }else{
            Debug.Log("Se intenta Huir!!!! Eres Gay");
        }
        ReproducirTimbre();
    }

    private void ReproducirTimbre(){
        reproductor.PlayOneShot(timbre);
    }
}

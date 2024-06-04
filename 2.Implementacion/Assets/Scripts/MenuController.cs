using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] GameObject buttonmenu;
    [SerializeField] GameObject buttonback;
    [SerializeField] GameObject menu;
    [SerializeField] GameObject pokemonList;
    [SerializeField] GameObject account;
    
    public void AbrirMenu(){
        //Debug.Log("TEST");
        Time.timeScale = 0f;
        buttonmenu.SetActive(false);
        buttonback.SetActive(true);
        menu.SetActive(true);
    }
    public void CerrarMenu(){
        //Debug.Log("TEST");
        Time.timeScale = 1f;
        buttonmenu.SetActive(true);
        buttonback.SetActive(false);
        menu.SetActive(false);
    }
    public void Cerrar(){
        if(pokemonList.active){
            pokemonList.GetComponent<TeamController>().Close();
        }else
        if(account.active){
            account.SetActive(false);
        }else{
            CerrarMenu();
        }
    }
    public void OpenList(){
        pokemonList.GetComponent<TeamController>().OpenList();
    }
    public void OpenAccount(){
        account.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] GameObject buttonmenu;
    [SerializeField] GameObject menu;
    [SerializeField] GameObject pokemonList;
    
    public void AbrirMenu(){
        //Debug.Log("TEST");
        Time.timeScale = 0f;
        buttonmenu.SetActive(false);
        menu.SetActive(true);
    }
    public void CerrarMenu(){
        //Debug.Log("TEST");
        Time.timeScale = 1f;
        buttonmenu.SetActive(true);
        menu.SetActive(false);
    }
    public void OpenList(){
        pokemonList.GetComponent<TeamController>().OpenList();
    }
}

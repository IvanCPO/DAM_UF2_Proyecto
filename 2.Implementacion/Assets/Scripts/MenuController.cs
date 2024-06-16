using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] GameObject buttonmenu;
    [SerializeField] GameObject buttonback;
    [SerializeField] GameObject menu;
    [SerializeField] GameObject pokemonList;
    [SerializeField] PokedexController pokedex;
    [SerializeField] GameObject account;
    [SerializeField] GameObject cure;
    
    public void AbrirMenu(){
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
        if(pokemonList.activeSelf){
            pokemonList.GetComponent<TeamController>().Close();
        }else
        if(account.activeSelf){
            account.SetActive(false);
        }else
        if(pokedex.gameObject.activeSelf){
            pokedex.gameObject.SetActive(false);
        }else
        if(cure.gameObject.activeSelf){
            cure.gameObject.SetActive(false);
        }else{
            CerrarMenu();
        }
    }
    
    public void OpenList(){
        pokemonList.GetComponent<TeamController>().OpenList();
    }
    
    public void OpenPokedex(){
        pokedex.OpenPokedex();
    }

    public void OpenAccount(){
        account.SetActive(true);
        account.GetComponent<OptionAccountController>().SetDataPlayer();
    }

    public void ExitInit(){
        SceneManager.LoadScene(0);
    }
}

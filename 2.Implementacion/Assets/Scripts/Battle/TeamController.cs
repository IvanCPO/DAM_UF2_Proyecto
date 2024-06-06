using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeamController : MonoBehaviour
{
    [SerializeField] List<DataPokemonController> pokemons;
    [SerializeField] GameObject listPokemon;
    [SerializeField] GameObject confirmPanel;
    [SerializeField] GameObject optionsPanel;
    [SerializeField] GameObject statsPanel;
    private StatusPlayer status;
    private int pokemonConfirmIndex;
    private Pokemon pokemonSelected;
    void Start()
    {
        status = StatusPlayer.getInstance();
    }
    
    public void OpenList(){
        gameObject.SetActive(true);
        pokemonSelected =null;
        Invoke("UpdatePokemons",0.0001f);
    }
    
    public void Close(){
        if (statsPanel.active)
        {
            CloseInfoTextMove();
            statsPanel.SetActive(false);
        }else{
            if (confirmPanel.active)
            {
                confirmPanel.SetActive(false);
            }else
            if (optionsPanel.active)
            {
                optionsPanel.SetActive(false);
            }else
            {
                gameObject.SetActive(false);
            }
        }
        
    }
    
    public void OpenInfoMenu(int pokemon){
        if (pokemonSelected == null)
        {
            if (SceneManager.GetActiveScene().buildIndex==4)
            {
                confirmPanel.SetActive(true);
            }else{
                optionsPanel.SetActive(true);
            }
            pokemonConfirmIndex = pokemon;
            Invoke("SetPokemonBasicData",0.000000001f);
        }else{
            status.GetTeam()[pokemonConfirmIndex] = status.GetTeam()[pokemon];
            status.GetTeam()[pokemon] = pokemonSelected;
            ChangePokemon();
        }
    }

    public void OpenPokemonInfo(){
        statsPanel.SetActive(true);
        confirmPanel.SetActive(false);
        optionsPanel.SetActive(false);
        Invoke("SetPokemonStats",0.000000001f);
    }
    private void SetPokemonStats(){
        statsPanel.GetComponent<InfoSystem>().InsertDataPokemon(status.GetTeam()[pokemonConfirmIndex]);
    }
    private void CloseInfoTextMove(){
        statsPanel.GetComponent<InfoSystem>().CloseInfo();
    }

    private void SetPokemonBasicData(){
        confirmPanel.GetComponent<ConfirmPokemonController>().OpenMenu(status.GetTeam()[pokemonConfirmIndex]);

    }
    public void ChangePokemon(){
        if (pokemonSelected==null)
        {
            pokemons[pokemonConfirmIndex].isSelected();
            pokemonSelected = status.GetTeam()[pokemonConfirmIndex];
            Close();
        }else{
            pokemons[pokemonConfirmIndex].isSelected();
            UpdatePokemons();
            pokemonSelected = null;
        }
    }

    private void UpdatePokemons(){
        Debug.Log("El numero de pokemons es de = "+status.GetTeam().Count);
        for (int i = 0; pokemons.Count < 6; i++)
        {
            if (status.GetTeam().Count>=(i+1))
            {
                pokemons[i].AddPokemon(status.GetTeam()[i]);
            }
        }
    }
}

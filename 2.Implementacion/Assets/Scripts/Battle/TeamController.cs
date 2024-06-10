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
    private Pokemon pokemonChange;

    void Start()
    {
        status = StatusPlayer.getInstance();
        pokemonChange = null;
    }
    
    public void OpenList(){
        gameObject.SetActive(true);
        pokemonSelected = null;
        pokemonChange = null;
        Invoke("UpdatePokemons",0.0001f);

    }
    
    public void OpenList(Pokemon pokemon){
        gameObject.SetActive(true);
        pokemonSelected = pokemon;
        pokemonChange = null;
        Invoke("UpdatePokemons",0.0001f);
        Invoke("CheckSelected",0.0001f);

    }
    
    public void Close(){
        if (statsPanel.activeSelf)
        {
            CloseInfoTextMove();
            statsPanel.SetActive(false);
        }else{
            if (confirmPanel.activeSelf)
            {
                confirmPanel.SetActive(false);
            }else
            if (optionsPanel.activeSelf)
            {
                optionsPanel.SetActive(false);
            }else
            {
                CheckSelected();
                gameObject.SetActive(false);
            }
        }
    }
    
    public void OpenInfoMenu(int pokemon){
        pokemonConfirmIndex = pokemon;
        if (SceneManager.GetActiveScene().buildIndex==4)
        {
            confirmPanel.SetActive(true);
            Invoke("SetPokemonBasicData",0.000000001f);
        }
        else{
            if (pokemonSelected == null)
                optionsPanel.SetActive(true);
            else
            {
                ChangePokemon();
            }
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
        if (SceneManager.GetActiveScene().buildIndex!=4)
        {
            if (pokemonSelected==null)
            {
                pokemons[pokemonConfirmIndex].isSelected();
                pokemonSelected = status.GetTeam()[pokemonConfirmIndex];
                Close();
            }else
            {
                CheckSelected();
                Invert();
                UpdatePokemons();
                pokemonSelected = null;
            }
        }
        else
        {
            if (status.GetTeam()[pokemonConfirmIndex].HP>0)
            {
                if(pokemonSelected==status.GetTeam()[pokemonConfirmIndex])
                    Close();
                else{
                    pokemonChange = status.GetTeam()[pokemonConfirmIndex];
                    Close();
                    Close();
                }
            }else{
                Close();
            }
        }
    }

    private void Invert()
    {
        for (int i = 0; i < status.GetTeam().Count; i++)
        {
            if (status.GetTeam()[i] == pokemonSelected)
            {
                status.GetTeam()[i] = status.GetTeam()[pokemonConfirmIndex];
                status.GetTeam()[pokemonConfirmIndex] = pokemonSelected;
                break;
            }
        }
    }

    public Pokemon PokChange(){
        return pokemonChange;
    }

    public void Reset(){
        pokemonChange = null;
    }

    private void CheckSelected(){
        // Debug.Log("El numero de pokemons es de = "+status.GetTeam().Count);
        for (int i = 0; i < status.GetTeam().Count; i++)
        {
            // Debug.Log("Compare "+status.GetTeam()[i].Base.Name+" is like "+pokemonSelected.Base.Name+"? "+(status.GetTeam()[i]==pokemonSelected));
            if (status.GetTeam()[i]==pokemonSelected)
            {
                pokemons[i].isSelected();
                break;
            }
        }
    }

    private void UpdatePokemons(){
        Debug.Log("El numero de pokemons es de = "+status.GetTeam().Count);
        for (int i = 0; i < 6; i++)
        {
            if (status.GetTeam().Count>=(i+1))
            {
                pokemons[i].AddPokemon(status.GetTeam()[i]);
            }
        }
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamController : MonoBehaviour
{
    [SerializeField] DataPokemonController pokemon1;
    [SerializeField] DataPokemonController pokemon2;
    [SerializeField] DataPokemonController pokemon3;
    [SerializeField] DataPokemonController pokemon4;
    [SerializeField] DataPokemonController pokemon5;
    [SerializeField] DataPokemonController pokemon6;
    [SerializeField] GameObject listPokemon;
    [SerializeField] GameObject confirmPanel;
    [SerializeField] GameObject statsPanel;
    private StatusPlayer status;
    private int pokemonConfirmIndex;
    void Start()
    {
        status = StatusPlayer.getInstance();
    }
    
    public void OpenList(){
        gameObject.SetActive(true);
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
            {
                gameObject.SetActive(false);
            }
        }
        
    }
    
    public void OpenInfoMenu(int pokemon){
        confirmPanel.SetActive(true);
        pokemonConfirmIndex = pokemon;
        Invoke("SetPokemonBasicData",0.000000001f);
    }

    public void OpenPokemonInfo(){
        statsPanel.SetActive(true);
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

    private void UpdatePokemons(){
        if (status.GetTeam().Count>=1)
        {
            pokemon1.AddPokemon(status.FirstPokemon());
        }
        if (status.GetTeam().Count>=2)
        {
            pokemon2.AddPokemon(status.GetTeam()[1]);
        }
        if (status.GetTeam().Count>=3)
        {
            pokemon2.AddPokemon(status.GetTeam()[2]);
        }
        if (status.GetTeam().Count>=4)
        {
            pokemon2.AddPokemon(status.GetTeam()[3]);
        }
        if (status.GetTeam().Count>=5)
        {
            pokemon2.AddPokemon(status.GetTeam()[4]);
        }
        if (status.GetTeam().Count==6)
        {
            pokemon2.AddPokemon(status.GetTeam()[5]);
        }
    }
}

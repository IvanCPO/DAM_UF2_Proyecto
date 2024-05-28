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
    private StatusPlayer status;
    void Start()
    {
        status = StatusPlayer.getInstance();
    }
    
    public void OpenList(){
        gameObject.SetActive(true);
        UpdatePokemons();
    }
    
    public void CloseList(){
        gameObject.SetActive(false);
    }

    private void UpdatePokemons(){
        pokemon1.AddPokemon(status.GetTeam()[0]);
        pokemon2.AddPokemon(status.GetTeam()[1]);
        pokemon3.AddPokemon(status.GetTeam()[2]);
        pokemon4.AddPokemon(status.GetTeam()[3]);
        pokemon5.AddPokemon(status.GetTeam()[4]);
        pokemon6.AddPokemon(status.GetTeam()[5]);
    }
}

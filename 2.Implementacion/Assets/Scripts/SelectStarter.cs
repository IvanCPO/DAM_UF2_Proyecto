using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectStarter : MonoBehaviour
{
    [SerializeField] Image firstPokemonImage;
    [SerializeField] Image secondPokemonImage;
    [SerializeField] Image thirdPokemonImage;
    // [SerializeField] PokemonBase firstPokemon;
    // [SerializeField] PokemonBase secondPokemon;
    // [SerializeField] PokemonBase thirdPokemon;
    private PokemonBase firstPokemon;
    private PokemonBase secondPokemon;
    private PokemonBase thirdPokemon;
    private StatusPlayer status;
    void Start()
    {
        status = StatusPlayer.getInstance();
        var connection = DDBBConector.GenerateConnection().GetConnection();
        String query = "SELECT * FROM POKEMON WHERE POKEDEX_ID = 1";
        firstPokemon = connection.CreateCommand(query).ExecuteScalar<PokemonBase>();
        query = "SELECT * FROM POKEMON WHERE POKEDEX_ID = 4";
        secondPokemon = connection.CreateCommand(query).ExecuteScalar<PokemonBase>();
        query = "SELECT * FROM POKEMON WHERE POKEDEX_ID = 7";
        thirdPokemon = connection.CreateCommand(query).ExecuteScalar<PokemonBase>();
        firstPokemonImage.sprite = firstPokemon.FrontSprite;
        secondPokemonImage.sprite = secondPokemon.FrontSprite;
        thirdPokemonImage.sprite = thirdPokemon.FrontSprite;
    }

    public void Choose(int i){
        switch (i)
        {
            case 1:
                status.SavePokemon(new Pokemon(firstPokemon,5));
                break;
            case 2:
                status.SavePokemon(new Pokemon(secondPokemon,5));
                break;
            case 3:
                status.SavePokemon(new Pokemon(thirdPokemon,5));
                break;
        }
        gameObject.SetActive(false);
    }
}

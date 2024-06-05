using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateListPokemon : MonoBehaviour
{
    [SerializeField] List<RivalTeam> rival;
    StatusPlayer player;
    private void Start(){
        player = StatusPlayer.getInstance();
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        // Comprueba si el objeto que entra en contacto es el jugador
        if (other.gameObject.CompareTag("Player"))
        {
            if(player.GetTeam().Count>0){
                // Cambia a la escena especificada
                Debug.Log("Que empiece el combate");
                foreach (RivalTeam pokemon in rival)
                {
                    player.Rival.Add(pokemon.GeneratePokemon());
                }
                // player.Rival = new Pokemon(PokemonBase.GetPokemonBase(4),levelr);
            }
        }
    }
}
[Serializable]
class RivalTeam {
    [SerializeField] int pokedexId;
    [SerializeField] int level;

    public Pokemon GeneratePokemon(){
        return new Pokemon(PokemonBase.GetPokemonBase(pokedexId),level);
    }
}
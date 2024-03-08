using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateListPokemon : MonoBehaviour
{
    [SerializeField] PokemonBase pokemon;
    [SerializeField] int level;
    StatusPlayer player;
    private void Start(){
        player = StatusPlayer.getInstance();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Comprueba si el objeto que entra en contacto es el jugador
        if (other.CompareTag("Player"))
        {
            // Cambia a la escena especificada
            Debug.Log("obtuviste un pokemon!!!!");
            player.SavePokemon(new Pokemon(pokemon,level));
        }
    }
}

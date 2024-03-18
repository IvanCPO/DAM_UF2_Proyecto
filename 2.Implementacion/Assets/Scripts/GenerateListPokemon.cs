using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateListPokemon : MonoBehaviour
{
    [SerializeField] PokemonBase rival;
    [SerializeField] int levelr;
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
                Debug.Log("obtuviste un pokemon!!!!");
                player.Rival = new Pokemon(rival,levelr);
            }
        }
    }
}

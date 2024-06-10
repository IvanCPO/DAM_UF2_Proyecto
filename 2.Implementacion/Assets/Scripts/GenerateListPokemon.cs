using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateListPokemon : MonoBehaviour
{
    [SerializeField] List<RivalTeam> rival;
    [SerializeField] string nameRival;
    [SerializeField] bool isWild;
    [SerializeField] int money;
    StatusRival rivalStatus;
    StatusPlayer player;
    private void Start(){
        rivalStatus = StatusRival.GetRival();
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
                List<Pokemon> list = new List<Pokemon>();
                foreach (RivalTeam pokemon in rival)
                {
                    list.Add(pokemon.GeneratePokemon());
                }
                if (isWild)
                {
                    rivalStatus.SetDataWild(list[0]);
                }else
                    rivalStatus.SetData(list,name,money);
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
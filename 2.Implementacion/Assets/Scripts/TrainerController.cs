using System;
using System.Collections.Generic;
using UnityEngine;

public class TrainerController : MonoBehaviour
{
    [SerializeField] string trainerName;
    [SerializeField] int idTrainer;
    [SerializeField] int money;
    [TextArea]
    [SerializeField] List<string> messageBefore;
    [TextArea]
    [SerializeField] List<string> messageLater;
    [SerializeField] List<RivalController> pokemons;
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
                foreach (RivalController pokemon in pokemons)
                {
                    list.Add(pokemon.GeneratePokemon());
                }
                rivalStatus.SetData(list,name,money);
            }
            
        }
    }
}

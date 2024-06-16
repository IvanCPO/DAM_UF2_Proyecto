using System;
using UnityEngine;

public class WildPokemonController : MonoBehaviour
{
    [SerializeField] RivalController rival;
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
                StartFight(rival);
            }
            
        }
    }
    
    public void StartFight(RivalController rival){
        Debug.Log("Que empiece el combate");
        rivalStatus.SetDataWild(rival.GeneratePokemon());
    }
}
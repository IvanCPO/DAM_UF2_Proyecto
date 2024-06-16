using System;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerPokemon : MonoBehaviour
{
    System.Random random;
    [SerializeField] List<int> idPokedex;
    [SerializeField] int maxLevel;
    [SerializeField] int minLevel;
    StatusRival rivalStatus;
    StatusPlayer player;
    void Start()
    {
        random = new System.Random();
        rivalStatus = StatusRival.GetRival();
        player = StatusPlayer.getInstance();
    }

    void OnTriggerStay2D(Collider2D c){
        int num = random.Next(0, 150);
        if (num == 33){
            Debug.Log("Pokemon Find");
            StartFight(ObteinPokemon());
        }
    }

    private RivalController ObteinPokemon()
    {
        int idPokemon = random.Next(0, idPokedex.Count-1);
        int level = random.Next(minLevel, maxLevel);
        return new RivalController(idPokedex[idPokemon], level);
    }

    public void StartFight(RivalController rival){

        if(player.GetTeam().Count>0){
            // Cambia a la escena especificada
            Debug.Log("Que empiece el combate");
            rivalStatus.SetDataWild(rival.GeneratePokemon());
            gameObject.GetComponent<ChangeSceneController>().Saver();
        }
    }
}

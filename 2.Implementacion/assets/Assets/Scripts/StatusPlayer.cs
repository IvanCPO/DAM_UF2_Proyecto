using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusPlayer
{
    private static StatusPlayer instance;
    private List<Pokemon> myTeam;
    private List<Pokemon> myPokemons;
    private String name;
    private GameObject genero;
    private String[] medallas;
    private String place;

    private StatusPlayer(){
        myTeam = new List<Pokemon>();
        myPokemons = new List<Pokemon>();
        medallas = new string[8];
        place = "Casa Abuela";
    }

    public static StatusPlayer getInstance(){
        if (instance==null)
        {
            instance = new StatusPlayer();
        }
        return instance;
    }

    public void SavePokemon(Pokemon pokemon){
        if (myTeam.Count<6)
            myTeam.Add(pokemon);
        myPokemons.Add(pokemon);
    }

    public void SaveUserPlayer(String name, GameObject prefab){
        this.name = name;
        this.genero = prefab;
    }

    public Pokemon FirstPokemon(){
        return myTeam[0];
    }
}

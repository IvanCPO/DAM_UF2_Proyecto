using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using UnityEngine;

[System.Serializable]
public class StatusPlayer
{
    private static StatusPlayer instance;
    private List<Pokemon> myTeam;
    public Pokemon Rival{get;set;}
    private List<Pokemon> myPokemons;
    private String name;
    // TODO Para implementrae a futuro
    //private GameObject genero;
    private int money;
    Stopwatch time;
    private bool[] medallas;
    private Vector3 ubicationWorld;

    private StatusPlayer(){
        myTeam = new List<Pokemon>();
        name = "";
        myPokemons = new List<Pokemon>();
        medallas = new bool[3]{false,false,false};
        ubicationWorld = new Vector3(5.5f,-34.7f,0f);
        Rival = null;
        money = 0;
        time = new Stopwatch();
    }

    public static StatusPlayer getInstance(){
        if (instance==null)
        {
            instance = new StatusPlayer();
        }
        return instance;
    }
    public void clearGame(){
        instance = new StatusPlayer();
    }

    public string GetName(){
        return name;
    }
    public void SavePokemon(Pokemon pokemon){
        if (myTeam.Count<6)
            myTeam.Add(pokemon);
        myPokemons.Add(pokemon);
    }

    /* public void SaveUserPlayer(String name, GameObject prefab){
        this.name = name;
        this.genero = prefab;
    } */

    public void SaveUserPlayer(String name){
        this.name = name;
        
    }

    /*public GameObject GetPlayerGenere(){
        return genero;
    }*/

    public Pokemon FirstPokemon(){
        return myTeam[0];
    }
    public List<Pokemon> GetTeam(){
        return myTeam;
    }
    public void RestaureAll(){
        foreach (Pokemon pokemon in myTeam)
        {
            pokemon.Recuperate();
        }
    }

    public void SaveOldUbication(Vector3 vector3){
        ubicationWorld = vector3;
    }
    public Vector3 getUbicationWorld(){
        return ubicationWorld;
    }

    internal int GetTotalHPTeam()
    {
        int count = 0;
        foreach (Pokemon pokemon in myTeam)
        {
            count+=pokemon.HP;
        }
        return count;
    }


}

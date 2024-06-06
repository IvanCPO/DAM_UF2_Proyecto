using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

[System.Serializable]
public class StatusPlayer
{
    private static StatusPlayer instance;
    private List<Pokemon> myTeam;
    public List<Pokemon> Rival{get;set;}
    private List<Pokemon> myPokemons;
    private string name;
    // TODO Para implementrae a futuro
    //private GameObject genero;
    private int money;
    private bool[] medallas;
    private Vector3 ubicationWorld;

    private StatusPlayer(){
        myTeam = new List<Pokemon>();
        name = "Iván";
        myPokemons = new List<Pokemon>();
        medallas = new bool[3]{false,false,false};
        ubicationWorld = new Vector3(5.5f,-34.7f,0f);
        Rival = new List<Pokemon>();
        money = 0;
    }

    public static StatusPlayer getInstance(){
        if (instance==null)
        {
            instance = new StatusPlayer();
        }
        return instance;
    }
    public void ClearGame(){
        instance = new StatusPlayer();
    }

    public string GetName(){
        return name;
    }

    public int GetMoney(){
        return money;
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
    public bool[] Medallas{
        get{return medallas;}
    }

    public void SaveUserPlayer(string name){
        this.name = name;
        
    }

    /*public GameObject GetPlayerGenere(){
        return genero;
    }*/

    public Pokemon FirstPokemon(){
        Pokemon pokemon;
        foreach (Pokemon p in GetTeam())
        {
            if (p.HP!=0)
            {
                pokemon = p;
                break;
            }
        }
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

    public void ClearRival(){
        Rival = new List<Pokemon>();
    }

    public int GetRivalHPTeam()
    {
        int count = 0;
        foreach (Pokemon pokemon in Rival)
        {
            count+=pokemon.HP;
        }
        return count;
    }

}

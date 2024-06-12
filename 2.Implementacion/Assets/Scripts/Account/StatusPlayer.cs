using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class StatusPlayer
{
    [System.NonSerialized] private static StatusPlayer instance;
    public List<Pokemon> myTeam;
    public List<Pokemon> myPokemons;
    public string userName;
    // TODO Para implementrae a futuro
    //public GameObject genero;
    public int money;
    public bool[] medallas;

    public Bag bag;
    
    public Ubication world;
    public Ubication actual;
    public Ubication restUbi;
    private string path;

    private StatusPlayer(){
        myTeam = new List<Pokemon>();
        userName = "Iván";
        myPokemons = new List<Pokemon>();
        medallas = new bool[3]{false,false,false};
        money = 0;
        bag = new Bag();
        world = new Ubication(new Vector3(5.5f,-34.7f,0f),"Layer 1",3);
        actual = new Ubication(new Vector3(0f,0f,0f),"Layer 1",2);
        restUbi = new Ubication(new Vector3(0f,0f,0f),"Layer 1",2);
        path = Application.streamingAssetsPath + "/GameStatus.json";
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
        return userName;
    }

    public void GiveNamePlayer(string name){
        this.userName = name;
    }

    public int GetMoney(){
        return money;
    }

    public void AddMoney(int money){
        this.money+=money;
    }

    public void RemoveMoney(int money){
        this.money-=money;
        if (money<0)
        {
            money = 0;
        }
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

    /*public GameObject GetPlayerGenere(){
        return genero;
    }*/

    public Pokemon FirstPokemon(){
        Pokemon pokemon = GetTeam()[0];
        foreach (Pokemon p in GetTeam())
        {
            if (p.HP!=0)
            {
                pokemon = p;
                break;
            }
        }
        return pokemon;
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

    internal int GetTotalHPTeam()
    {
        int count = 0;
        foreach (Pokemon pokemon in myTeam)
        {
            count+=pokemon.HP;
        }
        return count;
    }


    public void SaveUbication(Vector3 ubication, string layout, int scene){
        Ubication u = new Ubication(ubication, layout, scene);
        actual = u;
        if (scene == 3){
            world = u;
        }
    }

    public void SaveRestUbication(Vector3 ubication, string layout, int scene){
        restUbi = new Ubication(ubication, layout, scene);
    }
    
    public Ubication getUbicationWorld(){
        return world;
    }
    
    public Ubication getUbicationActual(){
        return actual;
    }
    
    public Ubication getUbicationRest(){
        return restUbi;
    }

    public void SaveData(){
        string json = JsonUtility.ToJson(this);
        
        File.WriteAllText(path, json);
        Debug.Log("JSON guardado en: " + path);
    }

    public void LoadData(){
        try
        {
            if (ExistJSONFileSave())
            {
                string loadedJson = File.ReadAllText(path);
                instance = JsonUtility.FromJson<StatusPlayer>(loadedJson);
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Error al leer el archivo JSON: " + e.Message);
        }
    }
    public bool ExistJSONFileSave(){
        return File.Exists(path);
    }

}

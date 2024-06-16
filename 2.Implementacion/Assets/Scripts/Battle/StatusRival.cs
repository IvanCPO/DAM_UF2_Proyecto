using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class StatusRival
{
    private static StatusRival status;
    public int IDTrainer{get; private set;}
    public string NameRival{get; private set;}
    public List<Pokemon> Team{get;set;}
    public bool IsWild{get; private set;}
    public int Money{get; private set;}


    private StatusRival(){
        Team = new List<Pokemon>();
    }

    public static StatusRival GetRival(){
        if (status == null)
        {
            status = new StatusRival();
        }
        return status;
    }

    public void SetDataWild(Pokemon pokemon){
        IsWild = true;
        Team.Add(pokemon);
    }

    public void SetData(List<Pokemon> team, int id, string name, int money){
        IsWild = false;
        this.Team = team;
        IDTrainer = id;
        NameRival = name;
        this.Money = money;
    }

    public void Clear(){
        IsWild = false;
        Team = new List<Pokemon>();
        NameRival ="";
        Money = 0;
    }

    public int TotalRivalHP(){
        int count = 0;
        foreach (Pokemon pokemon in Team)
        {
            count+=pokemon.HP;
        }
        return count;
    }

    public Pokemon FirstPokemonLive(){
        foreach (Pokemon pokemon in Team)
        {
            if (pokemon.HP>0)
            {
                return pokemon;
            }
        }
        return null;
    }
}

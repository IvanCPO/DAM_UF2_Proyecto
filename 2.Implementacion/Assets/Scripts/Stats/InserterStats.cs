using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InserterStats : MonoBehaviour, InterfaceData
{
    
    [SerializeField] Text hp;
    [SerializeField] Text attack;
    [SerializeField] Text defense;
    [SerializeField] Text spAttack;
    [SerializeField] Text spDefense;
    [SerializeField] Text speed;

    public void InsertDataPokemon(Pokemon pokemon)
    {
        hp.text = pokemon.HP+"/"+pokemon.MaxHP;
        attack.text = pokemon.Attack.ToString();
        defense.text = pokemon.Defense.ToString();
        spAttack.text = pokemon.SpAttack.ToString();
        spDefense.text = pokemon.SpDefense.ToString();
        speed.text = pokemon.Speed.ToString();
    }
}

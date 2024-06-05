using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataPokemonController : MonoBehaviour
{
    [SerializeField] Text namePokemon;
    [SerializeField] Text levelPokemon;
    [SerializeField] Text hpCount;
    [SerializeField] HPBar hpBar;
    [SerializeField] GameObject expBar;
    private Pokemon pokemon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pokemon!=null)
        {
            namePokemon.text = pokemon.Base.Name;
            levelPokemon.text = "Lvl. "+pokemon.Level;
            hpCount.text = "HP "+pokemon.HP+"/"+pokemon.MaxHP;
        }else
        {
            Debug.Log("El pokemon no existe.");
            gameObject.SetActive(false);
        }
    }

    public void AddPokemon(Pokemon pokemon){
        if (pokemon!=null)
        {
            gameObject.SetActive(true);
            this.pokemon = pokemon;
        }
    }
}

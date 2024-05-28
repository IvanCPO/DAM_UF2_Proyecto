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
        if (pokemon == null)
        {
            gameObject.SetActive(false);
        }
        else{
            gameObject.SetActive(true);
        }
    }

    public void AddPokemon(Pokemon pokemon){
        this.pokemon = pokemon;
    }
}

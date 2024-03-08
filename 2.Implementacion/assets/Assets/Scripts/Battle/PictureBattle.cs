using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PictureBattle : MonoBehaviour
{
    // PARA TESTEO
    //[SerializeField] PokemonBase _base;
    //[SerializeField] int level;
    [SerializeField] bool isPlayer;
    public Pokemon Pokemon{get;set;}
    // PARA TESTEO
    /*public void Setup (){
        //Pokemon = new Pokemon(_base,level);
        if (isPlayer)
            GetComponent<Image>().sprite = pokemon.Base.BackSprite;
        else
            GetComponent<Image>().sprite = pokemon.Base.FrontSprite;
    }*/

    
    //CUANDO EL JUEGO ESTA COMPLETO
    public void Setup ( Pokemon pokemon ){
        //Pokemon = new Pokemon(_base,level);
        if (isPlayer)
            GetComponent<Image>().sprite = pokemon.Base.BackSprite;
        else
            GetComponent<Image>().sprite = pokemon.Base.FrontSprite;

        
    }
}

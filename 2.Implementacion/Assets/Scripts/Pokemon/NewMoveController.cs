using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMoveController : MonoBehaviour
{
    [SerializeField] QuestionMoveController question;
    Pokemon pokemon;
    bool decision;

    void Start(){
        pokemon = null;
    }
    public void LearnMove(Pokemon pokemon, MoveBase move){
        this.pokemon = pokemon;
        decision = false;
        gameObject.SetActive(true);
        
    }
    public Pokemon ReturnPokemon(){
        return pokemon;
    }

    public bool IsDecided(){
        return false;
    }

}

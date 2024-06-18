using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMoveController : MonoBehaviour
{
    [SerializeField] QuestionMoveController question;
    [SerializeField] AddMoveController addMove;
    Pokemon pokemon;
    bool decision;
    bool changeMove;

    void Start(){
        decision=false;
        pokemon = null;
    }
    public void LearnMove(Pokemon pokemon, MoveBase move){
        this.pokemon = pokemon;
        decision = false;
        changeMove = false;
        addMove.SetData(pokemon, new Move(move));
        question.SetData(pokemon, new Move(move));
        gameObject.SetActive(true);
        
    }

    public Pokemon ReturnPokemon(){
        return pokemon;
    }

    public bool IsDecided(){
        return decision;
    }

    public bool IsChange(){
        decision=false;
        return changeMove;
    }

    public void Open(){
        if (addMove.isActive())
        {
            decision=true;
            changeMove = true;
            gameObject.SetActive(false);
        }
        addMove.ChangeActive();
        question.ChangeActive();
    }

    public void Close(){
        if (addMove.isActive())
        {
            addMove.ChangeActive();
            question.ChangeActive();
        }else{
            gameObject.SetActive(false);
            decision = true;
        }
    }

    public void Clear(){
        decision = false;
        changeMove = false;
    }

    public void LearnAlone(){
        decision = true;
        changeMove = true;
    }
    


}

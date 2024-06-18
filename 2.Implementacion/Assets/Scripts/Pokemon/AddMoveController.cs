using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddMoveController : MonoBehaviour
{
    [SerializeField] OptionMoveController newMove;
    [SerializeField] BattleMoves battleMoves;
    [SerializeField] InfoTextController info;
    [SerializeField] NewMoveController parent;
    private Pokemon pokemon;
    private Move move;
    private StatusPlayer status;

    void Start (){
        status = StatusPlayer.getInstance();
    }

    public void SetData(Pokemon pokemon, Move move){
        this.pokemon = pokemon;
        HitsController.GetInstance().Player = pokemon;
        this.move = move;
        battleMoves.SetMoves(pokemon);
        newMove.SetDataMove(move);
        info.InsertDataMove(move);
    }

    public void CheckInfoMove(int moveIndex){
        if (moveIndex==4)
            info.InsertDataMove(move);
        else{
            if (battleMoves.IsSelected(moveIndex))
            {
                HitsController.GetInstance().Player.ChangeMove(move,moveIndex);
                parent.Open();
            }else{
                battleMoves.ClearMovesSelected();
            }
            
            battleMoves.GetMoves()[moveIndex].ChangeSelected();
            info.InsertDataMove(pokemon.Moves[moveIndex]);
        }
    }
    public bool isActive(){
        return gameObject.active;
    }
    public void ChangeActive(){
        gameObject.SetActive(!gameObject.activeSelf);
    }
}

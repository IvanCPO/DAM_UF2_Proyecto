using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleMoves : MonoBehaviour
{
    [SerializeField] List<OptionMoveController> movesButton;
    public void SetMoves(Pokemon pokemon){
        for (int i = 0; i < 4; i++)
        {
            if (i<pokemon.Moves.Count)
            {
                if (pokemon.Moves[i].PP == 0)
                {
                    movesButton[i].SetDataMove(null);
                }else
                    movesButton[i].SetDataMove(pokemon.Moves[i]);
            }else
            {
                movesButton[i].SetDataMove(null);
            }
            
        }
    }
    
}

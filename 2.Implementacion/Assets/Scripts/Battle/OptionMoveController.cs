using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionMoveController : MonoBehaviour
{  
    [SerializeField] Text nameMove;
    [SerializeField] Text ppMove;
    private Move move;

    private void Update(){
        ppMove.text = "PP "+move.PP+"/"+move.Base.PP;
        if (move.PP==0)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }
    public void SetDataMove(Move move){
        if(move != null){
            this.move = move;
            nameMove.text = move.Base.Name;
        }else{
            gameObject.SetActive(false);
        }
    }

    public void RemoveAPP(){
        move.PP--;
    }
}

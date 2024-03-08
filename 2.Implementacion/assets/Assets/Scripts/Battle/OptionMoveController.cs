using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionMoveController : MonoBehaviour
{  
    [SerializeField] Text nameMove;
    [SerializeField] Text ppMove;

    public void SetDataMove(Move move){
        if(move != null){
            nameMove.text = move.Base.Name;
            ppMove.text = "PP "+move.PP+"/"+move.Base.PP;
        }else{
            gameObject.SetActive(false);
        }
    }
}

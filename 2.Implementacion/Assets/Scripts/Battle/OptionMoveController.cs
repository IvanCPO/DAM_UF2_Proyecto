using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionMoveController : MonoBehaviour
{  
    [SerializeField] Text nameMove;
    [SerializeField] Text ppMove;
    [SerializeField] PictureTypeController type;
    private Move move;

    public void SetDataMove(Move move){
        if(move != null){
            this.move = move;
            nameMove.text = move.Base.Name;
            ppMove.text = "PP "+move.PP+"/"+move.Base.PP;
            type.UpdatePictureType(move.Base.Type);
        }else{
            gameObject.SetActive(false);
        }
    }

    public void RemoveAPP(){
        move.PP--;
        ppMove.text = "PP "+move.PP+"/"+move.Base.PP;
    }
}

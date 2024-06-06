using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PictureEfectController : MonoBehaviour
{

    public void UpdatePictureEfect(Efect efect){
        gameObject.GetComponent<Image>().sprite = gameObject.GetComponent<EfectEnum>().GetSpriteEfect(efect);
    }
    public void SetPictureAilment(Efect efect){
        if (efect==Efect.NONE)
        {
            gameObject.SetActive(false);
        }else{
            gameObject.SetActive(true);
        }
        gameObject.GetComponent<Image>().sprite = gameObject.GetComponent<EfectEnum>().GetSpriteEfect(efect);
    }
}

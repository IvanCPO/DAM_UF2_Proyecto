using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[Serializable]
public class PictureBattle : MonoBehaviour
{
    [SerializeField] bool isPlayer;
    public Pokemon Pokemon{get;set;}

    void Update(){
        if (Pokemon!=null)
        {
            gameObject.SetActive(true);
        }else{
            gameObject.SetActive(false);
        }
    }

    //CUANDO EL JUEGO ESTA COMPLETO
    public void Setup ( Pokemon pokemon ){
        //Pokemon = new Pokemon(_base,level);
        gameObject.SetActive(true);
        Pokemon = pokemon;
        if (isPlayer)
            GetComponent<Image>().sprite = pokemon.Base.BackSprite;
        else
            GetComponent<Image>().sprite = pokemon.Base.FrontSprite;

        
    }

    public void ThrowAnimationAttack(){
        StopAnimation();
        Invoke("StopAnimation",0.5f);
    }

    public void ThrowAnimationGo(){
        StopAnimation();
        Invoke("StopAnimation",0.5f);
    }

    public void ThrowAnimationReturn(){
        StopAnimation();
        Invoke("StopAnimation",0.5f);
    }
    private void StopAnimation(){
        var isAttack = gameObject.GetComponent<Animator>().GetBool("isAttack");
        gameObject.GetComponent<Animator>().SetBool("isAttack",!isAttack);
    }
    public void ActiveDisact(){
        gameObject.SetActive(!gameObject.activeSelf);
    }
}

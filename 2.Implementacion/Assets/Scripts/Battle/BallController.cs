using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    [SerializeField] GameObject ballThrow;
    [SerializeField] GameObject ballMove;
    
    void Start(){
        ballMove.SetActive(false);
    }
    public void AnimationThrowBall(){
        ballThrow.SetActive(true);
        ballThrow.GetComponent<Animator>().SetBool("IsThrow",true);
    }


    public void StopAnimationThrow(){
        // ballMove.SetActive(true);
        ballThrow.SetActive(false);
        ballThrow.GetComponent<Animator>().SetBool("IsThrow",false);
    }
    
    
    public void AnimationMoveBall(){
        ballMove.GetComponent<Animator>().SetBool("move",true);
    }
    public void Stop(){
        ballMove.SetActive(false);
        ballThrow.GetComponent<Animator>().SetBool("IsThrow",false);
        // ballMove.GetComponent<Animator>().SetBool("move",false);
    }
    
    public void CaptureFinish(){
        ballThrow.GetComponent<Image>().color = Color.grey;
    }
    
    public void BallMoveActivation(){
        ballMove.SetActive(!ballMove.activeSelf);
    }
}

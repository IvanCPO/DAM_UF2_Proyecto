using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;
    [SerializeField] float speed;
    private bool canMove;
    void Start()
    {
        canMove = true;
        animator = GetComponent<Animator>();
    }
    public void ChangeMove(){
        if(canMove){
            canMove = false;
        }
        else{
            canMove = true;
        }
    }

    void Update()
    {
        if (canMove){
            float run = 1;
            Vector3 direction = Vector3.zero;
            bool IsMoving=false;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                run = 1.75f;
            }
            if (Input.GetKey(KeyCode.A))
            {
                animator.SetInteger("Horizontal",-1);
                animator.SetInteger("Vertical",0);
                IsMoving = true;
                direction.x=-1;
            }
            if (Input.GetKey(KeyCode.W))
            {
                animator.SetInteger("Vertical",1);
                animator.SetInteger("Horizontal",0);
                IsMoving = true;
                direction.y=1;
            }
            if (Input.GetKey(KeyCode.D))
            {
                animator.SetInteger("Horizontal",1);
                animator.SetInteger("Vertical",0);
                IsMoving = true;
                direction.x=1;
            }
            if (Input.GetKey(KeyCode.S))
            {
                animator.SetInteger("Vertical",-1);
                animator.SetInteger("Horizontal",0);
                IsMoving = true;
                direction.y=-1;
            }
            animator.SetBool("isRunning",IsMoving);
            direction = direction.normalized;
            transform.Translate(direction*speed*run*Time.deltaTime);
        }
    }

    //private int count = 0;

    /*void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("End"))
        {
            if (count==0)
            {
                count++;
            canMove=false;
            GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
            Animator animator = camera.GetComponent<Animator>();
            animator.SetBool("IsTheEnd",true);
            }
        }
    }*/
}

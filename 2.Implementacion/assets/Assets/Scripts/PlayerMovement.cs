using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;
    [SerializeField] float speed;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
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

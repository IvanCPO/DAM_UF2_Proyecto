using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestColisionController : MonoBehaviour
{
    [SerializeField] CureController cure;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            cure.SetData(StatusPlayer.getInstance());
        }
    }
}

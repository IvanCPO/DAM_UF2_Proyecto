using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] MoveBase moveBase;

    
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            StatusPlayer.getInstance().FirstPokemon().addMove(moveBase);
        }
    }
}

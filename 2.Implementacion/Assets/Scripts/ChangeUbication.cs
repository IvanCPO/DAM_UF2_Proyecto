using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChangeUbication : MonoBehaviour
{
    [SerializeField] float ubicationX;
    [SerializeField] float ubicationY;


    private void OnTriggerEnter2D(Collider2D other)
    {
        // Comprueba si el objeto que entra en contacto es el jugador
        if (other.CompareTag("Player"))
        {
            other.GameObject().transform.position = new Vector3(ubicationX,ubicationY,0f);
            
        }
    }
}

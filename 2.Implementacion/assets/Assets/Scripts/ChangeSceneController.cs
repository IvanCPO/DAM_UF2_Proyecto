using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneController : MonoBehaviour
{
    [SerializeField] int scene;
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Comprueba si el objeto que entra en contacto es el jugador
        if (other.CompareTag("Player"))
        {
            // Cambia a la escena especificada
            SceneManager.LoadScene(scene);
        }
    }
}

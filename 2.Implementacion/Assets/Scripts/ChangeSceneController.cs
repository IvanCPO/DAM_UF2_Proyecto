using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneController : MonoBehaviour
{
    [SerializeField] int scene;
    private GameManager game;
    void OnCollisionEnter2D(Collision2D other)
    {
        // Comprueba si el objeto que entra en contacto es el jugador
        if (other.gameObject.CompareTag("Player"))
        {
            if(SceneManager.GetActiveScene().buildIndex == 3){
                game = other.gameObject.GetComponent<GameManager>();
                Vector3 loc = new Vector3(other.gameObject.transform.position.x,
                other.gameObject.transform.position.y-0.1f,other.gameObject.transform.position.z);
                game.SaveUbication(loc);
            }
            
            // Cambia a la escena especificada
            SceneManager.LoadScene(scene);
        }
    }
}

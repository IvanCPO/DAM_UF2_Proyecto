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
            game = other.gameObject.GetComponent<GameManager>();
            Debug.Log("Name game controller = " + game.ToString());
            if(SceneManager.GetActiveScene().buildIndex == 3){
                Debug.Log(game.ToString());
                Vector3 loc = new Vector3(other.gameObject.transform.position.x,
                other.gameObject.transform.position.y-0.1f,other.gameObject.transform.position.z);
                string layout = LayerMask.LayerToName(other.gameObject.layer);
                Debug.Log("nombre del layout = "+layout);
                game.SaveUbication(loc, layout);
            }
            
            // Cambia a la escena especificada
            SceneManager.LoadScene(scene);
        }
    }
}

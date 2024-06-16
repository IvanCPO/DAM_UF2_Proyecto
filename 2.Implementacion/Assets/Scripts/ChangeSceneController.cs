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
            
            try
            {
                gameObject.GetComponent<TrainerController>().ExistThis();
            }
            catch (System.NullReferenceException)
            {
                    Saver(this.scene);
            }
        }
    }

    public void Saver(int changeScene = 4)
    {
        GameObject player = GameObject.FindWithTag("Player");
        game = player.GetComponent<GameManager>();
        Debug.Log(game.ToString());
        Vector3 loc = new Vector3(player.transform.position.x,
        player.gameObject.transform.position.y - 0.1f, player.transform.position.z);
        string layout = player.GetComponent<SpriteRenderer>().sortingLayerName;
        Debug.Log("nombre del layout = " + layout);
        game.SaveUbication(loc, layout, player.scene.buildIndex, changeScene);
        SceneManager.LoadScene(changeScene);
    }
}

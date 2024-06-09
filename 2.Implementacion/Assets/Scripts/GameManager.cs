using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    private StatusPlayer status;
    void Start()
    {
        status = StatusPlayer.getInstance();
        ApplyUbication();
    }

    public void ApplyUbication(){
        if (SceneManager.GetActiveScene().buildIndex==3)
        {
            gameObject.layer = LayerMask.NameToLayer(status.getUbicationWorld().Layout);
            gameObject.GetComponent<SpriteRenderer>().sortingLayerName = status.getUbicationWorld().Layout;

            if (status.GetTotalHPTeam()==0 && status.GetTeam().Count>0)
            {
                RestPokemons();
            }
            else
            {
                Debug.Log("Bienvenido a casa jefe");
                gameObject.transform.position= status.getUbicationWorld().Ubica;
            }
        }
    }

    private void RestPokemons()
    {
        SceneManager.LoadScene(status.getUbicationRest().SceneId);
        Debug.Log("Restaura la vida jefe");
        status.RestaureAll();
        gameObject.transform.position = status.getUbicationRest().Ubica;
        gameObject.layer = LayerMask.NameToLayer(status.getUbicationRest().Layout);
        gameObject.GetComponent<SpriteRenderer>().sortingLayerName = status.getUbicationRest().Layout;
    }

    public void SaveUbication(Vector3 vector, string layer){
        status.SaveUbication(vector, layer,SceneManager.GetActiveScene().buildIndex);
    }
}

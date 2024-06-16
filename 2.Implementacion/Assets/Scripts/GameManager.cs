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
            gameObject.transform.position= status.getUbicationWorld().Ubica;
            
        }else{
            
            if (status.GetTotalHPTeam()==0 && status.GetTeam().Count>0)
            {
                RestPokemons();
            }
            else if (status.getUbicationActual()!=null)
            {
                gameObject.layer = LayerMask.NameToLayer(status.actual.Layout);
                gameObject.GetComponent<SpriteRenderer>().sortingLayerName = status.actual.Layout;
                gameObject.transform.position= status.actual.Ubica;
            }
        }
    }

    private void RestPokemons()
    {
        Debug.Log("Restaura la vida jefe");
        status.RestaureAll();
        gameObject.transform.position = status.getUbicationRest().Ubica;
        gameObject.layer = LayerMask.NameToLayer(status.getUbicationRest().Layout);
        gameObject.GetComponent<SpriteRenderer>().sortingLayerName = status.getUbicationRest().Layout;
    }

    public void SaveUbication(Vector3 vector, string layer, int old_scene, int new_scene){
        status.SaveUbication(vector, layer, old_scene);
        if (new_scene!=4){
            status.actual = null;
        }
    }
}

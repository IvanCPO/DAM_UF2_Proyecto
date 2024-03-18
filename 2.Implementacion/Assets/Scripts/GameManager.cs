using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject avatarMan;
    private StatusPlayer status;
    private Vector3 spawnRest;
    void Start()
    {
        spawnRest = new Vector3(-5.5f,-27f,0f);
        status = StatusPlayer.getInstance();
        
        if (SceneManager.GetActiveScene().buildIndex==3)
        {
            if (status.GetTotalHPTeam()==0 && status.GetTeam().Count>0)
            {
                gameObject.transform.position = spawnRest;
            }else{
                //NO ME FUNCIONA
                /*if ( gameObject.transform.position.y > -14 && gameObject.transform.position.y < -15)
                {
                    Debug.Log("Funciona?");
                    gameObject.GetComponent<SpriteRenderer>().sortingLayerID = 2;
                }*/
                gameObject.transform.position= status.getUbicationWorld();
            }
                
        }
    }

    
    public void SaveUbication(Vector3 vector){
        status.SaveOldUbication(vector);
    }
}

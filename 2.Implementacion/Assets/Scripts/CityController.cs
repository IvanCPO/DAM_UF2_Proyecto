using UnityEngine;
using UnityEngine.UI;

public class CityController : MonoBehaviour
{
    
    [SerializeField] AudioClip song;
    [SerializeField] GameObject dialogCity;
    [SerializeField] Text text;
    private float x;
    private float y;

    public void ActivateQuestion(string city,float x, float y){
        this.x = x;
        this.y = y;
        dialogCity.SetActive(true);
        text.text = "QUIERES VIAJAR A "+city.ToUpper()+"?";
    }
    public void YesOption(){
        Invoke("ChangeCity",1f);
    }
    public void NoOption(){
        dialogCity.SetActive(false);
    }

    private void ChangeCity(){
        dialogCity.SetActive(false);
        GameObject colision = GameObject.FindGameObjectWithTag("Player");
        colision.transform.position = new Vector3(x,y,0f);
    }
}

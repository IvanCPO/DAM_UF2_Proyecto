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
        text.text = "QUIERES VIAJAR A "+city.ToUpper()+"? [33€]";
    }
    public void YesOption(){
        if (StatusPlayer.getInstance().GetMoney()>=33)
        {
            Invoke("ChangeCity",1f);
        }
    }
    public void NoOption(){
        dialogCity.SetActive(false);
    }

    private void ChangeCity(){
        dialogCity.SetActive(false);
        StatusPlayer.getInstance().RemoveMoney(33);
        GameObject colision = GameObject.FindGameObjectWithTag("Player");
        colision.transform.position = new Vector3(x,y,0f);
    }
}

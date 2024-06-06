using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoTextController : MonoBehaviour
{
    [SerializeField] Text infoData;
    [SerializeField] Text power;
    [SerializeField] Text acierto;
    [SerializeField] InsertPictureDamage classDamage;
    [SerializeField] PictureTypeController typePicture;
    [SerializeField] PictureEfectController efectPicture;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InsertDataMove(Move move)
    {
        gameObject.SetActive(true);
        infoData.text = move.Base.Description;
        power.text = move.Base.Power.ToString();
        acierto.text = move.Base.Accuracy.ToString();
        typePicture.UpdatePictureType(move.Base.Type);
        efectPicture.UpdatePictureEfect(move.Base.GetEfect);
        classDamage.UpdatePictureDamage(move);
        
    }

    public void CloseText(){
        gameObject.SetActive(false);
    }
}

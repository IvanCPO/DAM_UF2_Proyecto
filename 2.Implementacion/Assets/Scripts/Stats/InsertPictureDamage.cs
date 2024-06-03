
using UnityEngine;
using UnityEngine.UI;

public class InsertPictureDamage : MonoBehaviour
{
    public void UpdatePictureDamage(Move move){
        GetComponent<Image>().sprite = GetComponent<ClassDamageEnum>().GetSpriteDamage(move.Base.GetClassDamage);
    }
}

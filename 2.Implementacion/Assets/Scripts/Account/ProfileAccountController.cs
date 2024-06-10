using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfileAccountController : MonoBehaviour
{
    [SerializeField] Text name;
    [SerializeField] Text money;
    [SerializeField] SaveAnimationController save;

    public void SetData(StatusPlayer status){
        name.text = status.GetName();
        money.text = status.GetMoney()+"€";
    }
    public void SaveGame(){
        Debug.Log("Save");
        save.ActivateAnimation();
    }
}

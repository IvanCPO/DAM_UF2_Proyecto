using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfileAccountController : MonoBehaviour
{
    [SerializeField] Text name;
    [SerializeField] Text money;

    public void SetData(StatusPlayer status){
        name.text = status.GetName();
        money.text = status.GetMoney()+"€";
    }
}

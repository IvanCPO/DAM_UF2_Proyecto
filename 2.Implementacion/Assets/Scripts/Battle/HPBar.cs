using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    [SerializeField] GameObject health;
    [SerializeField] Text hpText;
    

    public void SetHP(Pokemon pokemon){
        var percent = (float)pokemon.HP/pokemon.MaxHP;
        health.transform.localScale = new Vector3(percent,1f);
        hpText.text = $"HP:{pokemon.HP}/{pokemon.MaxHP}";
        if (percent<0.2f)
        {
            health.GetComponent<Image>().color = new Color(186,0,0);
        }else if (percent<0.5f)
        {
            health.GetComponent<Image>().color = Color.yellow;
        }else
            health.GetComponent<Image>().color = Color.green;
    }
}

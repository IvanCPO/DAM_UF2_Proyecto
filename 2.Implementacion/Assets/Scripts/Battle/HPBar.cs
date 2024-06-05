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
        health.transform.localScale = new Vector3((float)pokemon.HP/pokemon.MaxHP,1f);
        hpText.text = $"ExpT= {pokemon.MaxExp}";
    }
}

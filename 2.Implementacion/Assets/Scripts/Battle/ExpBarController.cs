using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpBarController : MonoBehaviour
{
    [SerializeField] GameObject experience;
    public void SetExp(Pokemon pokemon){
                experience.GetComponent<Image>().fillAmount =(float)pokemon.Expirience/pokemon.MaxExp;
    }
}

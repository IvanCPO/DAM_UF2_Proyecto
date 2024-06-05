using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpBarController : MonoBehaviour
{
    [SerializeField] GameObject experience;
    public void SetExp(Pokemon pokemon){
        experience.transform.localScale = new Vector3((float)pokemon.Expirience/pokemon.MaxExp,1f);
    }
}

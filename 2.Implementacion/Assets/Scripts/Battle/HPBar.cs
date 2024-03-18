using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HPBar : MonoBehaviour
{
    [SerializeField] GameObject health;
    

    public void SetHP(float hpNormalized){
        health.transform.localScale = new Vector3(hpNormalized,1f);
    }
}

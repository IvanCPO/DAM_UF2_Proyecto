using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class BadgePictureController : MonoBehaviour
{
    public void AddBadge(){
        GetComponent<Image>().color = new Color(255,255,255);
    }
}

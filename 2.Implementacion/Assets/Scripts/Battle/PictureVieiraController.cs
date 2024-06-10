using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PictureVieiraController : MonoBehaviour
{
    [SerializeField] List<GameObject> pokevieira;
    public void SetData(List<Pokemon> rival){
        for (int i = 0; i < pokevieira.Count; i++)
        {
            if (rival.Count>=(i+1))
            {
                if (rival[i].HP==0)
                {
                    pokevieira[i].GetComponent<Image>().color = Color.black;
                }
            }
            else{
                pokevieira[i].SetActive(false);
            }
        }
    }

    public void ActiveBar(bool active){
        gameObject.SetActive(!active);
    }

}

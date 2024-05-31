using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PictureTypeController : MonoBehaviour
{
    public void UpdatePictureType(PokemonType type){
        gameObject.GetComponent<Image>().sprite = gameObject.GetComponent<PokemonTypeEnum>().GetSpriteType(type);
    }
}

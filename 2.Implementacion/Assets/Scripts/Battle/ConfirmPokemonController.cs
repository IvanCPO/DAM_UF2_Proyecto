using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmPokemonController : MonoBehaviour
{
    [SerializeField] Text name;
    [SerializeField] Image image;


    public void OpenMenu(Pokemon pokemon){
        name.text = pokemon.Base.Name;
        image.sprite = pokemon.Base.FrontSprite;
    }
}

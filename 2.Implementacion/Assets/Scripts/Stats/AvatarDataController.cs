using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvatarDataController : MonoBehaviour, InterfaceData
{
    [SerializeField] PictureBattle picture;
    [SerializeField] Text PokemonName;
    [SerializeField] PictureTypeController type1;
    [SerializeField] PictureTypeController type2;

    public void InsertDataPokemon(Pokemon pokemon){
        PokemonName.text= pokemon.Base.Name;
        picture.Setup(pokemon);
        Debug.Log("Types of this pokemon:{ Type 1= "+pokemon.Base.Type1+", Type 2 = "+pokemon.Base.Type2+" }");
        type1.UpdatePictureType(pokemon.Base.Type1);
        type2.UpdatePictureType(pokemon.Base.Type2);
        picture.gameObject.GetComponent<Image>().color = Color.white;
        type1.gameObject.GetComponent<Image>().color = Color.white;
        type2.gameObject.GetComponent<Image>().color = Color.white;

    }

    public void InsertDataUnknow(Sprite sprite){
        PokemonName.text= "???";
        picture.gameObject.GetComponent<Image>().sprite = sprite;
        picture.gameObject.GetComponent<Image>().color = Color.black;
        type1.gameObject.GetComponent<Image>().color = Color.black;
        type2.gameObject.GetComponent<Image>().color = Color.black;
    }

    public void InsertDataKnow(PokemonBase pokemon){
        PokemonName.text = pokemon.Name;
        picture.Setup(new Pokemon(pokemon,5));
        Debug.Log("Types of this pokemon:{ Type 1= "+pokemon.Type1+", Type 2 = "+pokemon.Type2+" }");
        type1.UpdatePictureType(pokemon.Type1);
        type2.UpdatePictureType(pokemon.Type2);
        picture.gameObject.GetComponent<Image>().color = Color.white;
        type1.gameObject.GetComponent<Image>().color = Color.white;
        type2.gameObject.GetComponent<Image>().color = Color.white;

    }

}

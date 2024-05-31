using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvatarDataController : MonoBehaviour, InterfaceData
{
    [SerializeField] PictureBattle picture;
    [SerializeField] Text name;
    [SerializeField] PictureTypeController type1;
    [SerializeField] PictureTypeController type2;

    public void InsertDataPokemon(Pokemon pokemon){
        name.text= pokemon.Base.Name;
        picture.Setup(pokemon);
        type1.UpdatePictureType(pokemon.Base.Type1);
        type2.UpdatePictureType(pokemon.Base.Type2);
    }
    
}

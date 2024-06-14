using UnityEngine;
using UnityEngine.UI;

public class BaseDataController : MonoBehaviour
{
    [SerializeField] AvatarDataController avatar;
    [SerializeField] Text text;
    [SerializeField] Sprite sprite;

    public void SetDataUnknow(){
        avatar.InsertDataUnknow(sprite);
        text.text = "";
    }

    public void SetDataKnow(PokemonBase pokemonBase){
        avatar.InsertDataKnow(pokemonBase);
        text.text = "";
    }

    public void SetData(Pokemon pokemon){
        avatar.InsertDataPokemon(pokemon);
        text.text = pokemon.Base.Description;
    }

}

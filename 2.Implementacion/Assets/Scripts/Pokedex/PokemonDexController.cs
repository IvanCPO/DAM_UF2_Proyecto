using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class PokemonDexController : MonoBehaviour
{
    [SerializeField] Image vieira;
    [SerializeField] Text pokemonName;
    [SerializeField] GameObject selectedPicture;
    private int typeValor;

    public void IsUnknow(){
        pokemonName.text = "???";
        typeValor = 0;
    }
    
    public void IsMeet(PokemonBase pokemonBase){
        pokemonName.text = pokemonBase.Name;
        gameObject.GetComponent<Image>().color = Color.red;
        typeValor = 1;
    }

    public void IsCapture(){
        vieira.color = Color.white;
        typeValor = 2;
    }

    public void DiSelect(){
        selectedPicture.SetActive(false);
    }

    public int Select(){
        selectedPicture.SetActive(true);
        return typeValor;
    }

}

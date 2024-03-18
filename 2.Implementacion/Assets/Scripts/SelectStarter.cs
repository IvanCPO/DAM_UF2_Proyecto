using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectStarter : MonoBehaviour
{
    [SerializeField] Image firstPokemonImage;
    [SerializeField] Image secondPokemonImage;
    [SerializeField] Image thirdPokemonImage;
    [SerializeField] PokemonBase firstPokemon;
    [SerializeField] PokemonBase secondPokemon;
    [SerializeField] PokemonBase thirdPokemon;
    private StatusPlayer status;
    void Start()
    {
        status = StatusPlayer.getInstance();
        firstPokemonImage.sprite = firstPokemon.FrontSprite;
        secondPokemonImage.sprite = secondPokemon.FrontSprite;
        thirdPokemonImage.sprite = thirdPokemon.FrontSprite;
    }

    public void Choose(int i){
        switch (i)
        {
            case 1:
                status.SavePokemon(new Pokemon(firstPokemon,5));
                break;
            case 2:
                status.SavePokemon(new Pokemon(secondPokemon,5));
                break;
            case 3:
                status.SavePokemon(new Pokemon(thirdPokemon,5));
                break;
        }
        gameObject.SetActive(false);
    }
}
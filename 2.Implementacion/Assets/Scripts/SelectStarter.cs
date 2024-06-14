using UnityEngine;
using UnityEngine.UI;

public class SelectStarter : MonoBehaviour
{
    [SerializeField] Image firstPokemonImage;
    [SerializeField] Image secondPokemonImage;
    [SerializeField] Image thirdPokemonImage;
    private PokemonBase firstPokemon;
    private PokemonBase secondPokemon;
    private PokemonBase thirdPokemon;
    private StatusPlayer status;
    void Start()
    {
        status = StatusPlayer.getInstance();
        firstPokemon = PokemonBase.GetPokemonBase(1);
        secondPokemon = PokemonBase.GetPokemonBase(4);
        thirdPokemon = PokemonBase.GetPokemonBase(7);
        firstPokemonImage.sprite = firstPokemon.FrontSprite;
        secondPokemonImage.sprite = secondPokemon.FrontSprite;
        thirdPokemonImage.sprite = thirdPokemon.FrontSprite;
        status.MeetPokemon(firstPokemon.PokedexID);
        status.MeetPokemon(secondPokemon.PokedexID);
        status.MeetPokemon(thirdPokemon.PokedexID);

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

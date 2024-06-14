using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollContentController : MonoBehaviour
{
    
    [SerializeField] List<PokemonDexController> pokemons; 
    
    public void SetPokemons(StatusPlayer status){
        for (int i = 0; i < pokemons.Count; i++)
        {
            if (!status.GetMeets().Contains(i+1))
                pokemons[i].IsUnknow();
            else
            {
                InsetMeetPokemon(status.myTeam,i);
            }

        }
    }

    private void InsetMeetPokemon(List<Pokemon> my, int i)
    {
        PokemonBase pokemonBase = PokemonBase.GetPokemonBase(i + 1);
        pokemons[i].IsMeet(pokemonBase);
        foreach (Pokemon pokemon in my)
        {
            if (pokemon.Base.PokedexID==(i+1)){
                pokemons[i].IsCapture();
                break;
            }
        }
    }

    public void DiSelect()
    {
        for (int i = 0; i < pokemons.Count; i++)
        {
            pokemons[i].DiSelect();
        }
    }

    public List<PokemonDexController> GetList()
    {
        return pokemons;
    }
}

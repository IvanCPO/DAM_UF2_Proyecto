using System;
using UnityEngine;

[Serializable]
public class RivalController
{
    [SerializeField] int pokedexId;
    [SerializeField] int level;

    public RivalController(int pokedexId, int level)
    {
        this.pokedexId = pokedexId;
        this.level = level;
    }

    public Pokemon GeneratePokemon(){
        return new Pokemon(PokemonBase.GetPokemonBase(pokedexId),level);
    }
}

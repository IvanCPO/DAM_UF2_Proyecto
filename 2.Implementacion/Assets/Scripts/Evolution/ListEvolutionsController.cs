

using System.Collections.Generic;

public class ListEvolutionsController
{
    private static ListEvolutionsController listInstance;

    private List<Pokemon> pokemons;

    private ListEvolutionsController(){
        pokemons = new List<Pokemon>();
    }

    public static ListEvolutionsController GetListInstance(){
        
        if (listInstance==null)
        {
            listInstance = new ListEvolutionsController();
        }
        return listInstance;
    }

    public void AddPokemon(Pokemon pokemon){
        pokemons.Add(pokemon);
    }

    public void RemovePokemon(){
        pokemons.Remove(pokemons[0]);
    }

    public Pokemon GenerateEvolution(){
        Pokemon pokemon = pokemons[0];
        RemovePokemon();
        return new Pokemon(pokemon,PokemonBase.GetPokemonBase(pokemon.Base.evolutionId));
    }

    public List<Pokemon> GetPokemons(){
        return pokemons;
    }
}

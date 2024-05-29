using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonBase : ScriptableObject
{
    private int pokedex_id;
    private string namePokemon;
    private string description;
    private int weight;
    private Sprite frontSprite;
    private Sprite backSprite;
    private PokemonType type1;
    private PokemonType type2;

    private int maxHP;
    private int attack;
    private int defense;
    private int spAttack;
    private int spDefense;
    private int speed;

    private int levelPokemon;
    private int evolutionId;
    private List<LearnableMove> learnableMoves;

    public static PokemonBase GetPokemonBase(int pokedex_id){
        var connection = DDBBConector.GenerateConnection().GetConnection();
        
        string query = "SELECT NAME FROM POKEMON WHERE POKEDEX_ID = "+pokedex_id;
        var name = connection.CreateCommand(query).ExecuteScalar<String>();
        query = "SELECT WEIGHT FROM POKEMON WHERE POKEDEX_ID = "+pokedex_id;
        var weight = connection.CreateCommand(query).ExecuteScalar<int>();
        query = "SELECT DESCRIPTION FROM POKEMON WHERE POKEDEX_ID = "+pokedex_id;
        var description = connection.CreateCommand(query).ExecuteScalar<String>();
        query = "SELECT TYPE_ID FROM POKEMON WHERE POKEDEX_ID = "+pokedex_id;
        var type = connection.CreateCommand(query).ExecuteScalar<int>();
        PokemonType type1 = PokemonTypeEnum.GetPokemonType(type);
        query = "SELECT SECOND_TYPE_ID FROM POKEMON WHERE POKEDEX_ID = "+pokedex_id;
        int secondType;
        try
        {
            secondType = connection.CreateCommand(query).ExecuteScalar<int>();
        }
        catch (System.Exception)
        {
            secondType = 0;
        }
        PokemonType type2 = PokemonTypeEnum.GetPokemonType(secondType);
        query = "SELECT HP FROM POKEMON WHERE POKEDEX_ID = "+pokedex_id;
        var hp = connection.CreateCommand(query).ExecuteScalar<int>();
        query = "SELECT ATTACK FROM POKEMON WHERE POKEDEX_ID = "+pokedex_id;
        var attack = connection.CreateCommand(query).ExecuteScalar<int>();
        query = "SELECT DEFENSE FROM POKEMON WHERE POKEDEX_ID = "+pokedex_id;
        var defense = connection.CreateCommand(query).ExecuteScalar<int>();
        query = "SELECT SP_ATTACK FROM POKEMON WHERE POKEDEX_ID = "+pokedex_id;
        var spAttack = connection.CreateCommand(query).ExecuteScalar<int>();
        query = "SELECT SP_DEFENSE FROM POKEMON WHERE POKEDEX_ID = "+pokedex_id;
        var spDefense = connection.CreateCommand(query).ExecuteScalar<int>();
        query = "SELECT SPEED FROM POKEMON WHERE POKEDEX_ID = "+pokedex_id;
        var speed= connection.CreateCommand(query).ExecuteScalar<int>();
        query = "SELECT SPRITE_FRONT FROM POKEMON WHERE POKEDEX_ID = "+pokedex_id;
        var sprite_Front = connection.CreateCommand(query).ExecuteScalar<byte[]>();
        Debug.Log("The value of pokemon sprite: "+sprite_Front);
        query = "SELECT SPRITE_BACK FROM POKEMON WHERE POKEDEX_ID = "+pokedex_id;
        var sprite_Back = connection.CreateCommand(query).ExecuteScalar<byte[]>();

        PokemonBase pokemon;
        // If is the last form/evolution and don´t have more info
        try
        {
            query = "SELECT LEVEL_EVOLUTION FROM POKEMON WHERE POKEDEX_ID = "+pokedex_id;
            var levelEvolution= connection.CreateCommand(query).ExecuteScalar<int>();
            query = "SELECT EVOLUTION_ID FROM POKEMON WHERE POKEDEX_ID = "+pokedex_id;
            var evolutionId= connection.CreateCommand(query).ExecuteScalar<int>();

            pokemon = new PokemonBase(pokedex_id,name,description,weight,type1,type2,hp,attack,defense,spAttack,spDefense,speed,sprite_Front,sprite_Back,levelEvolution,evolutionId);
            
            // Debug.Log("The value of this pokemon is: "+pokemon.Name);
        }
        catch (System.Exception)
        {
            pokemon = new PokemonBase(pokedex_id,name,description,weight,type1,type2,hp,attack,defense,spAttack,spDefense,speed,sprite_Front,sprite_Back);
            
        }
        return pokemon;
    }
    public PokemonBase(int pokedex_id, string namePokemon, string description, int weight, PokemonType type1, PokemonType type2, int maxHP, int attack, int defense, int spAttack, int spDefense, int speed, byte[] frontSprite, byte[] backSprite, int levelPokemon, int evolutionId){
        this.pokedex_id = pokedex_id;
        this.namePokemon = namePokemon;
        this.description = description;
        this.weight = weight;
        this.type1 = type1;
        this.type2 = type2;
        this.maxHP = maxHP;
        this.attack = attack;
        this.defense = defense;
        this.spAttack = spAttack;
        this.spDefense = spDefense;
        this.speed = speed;
        this.frontSprite = ConvertSprite(frontSprite);
        this.backSprite = ConvertSprite(backSprite);
        this.levelPokemon = levelPokemon;
        this.evolutionId = evolutionId;
    }
    public PokemonBase(int pokedex_id, string namePokemon, string description, int weight, PokemonType type1, PokemonType type2, int maxHP, int attack, int defense, int spAttack, int spDefense, int speed, byte[] frontSprite, byte[] backSprite){
        this.pokedex_id = pokedex_id;
        this.namePokemon = namePokemon;
        this.description = description;
        this.weight = weight;
        this.type1 = type1;
        this.type2 = type2;
        this.maxHP = maxHP;
        this.attack = attack;
        this.defense = defense;
        this.spAttack = spAttack;
        this.spDefense = spDefense;
        this.speed = speed;
        this.frontSprite = ConvertSprite(frontSprite);
        this.backSprite = ConvertSprite(backSprite);
    }
    
    private Sprite ConvertSprite(byte[] picture){
        var tex = new Texture2D(1,1);
        tex.LoadImage(picture);
        return Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(tex.width/2, tex.height/2));
    }

    public int PokedexID {
        get{ return pokedex_id;}
    }
    public string Name {
        get{ return namePokemon;}
    }
    public string Description {
        get{ return description;}
    }
    public int Weight {
        get{ return weight;}
    }
    public Sprite FrontSprite {
        get{ return frontSprite;}
    }
    public Sprite BackSprite {
        get{ return backSprite;}
    }
    public PokemonType Type1 {
        get{ return type1;}
    }
    public PokemonType Type2 {
        get{ return type2;}
    }
    public int MaxHP {
        get{ return maxHP;}
    }
    public int Attack {
        get{ return attack;}
    }
    public int SpAttack {
        get{ return spAttack;}
    }
    public int Defense {
        get{ return defense;}
    }
    public int SpDefense {
        get{ return spDefense;}
    }
    public int Speed {
        get{ return speed;}
    }
    public List<LearnableMove> LearnableMoves{
        get{ return learnableMoves; }
    }
}

[System.Serializable]
public class LearnableMove{

    [SerializeField] MoveBase moveBase;
    [SerializeField] int level;
    
    
    public MoveBase Base{
        get{ return moveBase;}
    }
    public int Level{
        get{ return level;}
    }
}

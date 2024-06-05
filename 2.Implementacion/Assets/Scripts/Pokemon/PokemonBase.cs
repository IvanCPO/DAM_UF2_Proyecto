using System;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;




// public class PokemonBase : ScriptableObject
public class PokemonBase
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
        connection.Open();
        string query;
        string name;
        int weight;
        string description;
        int type;
        int hp;
        int attack;
        int defense;
        int spAttack;
        int spDefense;
        int speed;
        byte[] spriteFront;
        byte[] spriteBack;

        IDbCommand command = connection.CreateCommand();
        
        query = "SELECT NAME, WEIGHT, DESCRIPTION, TYPE_ID, HP, ATTACK, DEFENSE, SP_ATTACK, SP_DEFENSE, SPEED, SPRITE_FRONT, SPRITE_BACK FROM POKEMON WHERE POKEDEX_ID = "+pokedex_id;
        command.CommandText = query;
        using (IDataReader reader = command.ExecuteReader())
            {
                reader.Read();
                name = reader.GetString(0);
                weight = reader.GetInt32(1);
                description = reader.GetString(2);
                type = reader.GetInt32(3);
                hp = reader.GetInt32(4);
                attack = reader.GetInt32(5);
                defense = reader.GetInt32(6);
                spAttack = reader.GetInt32(7);
                spDefense = reader.GetInt32(8);
                speed = reader.GetInt32(9);
                spriteFront = (byte[])reader.GetValue(10);
                spriteBack = (byte[])reader.GetValue(11);
                reader.Close();
            }
        int secondType;
        try
        {
            secondType = ExecuteScalarInt(command, query);
        }
        catch (Exception)
        {
            secondType = 0;
        }
        PokemonType type1 = PokemonTypeEnum.GetPokemonType(type);
        PokemonType type2 = PokemonTypeEnum.GetPokemonType(secondType);

        PokemonBase pokemon;
        try
        {
            query = "SELECT LEVEL_EVOLUTION FROM POKEMON WHERE POKEDEX_ID = "+pokedex_id;
            int levelEvolution = ExecuteScalarInt(command, query);

            query = "SELECT EVOLUTION_ID FROM POKEMON WHERE POKEDEX_ID = "+pokedex_id;
            int evolutionId = ExecuteScalarInt(command, query);

            pokemon = new PokemonBase(pokedex_id, name, description, weight, type1, type2, hp, attack, defense, spAttack, spDefense, speed, spriteFront, spriteBack, levelEvolution, evolutionId);
        }
        catch (Exception)
        {
            pokemon = new PokemonBase(pokedex_id, name, description, weight, type1, type2, hp, attack, defense, spAttack, spDefense, speed, spriteFront, spriteBack);
        }
        
        query = "SELECT MOVE_ID, LEVEL_UP FROM MOVELEARNER WHERE POKEMON_ID = "+pokedex_id;
        command.CommandText = query;
        pokemon.learnableMoves = GetLearnables(command);
        connection.Close();
        return pokemon;
    }

    private static int ExecuteScalarInt(IDbCommand command, string query)
    {
        command.CommandText = query;
        using (IDataReader reader = command.ExecuteReader())
        {
            reader.Read();
            int value = reader.GetInt32(0);
            reader.Close();
            return value;
        }
    }

    private static List<LearnableMove> GetLearnables(IDbCommand command){

        List<LearnableMove> moves= new List<LearnableMove>();
        // Crear un comando a partir de la consulta
        using (IDataReader reader = command.ExecuteReader())
        {
            while(reader.Read()){
                int idMove = reader.GetInt32(0);
                int level = reader.GetInt32(1);
                moves.Add(new LearnableMove(MoveBase.GetMoveBase(idMove),level));
            }
            reader.Close();
        }
        return moves;
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
        learnableMoves = new List<LearnableMove>();
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
        learnableMoves = new List<LearnableMove>();
    }
    
    private Sprite ConvertSprite(byte[] picture){
        var tex = new Texture2D(200,200);
        tex.LoadImage(picture);
        return Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(tex.width/2, tex.height/2));
    }

    public void AddMoveBase(LearnableMove move){
        this.learnableMoves.Add(move);
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
    
    public LearnableMove(MoveBase moveBase, int level){
        this.moveBase = moveBase;
        this.level = level;
    }

    public MoveBase Base{
        get{ return moveBase;}
    }
    public int Level{
        get{ return level;}
    }
}

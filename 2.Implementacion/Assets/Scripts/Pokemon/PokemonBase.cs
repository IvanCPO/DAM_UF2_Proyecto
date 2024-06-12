using System;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;



[Serializable]
public class PokemonBase
{

    public int pokedex_id;
    public string namePokemon;
    public string description;
    public int weight;
    public PokemonType type1;
    public PokemonType type2;
    public int maxHP;
    public int attack;
    public int defense;
    public int spAttack;
    public int spDefense;
    public int speed;
    public int levelPokemon;
    public int evolutionId;
    public int expBase;
    public int capture_rate;
    public List<LearnableMove> learnableMoves;



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
        int expBase;
        int capture_rate;

        IDbCommand command = connection.CreateCommand();
        
        query = "SELECT NAME, WEIGHT, DESCRIPTION, TYPE_ID, HP, ATTACK, DEFENSE, SP_ATTACK, SP_DEFENSE, SPEED, BASE_EXPERIENCE, CAPTURE_RATE FROM POKEMON WHERE POKEDEX_ID = "+pokedex_id;
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
                expBase = reader.GetInt32(10);
                capture_rate = reader.GetInt32(11);
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

            pokemon = new PokemonBase(pokedex_id, name, description, weight, type1, type2, hp, attack, defense, spAttack, spDefense, speed, expBase, levelEvolution, evolutionId, capture_rate);
        }
        catch (Exception)
        {
            pokemon = new PokemonBase(pokedex_id, name, description, weight, type1, type2, hp, attack, defense, spAttack, spDefense, speed, expBase, capture_rate);
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
    public PokemonBase(int pokedex_id, string namePokemon, string description, int weight, PokemonType type1, PokemonType type2, int maxHP, int attack, int defense, int spAttack, int spDefense, int speed, int expBase, int levelPokemon, int evolutionId, int capture_rate){
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
        this.levelPokemon = levelPokemon;
        this.evolutionId = evolutionId;
        // Cambiar cuando implemente la informacion de la experiencia base
        this.expBase = expBase;
        learnableMoves = new List<LearnableMove>();
        this.capture_rate = capture_rate;
    }
    public PokemonBase(int pokedex_id, string namePokemon, string description, int weight, PokemonType type1, PokemonType type2, int maxHP, int attack, int defense, int spAttack, int spDefense, int speed, int expBase, int capture_rate){
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
        learnableMoves = new List<LearnableMove>();
        this.expBase = expBase;
        this.capture_rate = capture_rate;
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
        get{
            var connection = DDBBConector.GenerateConnection().GetConnection();
            connection.Open();
            byte[] spriteFront;
            IDbCommand command = connection.CreateCommand();
            
            string query = "SELECT SPRITE_FRONT FROM POKEMON WHERE POKEDEX_ID = "+pokedex_id;
            command.CommandText = query;
            using (IDataReader reader = command.ExecuteReader())
            {
                reader.Read();
                
                spriteFront = (byte[])reader.GetValue(0);
                reader.Close();
            }
            
            
             return ConvertSprite(spriteFront);}
    }
    public Sprite BackSprite {
        get{
            var connection = DDBBConector.GenerateConnection().GetConnection();
            connection.Open();
            byte[] spriteBack;

            IDbCommand command = connection.CreateCommand();
            
            string query = "SELECT SPRITE_BACK FROM POKEMON WHERE POKEDEX_ID = "+pokedex_id;
            command.CommandText = query;
            using (IDataReader reader = command.ExecuteReader())
            {
                reader.Read();
                spriteBack = (byte[])reader.GetValue(0);
                reader.Close();
            }
            
            
             return ConvertSprite(spriteBack);}
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

    public int ExpBase {
        get{ return speed;}
    }
    
    public int CaptureRate {
        get{ return capture_rate;}
    }
}

[Serializable]
public class LearnableMove{

    public MoveBase moveBase;
    public int level;
    
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

using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
using System.Data.Common;
using Mono.Data.Sqlite;



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
        connection.Open();
        string query;
        
        query = "SELECT NAME FROM POKEMON WHERE POKEDEX_ID = @pokedex_id";
        var name = ExecuteScalar<string>(connection, query, pokedex_id);

        query = "SELECT WEIGHT FROM POKEMON WHERE POKEDEX_ID = @pokedex_id";
        var weight = ExecuteScalar<int>(connection, query, pokedex_id);

        query = "SELECT DESCRIPTION FROM POKEMON WHERE POKEDEX_ID = @pokedex_id";
        var description = ExecuteScalar<string>(connection, query, pokedex_id);

        query = "SELECT TYPE_ID FROM POKEMON WHERE POKEDEX_ID = @pokedex_id";
        var type = ExecuteScalar<int>(connection, query, pokedex_id);
        PokemonType type1 = PokemonTypeEnum.GetPokemonType(type);

        query = "SELECT SECOND_TYPE_ID FROM POKEMON WHERE POKEDEX_ID = @pokedex_id";
        int secondType;
        try
        {
            secondType = ExecuteScalar<int>(connection, query, pokedex_id);
        }
        catch (Exception)
        {
            secondType = 0;
        }
        PokemonType type2 = PokemonTypeEnum.GetPokemonType(secondType);

        query = "SELECT HP FROM POKEMON WHERE POKEDEX_ID = @pokedex_id";
        var hp = ExecuteScalar<int>(connection, query, pokedex_id);

        query = "SELECT ATTACK FROM POKEMON WHERE POKEDEX_ID = @pokedex_id";
        var attack = ExecuteScalar<int>(connection, query, pokedex_id);

        query = "SELECT DEFENSE FROM POKEMON WHERE POKEDEX_ID = @pokedex_id";
        var defense = ExecuteScalar<int>(connection, query, pokedex_id);

        query = "SELECT SP_ATTACK FROM POKEMON WHERE POKEDEX_ID = @pokedex_id";
        var spAttack = ExecuteScalar<int>(connection, query, pokedex_id);

        query = "SELECT SP_DEFENSE FROM POKEMON WHERE POKEDEX_ID = @pokedex_id";
        var spDefense = ExecuteScalar<int>(connection, query, pokedex_id);

        query = "SELECT SPEED FROM POKEMON WHERE POKEDEX_ID = @pokedex_id";
        var speed = ExecuteScalar<int>(connection, query, pokedex_id);

        query = "SELECT SPRITE_FRONT FROM POKEMON WHERE POKEDEX_ID = @pokedex_id";
        var spriteFront = ExecuteScalar<byte[]>(connection, query, pokedex_id);

        query = "SELECT SPRITE_BACK FROM POKEMON WHERE POKEDEX_ID = @pokedex_id";
        var spriteBack = ExecuteScalar<byte[]>(connection, query, pokedex_id);

        PokemonBase pokemon;
        try
        {
            query = "SELECT LEVEL_EVOLUTION FROM POKEMON WHERE POKEDEX_ID = @pokedex_id";
            var levelEvolution = ExecuteScalar<int>(connection, query, pokedex_id);

            query = "SELECT EVOLUTION_ID FROM POKEMON WHERE POKEDEX_ID = @pokedex_id";
            var evolutionId = ExecuteScalar<int>(connection, query, pokedex_id);

            pokemon = new PokemonBase(pokedex_id, name, description, weight, type1, type2, hp, attack, defense, spAttack, spDefense, speed, spriteFront, spriteBack, levelEvolution, evolutionId);
        }
        catch (Exception)
        {
            pokemon = new PokemonBase(pokedex_id, name, description, weight, type1, type2, hp, attack, defense, spAttack, spDefense, speed, spriteFront, spriteBack);
        }
        connection.Close();
        return pokemon;
    }

    private static T ExecuteScalar<T>(SqliteConnection connection, string query, int pokedex_id)
    {

        using (var command = new SqliteCommand(query, connection))
        {
            command.Parameters.AddWithValue("@pokedex_id", pokedex_id);
            object result = command.ExecuteScalar();
            return (result == DBNull.Value) ? default(T) : (T)result;
        }
    }

    // public static List<LearnableMove> GetLearnables(int pokedex_id, SqliteConnection connection){
    //     // String query = "SELECT TOP 1 LEVEL_UP FROM MOVELEARNER WHERE POKEMON_ID="+pokedex_id;
    //     // int level = connection.CreateCommand(query).ExecuteScalar<int>();
    //     // Debug.Log("EL POKEMON "+pokedex_id+" tiene el movimiento al nivel = "+level);

    //     // String query = "SELECT LEVEL_UP FROM MOVELEARNER WHERE POKEMON_ID="+pokedex_id;
    //     // List<int> move = connection.CreateCommand(query).ExecuteQuery<int>();
    //     // Debug.Log("El ancho de la lista de movimientos de "+pokedex_id+" es de : "+move.Count);
    //     // for (int i = 0; i < move.Count; i++)
    //     // {
    //     //     Debug.Log("EL POKEMON "+pokedex_id+" tiene el movimiento al nivel = "+move[i]);
    //     // }
    //     // return null;

    //     string query = "SELECT LEVEL_UP FROM MOVELEARNER WHERE POKEMON_ID = @pokedex_id";
        
    //     // Crear un comando a partir de la consulta
    //     using (var command = new SqliteCommand(query, connection))
    //     {
    //         // Añadir el parámetro a la consulta para evitar inyección SQL
    //         command.Parameters.AddWithValue("@pokedex_id", pokedex_id);
            
    //         // Crear una lista para almacenar los movimientos aprendibles
    //         List<LearnableMove> learnableMoves = new List<LearnableMove>();
            
    //         // Ejecutar la consulta y recuperar los resultados
    //         using (var reader = command.ExecuteReader())
    //         {
    //             // Recorrer los resultados de la consulta
    //             while (reader.Read())
    //             {
    //                 // Obtener el nivel del movimiento desde el resultado actual
    //                 int levelUp = reader.GetInt32(0); // Suponiendo que el nivel está en la primera columna
                    
    //                 // Crear un nuevo LearnableMove y añadirlo a la lista
    //                 LearnableMove move = new LearnableMove
    //                 {
    //                     Level = levelUp
    //                     // Asignar otros campos según sea necesario
    //                 };
                    
    //                 learnableMoves.Add(move);
                    
    //                 // Debug para verificar los valores
    //                 Debug.Log("EL POKEMON " + pokedex_id + " tiene el movimiento al nivel = " + levelUp);
    //             }
    //         }
            
    //         // Mostrar la cantidad de movimientos encontrados
    //         Debug.Log("El ancho de la lista de movimientos de " + pokedex_id + " es de : " + learnableMoves.Count);
            
    //         // Devolver la lista de movimientos aprendibles
    //         return learnableMoves;
    //     }
    // }
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
    
    
    public MoveBase Base{
        get{ return moveBase;}
    }
    public int Level{
        get{ return level;}
    }
}

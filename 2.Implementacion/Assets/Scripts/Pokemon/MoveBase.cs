using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
// [CreateAssetMenu (fileName = "Move", menuName = "Pokemon/Create new move")]
// public class MoveBase : ScriptableObject
public class MoveBase
{
    [SerializeField] string name;
    [SerializeField] string description;
    [SerializeField] PokemonType type;
    [SerializeField] int power;
    [SerializeField] int accuracy;
    [SerializeField] int pp;
    ClassDamage classDamage;

    public static MoveBase GetMoveBase(int move_id){
        var connection = DDBBConector.GenerateConnection().GetConnection();
        connection.Open();
        string name;
        string description;
        int type;
        int power;
        int accuracy;
        int pp;
        int classDamage;

        IDbCommand command = connection.CreateCommand();
        
        string query = "SELECT NAME, DESCRIPTION, TYPE_ID, POWER, ACCURACY, PP, CLASSDAMAGE_ID FROM MOVE WHERE MOVE_ID = "+move_id;
        command.CommandText = query;
        using (IDataReader reader = command.ExecuteReader())
            {
                reader.Read();
                name = reader.GetString(0);
                description = reader.GetString(1);
                type = reader.GetInt32(2);
                power = reader.GetInt32(3);
                accuracy = reader.GetInt32(4);
                pp = reader.GetInt32(5);
                classDamage = reader.GetInt32(6);
                reader.Close();
            }
        
        return new MoveBase(name,description,PokemonTypeEnum.GetPokemonType(type),power,accuracy,pp,classDamage);
    }

    public MoveBase (string name, string description, PokemonType type, int power, int accuracy, int pp, int classDamage){
        this.name = name;
        this.description = description;
        this.type = type;
        this.power = power;
        this.accuracy = accuracy;
        this.pp = pp;
        this.classDamage = ClassDamageEnum.GetClassDamage(classDamage);
    }
    
    public string Name{
        get{ return name; }
    }

    public string Description{
        get{ return description; }
    }

    public PokemonType Type{
        get{ return type; }
    }

    public int Power{
        get{ return power; }
    }

    public int Accuracy{
        get{ return accuracy; }
    }

    public int PP{
        get{ return pp; }
    }
    
    public ClassDamage GetClassDamage{
        get{ return classDamage; }
    }

}

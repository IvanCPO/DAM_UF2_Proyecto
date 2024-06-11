using System;
using System.Data;
using UnityEngine;


[Serializable]
public class MoveBase
{
    public string name;
    public string description;
    public PokemonType type;
    public int power;
    public int accuracy;
    public int pp;
    public Efect efect;
    public int chance_efect;
    public ClassDamage classDamage;

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
        int efect;
        int chance_efect;

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
                try
                {
                    efect = reader.GetInt32(7);
                    chance_efect = reader.GetInt32(8);
                }
                catch (Exception)
                {
                    efect = 0;
                    chance_efect = 0;
                }
                reader.Close();
            }
        
        return new MoveBase(name,description,PokemonTypeEnum.GetPokemonType(type),power,accuracy,pp,classDamage,efect,chance_efect);
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

    public MoveBase (string name, string description, PokemonType type, int power, int accuracy, int pp, int classDamage, int efect, int chance_efect){
        this.name = name;
        this.description = description;
        this.type = type;
        this.power = power;
        this.accuracy = accuracy;
        this.pp = pp;
        this.classDamage = ClassDamageEnum.GetClassDamage(classDamage);
        this.efect = EfectEnum.GetEfect(efect);
        this.chance_efect = chance_efect;
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
    
    public Efect GetEfect{
        get{ return efect; }
    }
    
    public int Chance_Efect{
        get{ return chance_efect; }
    }

}

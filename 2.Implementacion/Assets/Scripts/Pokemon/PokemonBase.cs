using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonBase : ScriptableObject
{
    private int pokedex_id;
    private string name;
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
    private List<LearnableMove> learnableMoves;

    public PokemonBase(int pokedex_id, string name, string description, int weight, PokemonType type1, PokemonType type2, int maxHP, int attack, int defense, int spAttack, int spDefense, int speed, byte[] frontSprite, byte[] backSprite){
        this.pokedex_id = pokedex_id;
        this.name = name;
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
        get{ return name;}
    }
    public string Description {
        get{ return name;}
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

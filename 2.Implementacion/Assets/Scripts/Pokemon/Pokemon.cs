using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pokemon
{
    public PokemonBase Base{get;set;}
    public int Level{get;set;}
    public int HP { get; set;}
    public List<Move> Moves { get; set;}
    private System.Random random;
    private int IVhp;
    private int IVattack;
    private int IVdefense;
    private int IVSpA;
    private int IVSpD;
    private int IVspeed;
    private int MaxExp;
    private int Exp;


    public Pokemon (PokemonBase pokemon, int level){
        Base=pokemon;
        this.Level = level;
        HP = MaxHP;
        Moves = new List<Move>();
        random = new System.Random();

        this.MaxExp = CalcExp();
        this.Exp = 0;

        // Spawn pokemon
        foreach (var move in Base.LearnableMoves)
        {

            if (move.Level <= level)
            {
                if (Moves.Count==4)
                {
                    LearnerMove(move.Base);
                }else
                    Moves.Add(new Move(move.Base));
            }

        }

        IVhp = GenerateIV();
        IVattack = GenerateIV();
        IVdefense = GenerateIV();
        IVSpA = GenerateIV();
        IVSpD = GenerateIV();
        IVspeed = GenerateIV();

    }

    private int CalcExp(){
        var num = (Level+1) ^ 2 * 100;
        return num;
    }

    private void LearnerMove(MoveBase move){
        if (random.Next(3)==0)
        {
            Moves[random.Next(4)] = new Move(move);
        }
    }

    private int GenerateIV(){
        return random.Next(32);
    }


    public int MaxHP {
        get{ return Mathf.FloorToInt((Base.MaxHP+IVhp) * (Level/100f) )+Level+10; }
    }
    public int Attack {
        get{ return Mathf.FloorToInt((Base.Attack+IVattack) * (Level/100f) )+5; }
    }
    public int SpAttack {
        get{ return Mathf.FloorToInt((Base.SpDefense+IVSpA) * (Level/100f) )+5; }
    }
    public int Defense {
        get{ return Mathf.FloorToInt((Base.Defense+IVdefense) * (Level/100f) )+5; }
    }
    public int SpDefense {
        get{ return Mathf.FloorToInt((Base.SpDefense+IVSpD) * (Level/100f) )+5; }
    }
    public int Speed {
        get{ return Mathf.FloorToInt((Base.Speed+IVspeed) * (Level/100f) )+5; }
    }

    public int IVHP{
        get{ return IVhp; }
    }
    public int IVAttack{
        get{ return IVattack; }
    }
    public int IVDefense{
        get{ return IVdefense; }
    }
    public int IVSpAttack{
        get{ return IVSpA; }
    }
    public int IVSpDefense{
        get{ return IVSpD; }
    }
    public int IVSpeed{
        get{ return IVspeed; }
    }


    public void Recuperate(){
        HP = MaxHP;
        foreach (Move move in Moves)
        {
            move.PP = move.MaxPP;
        }
    }


    public bool LevelUp(int experience){
        Exp+=experience;
        if (Exp>=MaxExp)
        {
            Level++;
            return true;
        }
        return false;
    }
}

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
    private int Exp;
    private Efect ailment;


    public Pokemon (PokemonBase pokemon, int level){

        random = new System.Random();
        Exp=0;
        Base=pokemon;
        this.Level = level;
        ailment = Efect.NONE;
        
        //Generate IVs
        IVhp = GenerateIV();
        IVattack = GenerateIV();
        IVdefense = GenerateIV();
        IVSpA = GenerateIV();
        IVSpD = GenerateIV();
        IVspeed = GenerateIV();

        HP = MaxHP;
        Moves = new List<Move>();

        // Spawn pokemon
        if (Base.LearnableMoves!=null)
        {
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
        }
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
    public int MaxExp {
        get{ return Convert.ToInt32((Base.ExpBase+Level)/5 * Math.Pow((2*Level+10)/(Level+10.0),2.0)*5+1); }
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
    public Efect Ailment{
        get{ return ailment; }
    }


    public void Recuperate(){
        HP = MaxHP;
        ailment = Efect.NONE;
        foreach (Move move in Moves)
        {
            move.PP = move.MaxPP;
        }
    }


    public int Expirience{
        get{return Exp;}
    }
    public bool LevelUp(int experience){
        Exp+=experience;
        if (Exp>=MaxExp)
        {
            if (Exp>MaxExp)
            {
                Exp = Exp-MaxExp;
            }
            Level++;
            
            return true;
        }
        return false;
    }

    public void addMove(MoveBase move){
        Moves.Add(new Move(move));
    }

    public void setEfectAttack(Efect efect){
        this.ailment = efect;
    }
}

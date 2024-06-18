using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Pokemon
{
    public PokemonBase Base;
    public int Level;
    public int HP;
    public List<Move> Moves;
    private System.Random random;
    public int IVhp;
    public int IVattack;
    public int IVdefense;
    public int IVSpA;
    public int IVSpD;
    public int IVspeed;
    public int Exp;
    public Efect ailment;


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
    public Pokemon (Pokemon preEvolution, PokemonBase pokemon){

        random = new System.Random();
        Exp=preEvolution.Exp;
        Base=pokemon;
        this.Level = preEvolution.Level;
        ailment = Efect.NONE;
        
        //Generate IVs
        IVhp = preEvolution.IVhp;
        IVattack = preEvolution.IVattack;
        IVdefense = preEvolution.IVdefense;
        IVSpA = preEvolution.IVSpA;
        IVSpD = preEvolution.IVSpD;
        IVspeed = preEvolution.IVspeed;

        HP = Ajust(preEvolution);
        Moves = preEvolution.Moves;
        // if (Base.LearnableMoves!=null)
        // {
        //     foreach (var move in Base.LearnableMoves)
        //     {

        //         if (move.Level <= Level)
        //         {
        //             if (Moves.Count==4)
        //             {
        //                 LearnerMove(move.Base);
        //             }else
        //                 Moves.Add(new Move(move.Base));
        //         }

        //     }
        // }
    }

    private int Ajust(Pokemon preEvolution)
    {
        int sum = MaxHP;
        sum -= preEvolution.MaxHP;
        sum += preEvolution.HP;
        return sum;
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
        var sum = this.MaxHP;
        Exp+=experience;
        if (Exp>=MaxExp)
        {
            if (Exp>MaxExp)
            {
                Exp = Exp-MaxExp;
            }
            Level++;
            sum-=this.MaxHP;
            this.HP -=sum;
            
            return true;
        }
        return false;
    }
    public MoveBase isLearning(){
        MoveBase newMove = null;
        // Debug.Log("The level of the pokemon is " + Level);
        foreach (var move in Base.LearnableMoves)
        {
            
            if (move.Level == this.Level)
            {
                newMove=move.Base;
            }
            
        }
        return newMove;
    }
    public bool LearnAlone(MoveBase move){
        if (Moves.Count<4)
        {
            addMove(move);
            return true;
        }
        return false;
    }

    public void addMove(MoveBase move){
        Moves.Add(new Move(move));
    }


    public void ChangeMove(Move move, int index){
        Moves[index]= move;
    }

    public void setEfectAttack(Efect efect){
        this.ailment = efect;
    }
}

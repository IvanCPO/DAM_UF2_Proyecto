using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitsController
{
    private static HitsController instance;

    public Pokemon Player{get;set;}
    public Pokemon Rival{get;set;}
    private Move moveRival;
    public Move MovePlayer{get;set;}

    private HitsController(){

    }

    public static HitsController GetInstance(){
        if (instance == null)
        {
            instance = new HitsController();
        }

        return instance;
    }

    public Move GetMoveRival(){
        return moveRival;
    }
    public Pokemon HitRival(){
        Player.HP-=Hit(Rival,moveRival,Player);
        if (Player.HP<0)
        {
            Player.HP=0;
        }
        return Player;
    }

    public Pokemon HitPlayer(){
        Rival.HP-=Hit(Player,MovePlayer,Rival);
        if (Rival.HP<0)
        {
            Rival.HP=0;
        }
        return Player;
    }

    public void clearGame(){
        Player = null;
        Rival = null;
        MovePlayer = null;
        moveRival = null;
    }

    public Move GenerateMoveRandom(){
        int num = Random.Range(0,Rival.Moves.Count-1);
        moveRival = Rival.Moves[num];
        return moveRival;
    }

    private int Hit(Pokemon kicker, Move m, Pokemon enemy){
        int res = (int)(((2*kicker.Level/5+2)* 1 * kicker.Attack/enemy.Defense)* m.Base.Power / 50 * 1 + 2 * Stab(kicker,m) * GetValueRandom()* Critical());
        return res;
    }

    private int Critical()
    {
        if (Random.Range(1,20)<6)
        {
            return 2;
        }
        return 1;
    }

    private float GetValueRandom()
    {
        return (int)(Random.Range(75,100)) /100f;
    }

    private float Stab(Pokemon kicker, Move m)
    {
        if (kicker.Base.Type1==m.Base.Type || kicker.Base.Type2==m.Base.Type)
        {
            return 1.5f;
        }
        return 1f;
    }
}
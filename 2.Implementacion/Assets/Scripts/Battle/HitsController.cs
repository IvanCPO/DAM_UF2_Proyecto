
using System.Collections.Generic;
using UnityEngine;

public class HitsController
{
    private static HitsController instance;

    public Pokemon Player{get;set;}
    public Pokemon Rival{get;set;}
    private Move moveRival;
    public Move MovePlayer{get;set;}
    private int countEscape;
    private int countCapMoves;
    private List<int> intento;

    private HitsController(){
        countEscape = 1;
        countCapMoves = 0;
        intento = new List<int>();
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
        foreach (Move move in Rival.Moves)
        {
            if (move.Base.Equals(moveRival.Base))
            {
                move.PP--;
                break;
            }
        }
        Player.HP-=Hit(Rival,moveRival,Player);
        if (Player.HP<0)
        {
            Player.HP=0;
        }
        return Player;
    }

    public Pokemon HitPlayer(){
        foreach (Move move in Player.Moves)
        {
            if (move.Base.Equals(MovePlayer.Base))
            {
                move.PP--;
                break;
            }
        }
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
        countEscape = 1;
        countCapMoves = 0;
    }

    public Move GenerateMoveRandom(){
        int num = Random.Range(0,Rival.Moves.Count-1);
        moveRival = Rival.Moves[num];
        return moveRival;
    }

    private int Hit(Pokemon kicker, Move m, Pokemon enemy){
        int res = (int)((2*kicker.Level/5+2)* 1 * kicker.Attack/enemy.Defense* m.Base.Power / 50 * 1 + 2 * Stab(kicker,m) * Eficaz(m,enemy) * GetValueRandom() * Critical());
        return res;
    }

    private float Eficaz(Move m, Pokemon enemy)
    {
        float efectividad = 1.0f;

        if (TableTypeController.efectivos.TryGetValue((m.Base.Type, enemy.Base.Type1), out double valorPrimario))
        {
            efectividad *= (float)valorPrimario;
        }

        if (enemy.Base.Type2 == PokemonType.None && TableTypeController.efectivos.TryGetValue((m.Base.Type, enemy.Base.Type2), out double valorSecundario))
        {
            efectividad *= (float)valorSecundario;
        }
        return efectividad;
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

    public void TryCap(){
        countCapMoves = 0;
        var x = ((3*Rival.MaxHP)-(2*Rival.HP))*Rival.Base.CaptureRate*1/(3*Rival.MaxHP);
        Debug.Log("Variable x = "+x);
        int y = (int)(1048560/System.Math.Sqrt( System.Math.Sqrt(16711680/x)));
        intento.Add(Random.Range(0,65535));
        intento.Add(Random.Range(0,65535));
        intento.Add(Random.Range(0,65535));
        intento.Add(Random.Range(0,65535));
        intento.Sort();
        foreach (int capture in intento)
        {
            Debug.Log("El exito de captura es = "+y+" || El intento = "+capture);
            if (capture<=y)
            {
                countCapMoves++;
            }
        }
        intento = new List<int>();
    }

    public int GetCountMoveBall(){
        return countCapMoves;
    }

    public bool TryEscape(){
        var p = Player.Speed*32/Rival.Speed+countEscape*30;
        int r = Random.Range(0,255);
        Debug.Log("El numero generado es igual a "+p+" y el random es "+r);
        return p > r;
    }

    public void IncreaseTry(){
        countEscape++;
    }
}

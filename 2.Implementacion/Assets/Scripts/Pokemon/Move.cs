using System;

[Serializable]
public class Move
{
    public MoveBase Base;
    public int PP;
    public int MaxPP;

    public Move( MoveBase moveBase){
        Base = moveBase;
        PP = moveBase.PP;
        MaxPP = PP;
    }
    public void UseMove(){
        PP-=1;
    }
}

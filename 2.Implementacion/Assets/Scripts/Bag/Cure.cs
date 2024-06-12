using System;

[Serializable]
public class Cure : Item
{
    public int recHP;
    public int recPP;
    public Cure(int id, string itemName, string itemDescription, int recHP, int recPP) : base(id, itemName, itemDescription)
    {
        this.recHP = recHP;
        this.recPP = recPP;
    }

    public int GetRecHP(){ return recHP; }
    public int GetRecPP(){ return recPP;}

}

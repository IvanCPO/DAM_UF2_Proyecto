using System;

[Serializable]
public class Ball : Item
{
    public int capacityBall;
    public Ball(int id, string itemName, string itemDescription, int capacityBall) : base(id, itemName, itemDescription)
    {
        this.capacityBall = capacityBall;
    }
}

using System.Collections.Generic;
using System;

[Serializable]
public class Bag
{
    public List<Cure> cure;
    public List<Ball> balls;
    public Bag(){
        cure = new List<Cure>();
        balls = new List<Ball>();
    }
    
}

using System;
using UnityEngine;
[Serializable]
public class Ubication
{
    public Vector3 Ubica{get; set;}
    public string Layout{get; set;}
    public int SceneId{get; set;}

    public Ubication()
    {
    }

    public Ubication(Vector3 ubication, string layout, int sceneId)
    {
        this.Ubica = ubication;
        this.Layout = layout;
        this.SceneId = sceneId;
    }
    
}

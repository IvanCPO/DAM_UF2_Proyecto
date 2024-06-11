
using UnityEngine;

[System.Serializable]
public class Ubication
{
    public Vector3 Ubica;
    public string Layout;
    public int SceneId;

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

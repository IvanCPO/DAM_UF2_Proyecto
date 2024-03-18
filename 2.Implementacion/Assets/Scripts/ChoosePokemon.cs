using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoosePokemon : MonoBehaviour
{
    [SerializeField] GameObject choosePokemon;
    private StatusPlayer status;
    void Start()
    {
        status = StatusPlayer.getInstance();
    }

    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.CompareTag("Player"))
        {
            if (status.GetTeam().Count==0)
            {
                Invoke("StopPlayer", 0.5f);
                choosePokemon.SetActive(true);
            }
        }
    }
}

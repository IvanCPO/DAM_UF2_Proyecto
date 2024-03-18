using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractiveNPCController : MonoBehaviour
{
    [SerializeField] String name;
    [TextArea]
    [SerializeField] List<String> messages;

    private CreateDialogController dialog;
    
    void Start()
    {
        GameObject canvas = GameObject.FindGameObjectWithTag("Canvas");
        dialog = canvas.GetComponent<CreateDialogController>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Invoke("StopPlayer", 0.5f);
            dialog.SetDialogs(name,messages);
        }
    }

    private void StopPlayer () {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().ChangeMove();
    }

}
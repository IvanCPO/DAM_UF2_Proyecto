using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObtainItemController : MonoBehaviour
{
    [SerializeField] int id;
    [SerializeField] string item;
    [SerializeField] int cantItem;
    private CreateDialogController dialog;

    void Start()
    {
        if (StatusPlayer.getInstance().idItemRecolected.Contains(id))
        {
            gameObject.SetActive(false);
        }
        GameObject canvas = GameObject.FindGameObjectWithTag("Canvas");
        dialog = canvas.GetComponent<CreateDialogController>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StatusPlayer.getInstance().AddItem(id,item,cantItem);
            List<string> list = new List<string>();
            list.Add("Acabas de encontrar un obxecto...");
            list.Add("Acabas de obter un "+item+" | cantidade = "+cantItem);
            dialog.SetDialogs("YO",list);
            gameObject.SetActive(false);
        }
    }
}

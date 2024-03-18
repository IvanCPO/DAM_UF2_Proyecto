using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogCombat : MonoBehaviour
{
    [SerializeField] Text text;
    [SerializeField] Text border;
    [SerializeField] int letterPerSeconds;

    public void GenerateTextEnemy(string dialog){
        gameObject.SetActive(true);
        border.color=Color.red;
        text.text = dialog;
        border.text = dialog;
    }
    public void GenerateTextPlayer(string dialog){
        gameObject.SetActive(true);
        border.color=Color.blue;
        text.text = dialog;
        border.text = dialog;
    }
    public void GenerateTextInfo(string dialog){
        gameObject.SetActive(true);
        border.color=Color.white;
        text.text = dialog;
        border.text = dialog;
    }

    public void StartGame(Pokemon rival){
        String messageStart = "HA APARECIDO UN "+rival.Base.Name.ToUpper()+" SALVAJE!!!! A PELEAR...";
        GenerateTextInfo(messageStart);
        Invoke("InitializeCombat",4f);
    }

    private void InitializeCombat(){
        BattleSystem system = GameObject.FindGameObjectWithTag("GameController").GetComponent<BattleSystem>();
        OcultarMostrarDialog();
        system.FinishDialog();
    }
    public void OcultarMostrarDialog(){
        if (gameObject.active)
        {
            gameObject.SetActive(false);
        }else
            gameObject.SetActive(true);
    }


}
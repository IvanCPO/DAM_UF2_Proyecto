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
    private StatusRival rivalStatus;
    public void StartGame(){
        rivalStatus = StatusRival.GetRival();
        string messageStart;
        if (rivalStatus.IsWild)
        {
            messageStart = "Un pokemon salvaje ha aparecido. ES "+rivalStatus.Team[0].Base.Name.ToUpper()+"!!!! A PELEAR!!!";
        }else{
            messageStart = rivalStatus.NameRival+" te a desafiado a un combate. Lanza a "+rivalStatus.Team[0].Base.Name.ToUpper()+". A PELEAR!!!";
        }
        GenerateTextInfo(messageStart);
        Invoke("InitializeCombat",4f);
    }

    private void InitializeCombat(){
        BattleSystem system = GameObject.FindGameObjectWithTag("GameController").GetComponent<BattleSystem>();
        OcultarMostrarDialog();
        system.FinishDialog();
    }
    public void OcultarMostrarDialog(){
        gameObject.SetActive(!gameObject.active);
    }


}

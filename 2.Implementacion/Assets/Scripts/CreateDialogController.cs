using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateDialogController : MonoBehaviour
{
    [SerializeField] GameObject panelDialog;
    [SerializeField] Text entityName;
    [SerializeField] Text textDialog;
    private List<string> dialog;
    private int letterPerSecond = 50;
    private bool writeNow = false;
    private int takeP;
    private int pulsation;
    public bool FinishConversation{get;set;}

    private void Start(){
        FinishConversation = false;
        takeP = 0;
        pulsation = 0;
    }
    private void Update(){
        if (panelDialog.activeSelf)
        {
            if(Input.GetKeyDown(KeyCode.Space)){
                DialogChange();
            } 
        }else{
            takeP = 0;
        }
    }
    private void RetomePulsations(){
        pulsation = 0;
    }
    private void DialogChange(){
        if (pulsation==0)
        {
            pulsation++;
            Invoke("RetomePulsations",0.3f);
            if (!writeNow && dialog.Count>takeP){
                writeNow=true;
                StartCoroutine("InsertTextDialog",dialog[takeP]);
            }
            if (writeNow && dialog.Count<takeP)
            {
                textDialog.text = dialog[takeP];
                writeNow = false;
                takeP++;
            }
            if (!writeNow && dialog.Count==takeP){
                Invoke("CloseDialog",0.2f);
            }
        }
    }
    

    public void SetDialogs(string name, List<string> dialog){
        Invoke("StopPlayer",0.5f);
        this.dialog = new List<string>();
        for (int i = 0; i < dialog.Count; i++)
        {
            if (dialog[i].Contains("$user"))
                dialog[i] =dialog[i].Replace("$user",StatusPlayer.getInstance().GetName());
        }
        this.dialog = dialog;
        entityName.text = name+":";
        panelDialog.SetActive(true);
        StartCoroutine("InsertTextDialog",dialog[takeP]);
        writeNow = true;
    }
    private void CloseDialog(){
        FinishConversation = true;
        textDialog.text="";
        entityName.text="";
        panelDialog.SetActive(false);
        StopPlayer();
    }

    private void StopPlayer(){
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().ChangeMove();
    }

    private IEnumerator InsertTextDialog(string info){
        textDialog.text="";
        // Debug.Log(info);
        foreach (char letter in info.ToCharArray())
        {
            textDialog.text+=letter;
            yield return new WaitForSeconds(1f/letterPerSecond);
        }
        writeNow = false;
        takeP++;

    }
}

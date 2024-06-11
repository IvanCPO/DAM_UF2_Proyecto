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
    private int letterPerSecond = 33;
    private bool writeNow = false;
    private int takeP;
    private bool activate;
    private int pulsation;
    private string nameUser;

    private void Start(){
        activate = false;
        takeP = 0;
        pulsation = 0;
        nameUser= StatusPlayer.getInstance().GetName();
    }
    private void Update(){
        if (activate)
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
            pulsation = 1;
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
        for (int i = 0; i < dialog.Count; i++)
        {
            if (dialog[i].Contains("$user"))
            {
                dialog[i] = dialog[i].Replace("$user",nameUser);
            }
        }
        this.dialog = dialog;
        entityName.text = name+":";
        activate=true;
        panelDialog.SetActive(true);
        StartCoroutine("InsertTextDialog",dialog[takeP]);
        writeNow = true;
    }
    private void CloseDialog(){
        textDialog.text="";
        entityName.text="";
        panelDialog.SetActive(false);
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().ChangeMove();
        activate = false;
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

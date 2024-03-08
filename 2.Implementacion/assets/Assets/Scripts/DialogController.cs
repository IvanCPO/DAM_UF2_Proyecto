using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogController : MonoBehaviour
{
    [SerializeField] Text text;
    [SerializeField] Text border;
    [SerializeField] int letterPerSeconds;

    public void GenerateTextEnemy(string dialog){
        border.color=Color.red;
        StartCoroutine("InsertTextDialog",dialog);
    }
    public void GenerateTextPlayer(string dialog){
        border.color=Color.blue;
        text.text = dialog;
        border.text = dialog;
    }
    public IEnumerator InsertTextDialog(string dialog){

        text.text = "";
        border.text = "";
        foreach (var letter in dialog.ToCharArray())
        {
            text.text+=letter;
            border.text+=letter;
            yield return new WaitForSeconds(1f/letterPerSeconds);
        }
    }
}

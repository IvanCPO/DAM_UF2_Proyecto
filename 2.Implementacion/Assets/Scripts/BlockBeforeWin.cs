using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BlockBeforeWin : MonoBehaviour
{
    [SerializeField] int idTrainer;
    StatusPlayer status;

    void Start(){
        status = StatusPlayer.getInstance();
    }

    void Update(){
        if (status.idTrainersWork.Contains(idTrainer))
        {
            gameObject.SetActive(false);
        }
    }
}

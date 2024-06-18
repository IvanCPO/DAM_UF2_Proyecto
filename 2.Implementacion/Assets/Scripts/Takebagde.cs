using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Takebagde : MonoBehaviour
{

    [SerializeField] int badge;
    private StatusPlayer status;

    void Start(){
        status = StatusPlayer.getInstance();
    }
    public void addBadge(){
        status.medallas[badge] = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamAccountController : MonoBehaviour
{
    [SerializeField] List<PictureBattle> pictures;
    
    public void SetDataTeam(StatusPlayer status){
        for (int i = 0; i < status.GetTeam().Count; i++)
        {
            pictures[i].Setup(status.GetTeam()[i]);
        }
    }
}

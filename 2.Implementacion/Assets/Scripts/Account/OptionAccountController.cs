using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionAccountController : MonoBehaviour
{
    [SerializeField] ProfileAccountController account;
    [SerializeField] TeamAccountController team;
    [SerializeField] List<BadgePictureController> badge;
    

    public void SetDataPlayer(){
        var status = StatusPlayer.getInstance();
        account.SetData(status);
        team.SetDataTeam(status);
        for (int i = 0; i < status.Medallas.Length; i++)
        {
            if (status.Medallas[i])
            {
                badge[i].AddBadge();
            }
        }
    }
}

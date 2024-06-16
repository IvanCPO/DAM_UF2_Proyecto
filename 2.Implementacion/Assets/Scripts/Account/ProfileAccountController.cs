using UnityEngine;
using UnityEngine.UI;

public class ProfileAccountController : MonoBehaviour
{
    [SerializeField] Text textName;
    [SerializeField] Text money;
    [SerializeField] SaveAnimationController save;
    private StatusPlayer status;

    public void SetData(StatusPlayer status){
        textName.text = status.GetName();
        money.text = status.GetMoney()+"€";
        this.status = status;
    }
    public void SaveGame(){
        save.ActivateAnimationSave(status);
    }
}

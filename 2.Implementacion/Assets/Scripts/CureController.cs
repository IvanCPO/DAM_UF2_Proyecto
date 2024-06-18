using UnityEngine;

public class CureController : MonoBehaviour
{
    [SerializeField] SaveAnimationController cure;
    private StatusPlayer status;

    void Update(){
        if(cure.FinishCure){
            cure.FinishCure = false;
            gameObject.SetActive(false);
        }
    }
    public void SetData(StatusPlayer status){
        gameObject.SetActive(true);
        this.status = status;
    }
    public void RestAllPokemons(){
        cure.ActivateAnimationCure(status);
    }
}

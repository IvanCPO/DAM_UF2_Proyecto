
using UnityEngine;
using UnityEngine.UI;

public class LostPokemonController : MonoBehaviour
{
    [SerializeField] Text question;
    [SerializeField] GameObject buttonRun;
    public bool WasPressedEscape{get;set;}

    public bool Decision{get;set;}
    public bool Change{get;set;}
    

    public void SetData(Pokemon pokemon, bool wild){
        gameObject.SetActive(true);
        Decision = false;
        Change = false;
        WasPressedEscape = false;
        question.text = "Perdiste a tu "+pokemon.Base.Name+", que quieres hacer";
        buttonRun.GetComponent<Button>().enabled = wild;
    }

    public void ChangePokemon(){
        Decision = true;
        Change = true;
    }

    public void Run(){
        if (!WasPressedEscape)
        {
            Debug.Log("Presionaste el huir");
            WasPressedEscape = true;
            Decision = true;
            Change = false;
        }
    }

    public void ClearDecision(){
        gameObject.SetActive(false);
        WasPressedEscape = false;
        Decision = false;
        Change = false;
    }
}

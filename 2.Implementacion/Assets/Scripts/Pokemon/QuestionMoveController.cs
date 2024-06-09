
using UnityEngine;
using UnityEngine.UI;

public class QuestionMoveController : MonoBehaviour
{
    
    [SerializeField] Image picture;
    [SerializeField] Text nameMove;
    public void ChangeActive(){
        gameObject.SetActive(!gameObject.activeSelf);
    }

    public void SetData(Pokemon pokemon, Move move){
        picture.sprite = pokemon.Base.FrontSprite;
        nameMove.text = move.Base.Name;
    }
}

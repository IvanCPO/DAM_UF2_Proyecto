
using UnityEngine;
using UnityEngine.UI;

public class PictureBattle : MonoBehaviour
{
    [SerializeField] bool isPlayer;
    public Pokemon Pokemon{get;set;}
    //CUANDO EL JUEGO ESTA COMPLETO
    public void Setup ( Pokemon pokemon ){
        //Pokemon = new Pokemon(_base,level);
        if (isPlayer)
            GetComponent<Image>().sprite = pokemon.Base.BackSprite;
        else
            GetComponent<Image>().sprite = pokemon.Base.FrontSprite;

        
    }
}

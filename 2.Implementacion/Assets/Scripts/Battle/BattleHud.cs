using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHud : MonoBehaviour
{
    [SerializeField] Text nameText;
    [SerializeField] Text levelText;
    [SerializeField] HPBar hpBar;
    [SerializeField] ExpBarController expBar;
    private void Update(){
    }
    public void SetData(Pokemon pokemon){
        nameText.text = pokemon.Base.Name;
        levelText.text = "Lvl "+pokemon.Level;
        hpBar.SetHP(pokemon);
        if (expBar!=null)
        {
            expBar.SetExp(pokemon);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHud : MonoBehaviour
{
    [SerializeField] Text nameText;
    [SerializeField] Text levelText;
    [SerializeField] HPBar hpBar;
    int count= 0;
    private void Update(){
        if (count==33)
        {
            
        }
    }
    public void SetData(Pokemon pokemon){
        nameText.text = pokemon.Base.Name;
        levelText.text = "Lvl "+pokemon.Level;
        hpBar.SetHP((float)pokemon.HP/pokemon.MaxHP);
    }
}

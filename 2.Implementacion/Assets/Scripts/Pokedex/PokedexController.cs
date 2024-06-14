using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokedexController : MonoBehaviour
{
    [SerializeField] BaseDataController left;
    [SerializeField] ScrollContentController content; 
    StatusPlayer status;
    
    public void OpenPokedex(){
        this.gameObject.SetActive(true);
        status = StatusPlayer.getInstance();
        content.SetPokemons(status);
        content.DiSelect();
        left.SetDataUnknow();
    }

    public void EnterData(int i){
        content.DiSelect();
        DataBasic(i);
    }

    private void DataBasic(int i){
        PokemonBase p = null;
        switch(content.GetList()[i].Select())
        {
            case 0:
                left.SetDataUnknow();
            break;
            case 1:
                p = PokemonBase.GetPokemonBase(i+1);
                left.SetDataKnow(p);
            break;
            case 2:
                p = PokemonBase.GetPokemonBase(i+1);
                left.SetData(new Pokemon(p,1));
            break;
        }
    }
    
}

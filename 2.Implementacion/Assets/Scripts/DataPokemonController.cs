using System;
using UnityEngine;
using UnityEngine.UI;
[Serializable]
public class DataPokemonController : MonoBehaviour
{
    [SerializeField] Text namePokemon;
    [SerializeField] Text levelPokemon;
    [SerializeField] Text hpCount;
    [SerializeField] HPBar hpBar;
    [SerializeField] ExpBarController expBar;
    [SerializeField] PictureEfectController ailment;
    [SerializeField] GameObject select;

    private Pokemon pokemon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pokemon!=null)
        {
            namePokemon.text = pokemon.Base.Name;
            levelPokemon.text = "Lvl. "+pokemon.Level;
            hpCount.text = "HP "+pokemon.HP+"/"+pokemon.MaxHP;
            hpBar.SetHP(pokemon);
            expBar.SetExp(pokemon);
            ailment.SetPictureAilment(pokemon.Ailment);
        }else
        {
            Debug.Log("El pokemon no existe.");
            gameObject.SetActive(false);
        }
    }

    public void AddPokemon(Pokemon pokemon){
        if (pokemon!=null)
        {
            gameObject.SetActive(true);
            this.pokemon = pokemon;
        }

        // if (pokemon.HP == 0)
        // {
        //     GetComponent<Image>().color = new Color(124,40,27);
        // }else
        // {
        //     GetComponent<Image>().color = new Color(27,31,124);
        // }
    }
    public void isSelected(){
        select.SetActive(!select.active);
    }
}

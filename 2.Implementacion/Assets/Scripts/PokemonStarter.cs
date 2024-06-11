
using UnityEngine;
using UnityEngine.UI;

public class PokemonStarter : MonoBehaviour
{
    [SerializeField] Image pokemon1Image;
    [SerializeField] Image pokemon2Image;
    [SerializeField] Image pokemon3Image;
    [SerializeField] Pokemon pokemon1;
    [SerializeField] Pokemon pokemon2;
    [SerializeField] Pokemon pokemon3;
    private StatusPlayer player;
    void Start()
    {
        player = StatusPlayer.getInstance();
    }

    // Update is called once per frame
    
    public void Select(int pokemon){
        switch (pokemon)
        {
            case 1:
            player.SavePokemon(pokemon1);
            break;
            case 2:
            player.SavePokemon(pokemon2);
            break;
            case 3:
            player.SavePokemon(pokemon3);
            break;
        }
        gameObject.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonTypeEnum : MonoBehaviour{
    [SerializeField] Sprite normal;
    [SerializeField] Sprite Fire;
    [SerializeField] Sprite Water;
    [SerializeField] Sprite Electric;
    [SerializeField] Sprite Grass;
    [SerializeField] Sprite Ice;
    [SerializeField] Sprite Fighting;
    [SerializeField] Sprite Poison;
    [SerializeField] Sprite Ground;
    [SerializeField] Sprite Flying;
    [SerializeField] Sprite Psychic;
    [SerializeField] Sprite Bug;
    [SerializeField] Sprite Rock;
    [SerializeField] Sprite Ghost;
    [SerializeField] Sprite Dragon;
    [SerializeField] Sprite Dark;
    [SerializeField] Sprite Steel;
    [SerializeField] Sprite Fairy;
    [SerializeField] Sprite None;
    public static PokemonType GetPokemonType(int value){
        PokemonType type;
        switch(value){
            case 1:
            type=PokemonType.Normal;
            break;
            case 2:
            type=PokemonType.Fire;
            break;
            case 3:
            type=PokemonType.Water;
            break;
            case 4:
            type=PokemonType.Electric;
            break;
            case 5:
            type=PokemonType.Grass;
            break;
            case 6:
            type=PokemonType.Ice;
            break;
            case 7:
            type=PokemonType.Fighting;
            break;
            case 8:
            type=PokemonType.Poison;
            break;
            case 9:
            type=PokemonType.Ground;
            break;
            case 10:
            type=PokemonType.Flying;
            break;
            case 11:
            type=PokemonType.Psychic;
            break;
            case 12:
            type=PokemonType.Bug;
            break;
            case 13:
            type=PokemonType.Rock;
            break;
            case 14:
            type=PokemonType.Ghost;
            break;
            case 15:
            type=PokemonType.Dragon;
            break;
            case 16:
            type=PokemonType.Dark;
            break;
            case 17:
            type=PokemonType.Steel;
            break;
            case 18:
            type=PokemonType.Fairy;
            break;
            default: type = PokemonType.None; break;
        }
        return type;
    }
    public Sprite GetSpriteType(PokemonType value){
        Sprite type;
        switch(value){
            case PokemonType.Normal:
            type= normal;
            break;
            case PokemonType.Fire:
            type= Fire;
            break;
            case PokemonType.Water:
            type= Water;
            break;
            case PokemonType.Electric:
            type= Electric;
            break;
            case PokemonType.Grass:
            type= Grass;
            break;
            case PokemonType.Ice:
            type= Ice;
            break;
            case PokemonType.Fighting:
            type= Fighting;
            break;
            case PokemonType.Poison:
            type= Poison;
            break;
            case PokemonType.Ground:
            type= Ground;
            break;
            case PokemonType.Flying:
            type= Flying;
            break;
            case PokemonType.Psychic:
            type= Psychic;
            break;
            case PokemonType.Bug:
            type= Bug;
            break;
            case PokemonType.Rock:
            type= Rock;
            break;
            case PokemonType.Ghost:
            type= Ghost;
            break;
            case PokemonType.Dragon:
            type= Dragon;
            break;
            case PokemonType.Dark:
            type= Dark;
            break;
            case PokemonType.Steel:
            type= Steel;
            break;
            case PokemonType.Fairy:
            type= Fairy;
            break;
            default: type = None; break;
        }
        return type;
    }
}

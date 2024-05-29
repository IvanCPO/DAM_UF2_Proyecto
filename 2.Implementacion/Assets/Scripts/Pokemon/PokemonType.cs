class PokemonTypeEnum{
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
            default: type = PokemonType.Normal; break;
        }
        return type;
    }
}
public enum PokemonType{
    Normal,
    Fire,
    Water,
    Electric,
    Grass,
    Ice,
    Fighting,
    Poison,
    Ground,
    Flying,
    Psychic,
    Bug,
    Rock,
    Ghost,
    Dragon,
    Dark,
    Steel,
    Fairy

}
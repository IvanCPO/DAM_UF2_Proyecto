using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoSystem : MonoBehaviour, InterfaceData
{
    [SerializeField] AvatarDataController avatar;
    [SerializeField] InserterStats stats;
    [SerializeField] BattleMoves moves;
    [SerializeField] InfoTextController moveInfo;
    private Pokemon pokemon;

    public void InsertDataPokemon(Pokemon pokemon)
    {
        this.pokemon = pokemon;
        avatar.InsertDataPokemon(pokemon);
        stats.InsertDataPokemon(pokemon);
        moves.SetMoves(pokemon);
    }
    public void CloseInfo(){
        moveInfo.CloseText();
        gameObject.SetActive(false);
    }
    public void CheckMoveInfo(int move){
        moves.ClearMovesSelected();
        moves.GetMoves()[move].ChangeSelected();
        moveInfo.InsertDataMove(pokemon.Moves[move]);
    }

}

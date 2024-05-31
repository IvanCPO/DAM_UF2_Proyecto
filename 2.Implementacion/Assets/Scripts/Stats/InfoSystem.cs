using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoSystem : MonoBehaviour, InterfaceData
{
    [SerializeField] AvatarDataController avatar;
    [SerializeField] InserterStats stats;
    [SerializeField] BattleMoves moves;
    [SerializeField] GameObject moveInfo;

    public void InsertDataPokemon(Pokemon pokemon)
    {
        avatar.InsertDataPokemon(pokemon);
        stats.InsertDataPokemon(pokemon);
        // moves.SetMoves(pokemon);
    }
    public void OpenStatsSystem()
    {
        gameObject.SetActive(true);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    // ESTA PARTE SE MATIENE CUANDO YA TENGO EL JUEGO PREPARADO, PARA PREPARAR EL COMBATE HAY
    // QUE QUITARLO
    [SerializeField] PokemonBase enemyPokemon;
    [SerializeField] int level;
    // HASTA AQUI LAS VARIABLES PARA EL JUEGO
    
    [SerializeField] PictureBattle player;
    [SerializeField] BattleHud playerLive;
    [SerializeField] PictureBattle enemy;
    [SerializeField] BattleHud enemyLive;
    [SerializeField] BattleMoves movesOptions;

    StatusPlayer playerStatus;
    // Start is called before the first frame update
    void Start()
    {
        playerStatus = StatusPlayer.getInstance();
        SetupBattle();
    }

    private void SetupBattle()
    {
        // JUEGO PREPARADO
        Pokemon pokemon = playerStatus.FirstPokemon();
        Pokemon rival = new Pokemon(enemyPokemon,level);
        player.Setup(pokemon);
        playerLive.SetData(pokemon);
        enemy.Setup(rival);
        enemyLive.SetData(rival);
        movesOptions.SetMoves(pokemon);

        
        // PARA CUANDO SE TESTEA
        /*
        player.Setup();
        playerLive.SetData(player.Pokemon);
        enemy.Setup();
        enemyLive.SetData(enemy.Pokemon);
        movesOptions.SetMoves(player.Pokemon);*/
    
    }
}

using System;
using System.Collections.Generic;
using UnityEngine;

public class TrainerController : MonoBehaviour
{
    [SerializeField] string trainerName;
    [SerializeField] int idTrainer;
    [SerializeField] int money;
    [TextArea]
    [SerializeField] List<string> messageBefore;
    [TextArea]
    [SerializeField] List<string> messageLater;
    [SerializeField] List<RivalController> pokemons;
    StatusRival rivalStatus;
    StatusPlayer player;
    private CreateDialogController dialog;
    private bool conversationCombat;
    private void Start(){
        conversationCombat = false;
        rivalStatus = StatusRival.GetRival();
        player = StatusPlayer.getInstance();
        GameObject canvas = GameObject.FindGameObjectWithTag("Canvas");
        dialog = canvas.GetComponent<CreateDialogController>();
    }
    private void Update(){
        if (StatusPlayer.getInstance().GetTeam().Count == 0)
        {
            gameObject.SetActive(false);
        }
        if (conversationCombat){
            if (dialog.FinishConversation)
            {
                conversationCombat = false;
                dialog.FinishConversation = false;
                StartCombat();
            }
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        // Comprueba si el objeto que entra en contacto es el jugador
        if (other.gameObject.CompareTag("Player"))
        {
            if (!player.idTrainersWork.Contains(idTrainer))
            {
                dialog.SetDialogs(trainerName, messageBefore);
                conversationCombat = true;
            }else{
                if (messageLater.Count!=0)
                {
                    dialog.SetDialogs(trainerName, messageLater);
                    messageLater = new List<string>();
                    try{
                        gameObject.GetComponent<Takebagde>().addBadge();
                    }catch{
                        Debug.Log("You win a trainer");
                    }
                }
            }
            
        }
    }

    private void StartCombat(){
        Debug.Log("Que empiece el combate");
        List<Pokemon> list = new List<Pokemon>();
        foreach (RivalController pokemon in pokemons)
        {
            list.Add(pokemon.GeneratePokemon());
        }
        rivalStatus.SetData(list,idTrainer,trainerName,money);

        gameObject.GetComponent<ChangeSceneController>().Saver();
    }
    public bool ExistThis(){
        return true;
    }
}

using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveAnimationController : MonoBehaviour
{
    [SerializeField] Image confirm;
    [SerializeField] GameObject player;

    private bool save;
    float count = 0.00000f;
    private StatusPlayer status;


    // Update is called once per frame
    void Update()
    {
        if (save)
        {
            if (count >= 1f)
            {
                save = false;
                SaveGame();
            }else{
                count+=0.003f;
                gameObject.GetComponent<Image>().fillAmount = count;
                confirm.fillAmount = count;
            }
        }
    }

    public void ActivateAnimation(StatusPlayer status){
        this.status = status;
        gameObject.SetActive(true);
        save = true;
    }

    private void SaveGame()
    {
        count = 0.00000f;
        gameObject.SetActive(false);
        gameObject.GetComponent<Image>().fillAmount = count;
        confirm.fillAmount = count;
        status.SaveUbication(player.transform.position, LayerMask.LayerToName(player.layer), player.scene.buildIndex);
        status.SaveData();
        Debug.Log("Escena de la ubicación actual: "+status.actual.SceneId+" | ubi: "+status.actual.Ubica);
        Debug.Log("Escena de la ubicación del mundo: "+status.world.SceneId+" | ubi: "+status.world.Ubica);
    }
}

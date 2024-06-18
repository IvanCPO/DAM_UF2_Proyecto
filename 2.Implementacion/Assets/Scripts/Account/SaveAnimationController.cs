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
    private bool cure;
    public bool FinishCure{get; set;}
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
        if (cure)
        {
            if (count >= 1f)
            {
                cure = false;
                CureGame();
            }else{
                count+=0.002f;
                gameObject.GetComponent<Image>().fillAmount = count;
                confirm.fillAmount = count;
            }
        }
    }

    public void ActivateAnimationSave(StatusPlayer status){
        this.status = status;
        gameObject.SetActive(true);
        save = true;
    }

    public void ActivateAnimationCure(StatusPlayer status){
        this.status = status;
        gameObject.SetActive(true);
        cure = true;
    }

    private void SaveGame()
    {
        count = 0.00000f;
        gameObject.SetActive(false);
        gameObject.GetComponent<Image>().fillAmount = count;
        confirm.fillAmount = count;
        status.SaveUbication(player.transform.position, player.GetComponent<SpriteRenderer>().sortingLayerName, player.scene.buildIndex);
        status.SaveData();
        
    }

    private void CureGame()
    {
        count = 0.00000f;
        gameObject.SetActive(false);
        gameObject.GetComponent<Image>().fillAmount = count;
        confirm.fillAmount = count;
        status.RestaureAll();
        FinishCure = true;
        status.SaveRestUbication(player.transform.position, LayerMask.LayerToName(player.layer), player.scene.buildIndex);
    }
}

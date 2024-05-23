using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.IO;

public class SaveGameController
{
    private String rutaFileJson;
    private StatusPlayer player;
    private static SaveGameController instance;
    private SaveGameController(){
        rutaFileJson = Path.Combine(Application.dataPath, "Data/saveJson.json");
        player = StatusPlayer.getInstance();
    }

    public static SaveGameController generateSaveController(){
        if(instance==null){
            instance = new SaveGameController();
        }
        return instance;
    }
    public void SaveGame(){
        String json = JsonUtility.ToJson(player);
        // generate file save
        using (StreamWriter escritor = new StreamWriter(rutaFileJson))
        {
            escritor.WriteLine(json);
        }
        Debug.Log("The game is saved correctly in : " + rutaFileJson);

    }
    public void LoadGame(){
        String gameSaved = null;

        using (StreamReader lector = new StreamReader(rutaFileJson))
        {
            gameSaved = lector.ReadToEnd();
        }
        player = JsonUtility.FromJson<StatusPlayer>(gameSaved);

        Debug.Log("Welcome!!! " + player.GetName());


    }
    public bool ExistGame(){
        
        if(File.Exists(rutaFileJson)){
            
            String gameSaved = null;
            using (StreamReader lector = new StreamReader(rutaFileJson))
            {
                gameSaved = lector.ReadToEnd();
            }
            if (gameSaved== "")
            {
                return false;
            }
            return true;
        }
        return false;
    }


}

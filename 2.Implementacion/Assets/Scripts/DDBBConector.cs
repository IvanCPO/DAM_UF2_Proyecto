using System;
using System.IO;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEditor.MemoryProfiler;
using UnityEngine;

public class DDBBConector
{
    private String urlDDBB;
    private String userName;
    private String password;
    private static DDBBConector connector;

    private DDBBConector(){
        urlDDBB = Application.dataPath+"/DDBB/dbPokemon";
        userName = "";
        password = "";
    }

    public static DDBBConector GenerateConnection(){
        if (connector == null){
            connector = new DDBBConector();
        }
        
        return connector;
    }

    public SQLiteConnection GetConnection(){

        if (!File.Exists(urlDDBB))
        {
            Debug.LogError("Database file not found at path: " + urlDDBB);
        }
        else
        {
            Debug.Log("Database file found at path: " + urlDDBB);
        }
        
        return new SQLiteConnection(urlDDBB);;
    }
    
}

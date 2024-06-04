using System;
using System.Data;
using System.Data.Common;
using System.IO;
using Mono.Data.Sqlite;
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

    public IDbConnection GetConnection(){

        if (!File.Exists(urlDDBB))
        {
            Debug.LogError("Database file not found at path: " + urlDDBB);
        }
        else
        {
            Debug.Log("Database file found at path: " + urlDDBB);
        }
        IDbConnection connection = new SqliteConnection("Data Source="+urlDDBB);
        
        return connection;
    }
    
}

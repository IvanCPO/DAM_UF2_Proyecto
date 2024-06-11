using System.Data;
using System.IO;
using Mono.Data.Sqlite;
using UnityEngine;

public class DDBBConector
{
    private string urlDDBB;
    private string userName;
    private string password;
    private static DDBBConector connector;

    private DDBBConector(){
        urlDDBB = Path.Combine(Application.streamingAssetsPath, "dbPokemon");
        userName = "";
        password = "";

        if (!File.Exists(urlDDBB))
        {
            Debug.LogError("Database file not found at path: " + urlDDBB);
        }
        else
        {
            Debug.Log("Database file found at path: " + urlDDBB);
        }
    }

    public static DDBBConector GenerateConnection(){
        if (connector == null){
            connector = new DDBBConector();
        }
        
        return connector;
    }

    public IDbConnection GetConnection(){
        IDbConnection connection = new SqliteConnection("Data Source="+urlDDBB);
        
        return connection;
    }
    
}

using System;
using UnityEditor.MemoryProfiler;
using UnityEngine;

public class DDBBConector
{
    private String urlDDBB;
    private static DDBBConector connector;

    private DDBBConector(){
        urlDDBB = "jdbc:h2:DDBB/dbPokemon.mv";
    }

    public static DDBBConector GenerateConnection(){
        if (connector == null){
            connector = new DDBBConector();
        }
        
        return connector;
    }

public void GetConnection(){
    try{
        

    }catch(Exception e){

        Debug.LogError("La base de datos no se conecta");
    }
}
    
}

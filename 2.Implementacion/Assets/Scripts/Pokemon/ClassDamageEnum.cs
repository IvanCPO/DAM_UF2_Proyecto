using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ClassDamageEnum : MonoBehaviour
{
    [SerializeField] Sprite special;
    [SerializeField] Sprite physical;
    [SerializeField] Sprite status;

    public static ClassDamage GetClassDamage(int id){
        ClassDamage value = ClassDamage.Status;
        switch (id)
        {
            case 1: value = ClassDamage.Special; break;
            case 2: value = ClassDamage.Physical; break;
            default: value = ClassDamage.Status; break;
        }
        return value;
    }

    public Sprite GetSpriteDamage(ClassDamage classDamage){
        switch (classDamage)
        {
            case ClassDamage.Special: return special;
            case ClassDamage.Physical: return physical;
            case ClassDamage.Status: return status;
            default:
            Debug.Log("Don't exist this class of damage");
             return null;
        }
    }
}


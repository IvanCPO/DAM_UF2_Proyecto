using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfectEnum : MonoBehaviour
{
    [SerializeField] Sprite burn;
    [SerializeField] Sprite freeze;
    [SerializeField] Sprite paralyze;
    [SerializeField] Sprite poison;
    [SerializeField] Sprite confuse;
    [SerializeField] Sprite sleep;
    [SerializeField] Sprite none;
    public static Efect GetEfect(int value){
        Efect efect;
        switch(value){
            case 1:
            efect=Efect.BURN;
            break;
            case 2:
            efect=Efect.FREEZE;
            break;
            case 3:
            efect=Efect.PARALYZE;
            break;
            case 4:
            efect=Efect.POISON;
            break;
            case 5:
            efect=Efect.CONFUSE;
            break;
            case 6:
            efect=Efect.SLEEP;
            break;
            default: efect = Efect.NONE; break;
        }
        return efect;
    }
    public Sprite GetSpriteEfect(Efect value){
        Sprite efect;
        switch(value){
            case Efect.BURN:
            efect= burn;
            break;
            case Efect.FREEZE:
            efect= freeze;
            break;
            case Efect.PARALYZE:
            efect= paralyze;
            break;
            case Efect.POISON:
            efect= poison;
            break;
            case Efect.CONFUSE:
            efect= confuse;
            break;
            case Efect.SLEEP:
            efect= sleep;
            break;
            default: efect = none; break;
        }
        return efect;
    }
}

using UnityEngine;
using System;

public class damage : MonoBehaviour
{

    static int atak = 1 + scr.equipedweapon.Getdamage();
    public static int Getdamag(){
        return atak;
    }
}
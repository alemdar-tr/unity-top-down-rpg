using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


public class weapon : MonoBehaviour
{
    private int damage;
    private string naam;

    public weapon(int x, string id) {
        damage = x;
        naam = id;
    }

    public int Getdamage(){
        return damage;
    }
    public string GetName(){
        return naam;
    }

}

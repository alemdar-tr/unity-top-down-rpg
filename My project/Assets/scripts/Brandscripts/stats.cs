using UnityEngine;

public class stats
{
    public int health;
    public int magic;
    public int defence;
    public int Power;

    public stats(int hp, int mp, int def, int pow){
        health = hp;
        magic = mp;
        defence = def;
        Power = pow;
    }

    public int GetHp(){
        return health;
    }
    public int GetMp(){
        return magic;
    }
    public int GetDef(){
        return defence;
    }
    public int GetPow(){
        return Power;
    }
}
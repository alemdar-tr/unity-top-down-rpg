using System.Collections;
using System.Collections.Generic;
using System;

public class RandomStats
{
    static Random newHp = new Random();

    public static int AddHP()
    {
        int hp = newHp.Next(1, 7);
        GetHP(hp);
        return hp;
    }
    public static int GetHP(int health)
    {
        return health;
    }
}

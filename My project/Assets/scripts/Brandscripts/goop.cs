using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class goop : Enemy
{
    public static stats goopstats = new stats(5, 0, 0, 3);

    public goop()
    {
        maxhp = goopstats.GetHp();
        hp = maxhp;
        dietime = 0.4F;
        enemyxp = 20;
    }

}

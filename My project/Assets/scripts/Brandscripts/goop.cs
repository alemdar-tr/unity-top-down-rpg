using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class goop : NetworkBehaviour
{
    public static stats goopstats = new stats(5, 0, 0, 3);
    int hp = goopstats.GetHp();
    float dietime = 0.4F;
    int enemyxp = 20;
    public static bool xpchange = false;
    Timers idk = new Timers(1.0F);

    enemybar baard;
    scr test;
    private void Awake()
    {
        baard = GetComponentInChildren<enemybar>();
    }

    // Start is called before the first frame update
    void Start()
    {
        baard.SetSlide(hp, goopstats.GetHp());
    }

    // Update is called once per frame
    void Update()
    {
        Die();
        TakeDamage();
        if (xpchange)
        {
            idk.countdown();
        }
        if (idk.timer <= 0)
        {
            xpchange = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "slash_0(Clone)")
        {
            NeemSchadeServerRpc();
            test = collision.collider.GetComponentInParent<scr>();

        }
    }
    [ServerRpc(RequireOwnership = false)]
    void NeemSchadeServerRpc()
    {
        hp -= damage.Getdamag();
        DoClientRpc();
    }
    void TakeDamage()
    {
        baard.SetSlide(hp, goopstats.GetHp());
    }

    void  OnDestroy(){
        xpchange = true;
        test.playerxp += enemyxp;
        idk.timer = 1;
    }

    void Die() { 
        if (hp <= 0)
        {
            DieServerRpc();
        }
    }
    [ServerRpc(RequireOwnership = false)]
    void DieServerRpc()
    {
        Destroy(gameObject, dietime);
        DoClientRpc();
    }
    [ServerRpc(RequireOwnership = false)]
    void DoServerRpc()
    {
        DoClientRpc();
    }
    [ClientRpc]
    void DoClientRpc()
    {

    }
}

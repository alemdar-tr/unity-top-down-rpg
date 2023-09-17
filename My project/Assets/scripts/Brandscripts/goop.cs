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
            hp -= damage.Getdamag();
            test = collision.collider.GetComponentInParent<scr>();

        }
    }
    
    [ServerRpc(RequireOwnership = false)]
    void TakeDamageServerRpc()
    {
        baard.SetSlide(hp, goopstats.GetHp());
        TakeDamageClientRpc();
    }

    [ClientRpc]
    void TakeDamageClientRpc()
    {
        if (!IsServer)
        {
            baard.SetSlide(hp, goopstats.GetHp());
        }
    }
    void TakeDamage()
    {
        baard.SetSlide(hp, goopstats.GetHp());
        TakeDamageServerRpc();
    }
    void  OnDestroy(){
        xpchange = true;
        test.playerxp += enemyxp;
        idk.timer = 1;
    }
    [ServerRpc(RequireOwnership = false)]
    void DieServerRpc(){
        if (hp <= 0){
            DieClientRpc();
            Destroy(gameObject, dietime);
        }
    }
    [ClientRpc]
    void DieClientRpc()
    {
        if (!IsServer)
        {
            Destroy(gameObject, dietime);
            Die();
        }
    }

    void Die() { 
        if (hp <= 0)
        {
            Destroy(gameObject, dietime);
            DieServerRpc();
        }
    }
}

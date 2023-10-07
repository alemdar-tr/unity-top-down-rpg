using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using Unity.Netcode;
using UnityEngine;

public class Enemy : NetworkBehaviour
{
    public virtual int hp {get; protected set;}
    public virtual int maxhp { get; protected set;}
    public virtual float dietime { get; protected set;}
    public virtual int enemyxp { get; protected set;}
    public static bool xpchange = false;
    public int playercount;
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
        baard.SetSlide(hp, maxhp);
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
        NeemSchadeClientRpc();
    }
    [ClientRpc]
    void NeemSchadeClientRpc()
    {
        if (!IsHost || !IsServer) hp -= damage.Getdamag();
    }
    void TakeDamage()
    {
        baard.SetSlide(hp, maxhp);
    }
    void OnDestroy()
    {
        xpchange = true;
        test.playerxp += enemyxp;
        idk.timer = 1;
    }
    void Die()
    {
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
    [ClientRpc]
    void DoClientRpc()
    {

    }
}

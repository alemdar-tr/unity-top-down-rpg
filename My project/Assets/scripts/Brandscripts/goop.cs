using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class goop : MonoBehaviour
{
    public int hp = 5;
    float dietime = 0.4F;
    int enemyxp = 90;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        die();
    }

    void OnCollisionEnter2D(Collision2D col){
        if(col.collider.name == "slash_0(Clone)"){
            hp -= damage.Getdamag();
        }
    }
    void OnDestroy(){
        scr.playerxp += enemyxp;
    }
    void die(){
        if (hp <= 0){
            Destroy(gameObject, dietime);
        }
    }
}

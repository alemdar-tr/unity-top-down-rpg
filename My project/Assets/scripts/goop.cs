using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goop : MonoBehaviour
{
    public int hp = 5;

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
            hp -= 5;
        }
    }
    void die(){
        if (hp <= 0){
            Destroy(gameObject);
        }
    }
}

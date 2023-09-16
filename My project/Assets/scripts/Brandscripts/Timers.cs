using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timers
{
    // Start is called before the first frame update
    public float timer = 0;
    private float cooldown;
    void Start()
    {
        
    }

    void add_cooldown(float cool){
        cooldown = cool;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void countdown(){
        if(timer > 0){
            timer -= Time.deltaTime;
        }
        if (timer < 0){
            timer = 0;
        }

    }

    public void count(){
        timer += Time.deltaTime;
    }


}

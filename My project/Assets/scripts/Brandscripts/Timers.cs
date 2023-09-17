using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timers
{
    // Start is called before the first frame update
    public float timer;
    private float cooldown;

    public Timers(float timer)
    {
        this.timer = timer;
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

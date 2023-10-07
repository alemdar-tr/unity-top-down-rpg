using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Slider slider;
    // Start is called before the first frame updat
    void Awake(){
        slider = GetComponent<Slider>();
    }
    public void Setmaxslide(){
        slider.maxValue = scr.playerstats.GetHp();
    }
    void Start(){

    }
    void Update(){
        Setmaxslide();
        Setslide();
    }
    public void Setslide(){
        slider.value = scr.playerhp;
    }
}

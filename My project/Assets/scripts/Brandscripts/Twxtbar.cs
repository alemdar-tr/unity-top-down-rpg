using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Twxtbar : MonoBehaviour
{
    TextMeshProUGUI HP;
    private void Awake()
    {
        HP = GetComponent<TextMeshProUGUI>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HP.text = "/ ";
        HP.text += scr.playerstats.GetHp();
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HP : MonoBehaviour
{
    TextMeshProUGUI Hp;
    private void Awake()
    {
        Hp = GetComponent<TextMeshProUGUI>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Hp.text = "";
        Hp.text += scr.playerhp;
    }
}

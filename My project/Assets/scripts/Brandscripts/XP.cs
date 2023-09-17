using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class XP : MonoBehaviour
{
    TextMeshProUGUI Xp;
    scr help;

    private void Awake()
    {
        Xp = GetComponent<TextMeshProUGUI>();
        help = GetComponentInParent<scr>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Xp.text = "";
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Xp.text = "";
        if(goop.xpchange == true)
        {
            Xp.text += help.playerxp + " / " + help.requiredxp;
        }
        
    }
}

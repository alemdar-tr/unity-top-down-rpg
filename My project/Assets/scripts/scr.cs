using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting.AssemblyQualifiedNameParser;
using UnityEditor.Callbacks;

public class scr : MonoBehaviour
{

    public GameObject MC;
    private Component rb;
    // Start is called before the first frame update
    void Start()
    {
        Update();
    }

    // Update is called once per frame
    void Update()
    {
        movement();
    }

    private void movement() {
        bool W = Input.GetKeyDown(KeyCode.Space);
        int y = Convert.ToInt32(W)
        rb.GetComponent<Rigidbody2d> = new Vector2(0, y);
        
    }
}

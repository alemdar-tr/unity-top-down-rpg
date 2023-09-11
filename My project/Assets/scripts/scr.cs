using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting.AssemblyQualifiedNameParser;
using UnityEditor.Callbacks;

public class scr : MonoBehaviour
{
    public GameObject MC;
    public float Speed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        movement();
    }

    private void movement() {
        float y = Input.GetAxis("Vertical");
        float x = Input.GetAxis("Horizontal");
        Vector2 mov = new Vector2(x, y) * Speed;
            
        transform.Translate(mov);
        
        
    }

    public float getY() {
        return transform.position.y;
    }

    public float getx() {
        return transform.position.x;
    }
}

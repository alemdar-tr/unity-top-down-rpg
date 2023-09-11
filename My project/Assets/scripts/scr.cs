using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting.AssemblyQualifiedNameParser;
using UnityEditor.Callbacks;

public class scr : MonoBehaviour
{
    public float GetY() {
        float bro = transform.position.y;
        return bro;
    }

    public float Getx() {
        return transform.position.x;
    }
    public GameObject MC;
    public float Speed;
    private int Level = 1;
    private int exp = 0;
    bool facingright = true;
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
        if (x < 0 && facingright){
            flip();
        }
        else if(x > 0 && !facingright) {
            flip();
        }
        
    }

    void flip() {
        Vector3 curruntscale = gameObject.transform.localScale;
        curruntscale.x *= -1;
        gameObject.transform.localScale = curruntscale;

        facingright = !facingright;
    }


}

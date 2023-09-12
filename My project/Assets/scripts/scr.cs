using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting.AssemblyQualifiedNameParser;
using UnityEditor.Callbacks;
using Unity.Multiplayer.Tools.NetStatsReporting;
using JetBrains.Annotations;
using Unity.Mathematics;
using Unity.VisualScripting;

public class scr : MonoBehaviour
{
    public float GetY() {
        float bro = transform.position.y;
        return bro;
    }

    public float Getx() {
        return transform.position.x;
    }
    public GameObject atak;
    public float Speed;
    private int Level = 1;
    private int exp = 0;
    private GameObject clone;
    bool facingright = true;
    float cooldown = 0.5F;
    float nextfire = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        movement();
        attack();
        clone.transform.position = transform.position;
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

    void attack() {
        if (Time.time > nextfire){
            if (Input.GetKey(KeyCode.Mouse0)) {
                GameObject clone = (GameObject)Instantiate(atak, transform.position, Quaternion.identity);
                clone.transform.position= transform.position;
                Destroy(clone, 0.4F);
                nextfire = Time.time + cooldown;
            }
        }

    }

    void flip() {
        Vector3 curruntscale = gameObject.transform.localScale;
        curruntscale.x *= -1;
        gameObject.transform.localScale = curruntscale;

        facingright = !facingright;
    }


}

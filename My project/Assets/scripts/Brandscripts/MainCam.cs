using System.Collections;
using System;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class MainCam : NetworkBehaviour
{
    Vector3 og;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void FlipCam()
    {
        og = transform.localScale;
        og.x *= -1;
        transform.localScale = og;
    }
}

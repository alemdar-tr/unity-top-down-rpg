using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class gamecontrol : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        NetworkManager.Singleton.StartHost();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape)){
            Application.Quit();
        }
    }
}

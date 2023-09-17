using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    [SerializeField] private Transform spawning;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            Transform Spawn = Instantiate(spawning);
            Spawn.GetComponent<NetworkObject>().Spawn();
        }
    }
}

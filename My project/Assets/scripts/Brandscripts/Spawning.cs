using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class Spawning : NetworkBehaviour
{
    [SerializeField] private Transform spawning;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Tryspawn();
    }

    void Tryspawn()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            TrySpawnServerRpc();
        }
    }
    [ServerRpc(RequireOwnership = false)]
    void TrySpawnServerRpc()
    {
        Transform Spawn = Instantiate(spawning);
        Spawn.GetComponent<NetworkObject>().Spawn();
        TrySpawnClientRpc();
    }
    [ClientRpc]
    void TrySpawnClientRpc()
    {

    }
}

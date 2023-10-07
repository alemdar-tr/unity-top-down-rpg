using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class gamecontrol : MonoBehaviour
{
    [SerializeField] private Button Host;
    [SerializeField] private Button server;
    [SerializeField] private Button Client;

    private void Awake()
    {
        Host.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartHost();
        });
        server.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartServer();
        });
        Client.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartClient();
        });
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape)){
            Application.Quit();
        }
    }

}

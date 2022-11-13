using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simulation : MonoBehaviour
{
    void Start()
    {

        string ip = "192.168.1.56";
        string subnetMask = "255.255.255.224";
        Debug.Log("NetworkID: " + Utility.GetNetworkID(ip, subnetMask));

        //initState();
    }

    void Update()
    {
        
    }

    public void initState()
    {
        /* iniciando todos os dispositivos */
        foreach (DefaultComputer device in FindObjectsOfType<DefaultComputer>())
        {
            device.Initialize();
        }

    }
}

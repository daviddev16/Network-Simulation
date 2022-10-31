using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simulation : MonoBehaviour
{
    void Start()
    {
        initState();
    }

    void Update()
    {
        
    }

    public void initState()
    {
        /* iniciando todos os dispositivos */
        foreach (ComputerDevice device in FindObjectsOfType<ComputerDevice>())
        {
            device.Initialize();
        }

    }
}

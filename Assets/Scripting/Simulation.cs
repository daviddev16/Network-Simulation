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
        foreach (DefaultComputer device in FindObjectsOfType<DefaultComputer>())
        {
            device.Initialize();
        }

    }
}

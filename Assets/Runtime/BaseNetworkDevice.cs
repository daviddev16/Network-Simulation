using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseNetworkDevice : BaseDevice, NetworkDevice
{

    private HashSet<NetworkInterface> networkInterfaces;

    public HashSet<NetworkInterface> NetworkInterfaces 
    { 
        get => networkInterfaces; 
        set
        {
            if (networkInterfaces == null)
                networkInterfaces = value;
        }
    }

    new void Start()
    {
        base.Start();
    }
}

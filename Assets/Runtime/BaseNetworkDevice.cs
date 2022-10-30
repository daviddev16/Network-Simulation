
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseNetworkDevice : BaseDevice, NetworkDevice
{
    [SerializeField] private List<TestNetworkInterface> networkInterfaces;

    public List<TestNetworkInterface> NetworkInterfaces 
    { 
        get => networkInterfaces; 
        set
        {
            if (networkInterfaces == null)
                networkInterfaces = value;
        }
    }

    new void Awake()
    {
        NetworkInterfaces = new List<TestNetworkInterface>();
        base.Awake();
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class EthernetDataLinkPort : MonoBehaviour, DataLinkPort
{
    private NetworkInterface parent;
    DataLinkPort pluggedDevice;
    public DataLinkPort PluggedDevice 
    { 
        get => pluggedDevice; 
        set => pluggedDevice = value; 
    }
    
    /* to be set when the device instantiate de datalinkport on canvas */
    public NetworkInterface Parent 
    { 
        get => parent;
        set => parent = value;
    }

    public void SendSignal(/* send networking packet */)
    {
        if (PluggedDevice != null)
        {
            if (PluggedDevice is EthernetDataLinkPort)
            {
                ((EthernetDataLinkPort)PluggedDevice).ReceiveSignal();
            }
        }
    }
    
    public void ReceiveSignal(/* receive networking packet */) 
    {
        Debug.Log("[" + Parent.MacAddress + "] Received something from [" + PluggedDevice.Parent.MacAddress + "].");
    }

    
}

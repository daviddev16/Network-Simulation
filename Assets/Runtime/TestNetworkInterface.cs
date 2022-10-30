using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TestNetworkInterface : MonoBehaviour, NetworkInterface
{

    [SerializeField] private List<EthernetDataLinkPort> dataLinks;

    private string mac;

    public string MacAddress 
    {
        get => gameObject.name + "@networkinterface@Device";
        set => mac = value;
    }
    public List<EthernetDataLinkPort> DataLinkPorts { get => dataLinks; set => dataLinks = value; }

    private void Awake()
    {
        foreach (DataLinkPort port in DataLinkPorts)
        {
            port.Parent = this;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TestNetworkInterface : MonoBehaviour, NetworkInterface
{

    [SerializeField] private EthernetDataLinkPort dataLink;

    private string mac;

    public string MacAddress 
    {
        get => gameObject.name + "@networkinterface@Device";
        set => mac = value;
    }
    public EthernetDataLinkPort DataLinkPort { get => dataLink; set => dataLink = value; }

    private void Awake()
    {
        DataLinkPort.Parent = this;
    }
}

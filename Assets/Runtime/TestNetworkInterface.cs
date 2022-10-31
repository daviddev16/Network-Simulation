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
        get => mac;
        set => mac = value;
    }
    public EthernetDataLinkPort DataLinkPort { get => dataLink; set => dataLink = value; }

    private void Awake()
    {
        MacAddress = Utility.GenerateMACAddress();
        DataLinkPort.Parent = this;
    }
}

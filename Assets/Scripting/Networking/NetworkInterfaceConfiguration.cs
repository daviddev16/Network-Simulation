

using System;
using UnityEngine;

[Serializable]
public class NetworkInterfaceConfiguration : AbstractNetworkInterfaceConfiguration<Inet4Address>
{

    [SerializeField] private Inet4Address address;

    public override Inet4Address Address 
    {
        get => address;
        set => address = value; 
    }

    [SerializeField] private Inet4Address subnetMask;
    public override Inet4Address SubnetMask 
    {
        get => subnetMask;
        set => subnetMask = value;
    }

    [SerializeField] private Inet4Address defaultGateway;
    public override Inet4Address DefaultGateway 
    {
        get => defaultGateway;
        set => defaultGateway = value;
    }

}

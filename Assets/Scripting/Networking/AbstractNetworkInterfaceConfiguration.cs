
using UnityEngine;

public abstract class AbstractNetworkInterfaceConfiguration<Inet> where Inet : InetAddress
{
    public abstract Inet Address { get; set; }
    public abstract Inet SubnetMask { get; set; }
    public abstract Inet DefaultGateway { get; set; }

}

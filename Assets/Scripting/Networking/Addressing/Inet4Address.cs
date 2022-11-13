
using System;

[Serializable]
public class Inet4Address : InetAddress
{

    [UnityEngine.SerializeField] private string address = "0.0.0.0";

    public override string Address
    {
        get => address;
        set
        {
            if (!Utility.ValidInet4Address(value))
                throw new InvalidAddressException("Esse endereço não é válido para Inet4Address.");

            address = value;
        }
    }

    public Inet4Address(string address)
    {
        Address = address;
    }

}

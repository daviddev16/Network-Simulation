using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultComputer : AbstractNetworkDevice
{
    public override void Initialize()
    {
        Name = gameObject.name;
        Debug.Log("Computador iniciado");
        NetworkInterfaces[0].PhysicalLink.Send(new DatagramPacket("hi"));
    }
}

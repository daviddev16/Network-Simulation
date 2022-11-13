
using UnityEngine;

public class DefaultPhysicalLink : AbstractPhysicalLink
{
    void Start() {}

    void Update() {}

    public override void OnDeviceConnected(AbstractNetworkDevice device) {}

    public override void OnDeviceDisconnected(AbstractNetworkDevice device) {}

    public override void Receive(DatagramPacket packet)
    {
        Debug.Log(NetworkInterface.Device.Name + " received a packet [" + packet.Data + "].");
    }
}

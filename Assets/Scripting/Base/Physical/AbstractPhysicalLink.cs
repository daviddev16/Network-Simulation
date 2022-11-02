
using UnityEngine;

[System.Serializable]
public abstract class AbstractPhysicalLink : MonoBehaviour
{
    private event OnLinkConnected OnLinkConnectedEvent;
    private event OnLinkConnected OnLinkDisconnectedEvent;

    [SerializeField] private AbstractNetworkInterface networkInterface;

    public AbstractNetworkInterface NetworkInterface
    {
        get => networkInterface;
        set => networkInterface ??= value;
    }

    /* esse atributo representa a conexão da outra máquina conectada a esse physicalLink */
    [SerializeField] private AbstractPhysicalLink other;

    [SerializeField] private Cable connectedCable;
    
    public AbstractPhysicalLink Other 
    {
        get => other;
        set => other = value;
    }

    public Cable ConnectedCable
    {
        get => connectedCable;
        set => connectedCable = value;
    }

    void Awake()
    {
        OnLinkConnectedEvent += OnDeviceConnected;
        OnLinkDisconnectedEvent += OnDeviceDisconnected;
    }
    public abstract void OnDeviceConnected(AbstractNetworkDevice device);
    public abstract void OnDeviceDisconnected(AbstractNetworkDevice device);
    
    public void Connect(AbstractPhysicalLink other, Cable connectedCable)
    {
        ConnectedCable = connectedCable;
        Connect(other);
    }

    public void Connect(AbstractPhysicalLink other)
    {
        Other = other;
        OnLinkConnectedEvent(Other.NetworkInterface.Device);
    }

    public void Disconnect()
    {
        ConnectedCable = null;
        OnLinkDisconnectedEvent(Other.NetworkInterface.Device);
        Other = null;
    }

    /*
     * send, receive signals
     */

    /*
    public void SendSignal()
    {
        if (PluggedDevice != null)
        {
            if (PluggedDevice is EthernetDataLinkPort)
            {
                DataLake.SpawnBit(this, PluggedDevice); 
                ((EthernetDataLinkPort)PluggedDevice).ReceiveSignal();
            }
        }
    }
    
    public void ReceiveSignal() 
    {
        Debug.Log("[" + Parent.MacAddress + "] Received something from [" + PluggedDevice.Parent.MacAddress + "].");

        if (PluggedDevice != null)
        {
            if (PluggedDevice is EthernetDataLinkPort)
            {
                ((EthernetDataLinkPort)PluggedDevice).SendSignal();
            }
        }
    }*/


}

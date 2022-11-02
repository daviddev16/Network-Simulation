
using UnityEngine;

[System.Serializable]
public abstract class AbstractNetworkInterface : MonoBehaviour
{
    [SerializeField] private string macAddress;
    public string MacAddress 
    { 
        get => macAddress; 
        set => macAddress ??= value;
    }

    [SerializeField] private AbstractPhysicalLink physicalLink;
    public AbstractPhysicalLink PhysicalLink 
    { 
        get => physicalLink;
        set => physicalLink ??= value;
    }

    [SerializeField] private AbstractNetworkDevice networkDevice;

    public AbstractNetworkDevice Device
    {
        get => networkDevice;
        private set => networkDevice = value;
    }
    
    public void Attach(AbstractNetworkDevice networkDevice)
    {
        Device = networkDevice;
    }

    private void Start()
    {
        if (PhysicalLink != null)
        {
            PhysicalLink.NetworkInterface = this;
            return;
        }

        Debug.LogWarning("Não há link fisco para essa interface.");
        enabled = false;
    }

}

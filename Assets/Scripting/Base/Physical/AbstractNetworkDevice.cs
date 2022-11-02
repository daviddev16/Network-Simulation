
using System.Collections.Generic;
using UnityEngine;


/* todo dispositivo dentro do jogo que tenha conexão com rede*/
public abstract class AbstractNetworkDevice : AbstractHardware
{

    [SerializeField] private List<AbstractNetworkInterface> networkInterfaces;
    public List<AbstractNetworkInterface> NetworkInterfaces
    {
        get => networkInterfaces;
        private set => networkInterfaces ??= value;
    }

    void Awake()
    {
        RegisterAllNetworkInterfaces();
    }

    private void RegisterAllNetworkInterfaces()
    {
        foreach (AbstractNetworkInterface networkInterface in GetComponents<AbstractNetworkInterface>())
        {
            RegisterNetworkInterface(networkInterface);
        }
    }

    public void RegisterNetworkInterface(AbstractNetworkInterface networkInterface)
    {
        if (networkInterface != null && !NetworkInterfaces.Contains(networkInterface))
        {
            NetworkInterfaces.Add(networkInterface);
            networkInterface.Attach(this);
        }
    }

}

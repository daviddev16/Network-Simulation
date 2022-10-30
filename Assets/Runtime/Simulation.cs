using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simulation : MonoBehaviour
{

    public ComputerDevice computerDevice1;
    public ComputerDevice computerDevice2;

    void Start()
    {
        initState();
    }

    void Update()
    {
        
    }

    public void initState()
    {
        List<TestNetworkInterface> netIntC1 = computerDevice1.NetworkInterfaces;
        netIntC1[0].DataLinkPort.PluggedDevice = computerDevice2.NetworkInterfaces[0].DataLinkPort;

        List<TestNetworkInterface> netIntC2 = computerDevice2.NetworkInterfaces;
        netIntC2[0].DataLinkPort.PluggedDevice = computerDevice1.NetworkInterfaces[0].DataLinkPort;

        /* plugando cabo de rede no computador  */

        computerDevice1.Initialize();
        computerDevice2.Initialize();
    }
}

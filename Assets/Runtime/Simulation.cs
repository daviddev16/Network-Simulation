using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simulation : MonoBehaviour
{

    public ComputerDevice computerDevice1;
    public ComputerDevice computerDevice2;

    void Start()
    {

     
        List<TestNetworkInterface> netIntC1 = computerDevice1.NetworkInterfaces;
        netIntC1[0].DataLinkPorts[0].PluggedDevice = computerDevice2.NetworkInterfaces[0].DataLinkPorts[0];

        List<TestNetworkInterface> netIntC2 = computerDevice2.NetworkInterfaces;
        netIntC2[0].DataLinkPorts[0].PluggedDevice = computerDevice1.NetworkInterfaces[0].DataLinkPorts[0];

        /* plugando cabo de rede no computador  */

        computerDevice1.Initialize();
        computerDevice2.Initialize();


    }

    void Update()
    {
        
    }
}

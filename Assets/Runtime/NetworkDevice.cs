using System.Collections.Generic;

/* todo dispositivo que tem interfaces de rede */
public interface NetworkDevice
{
    List<TestNetworkInterface> NetworkInterfaces { get; set; }
}

using System.Collections.Generic;

public interface NetworkDevice
{
    List<TestNetworkInterface> NetworkInterfaces { get; set; }
}

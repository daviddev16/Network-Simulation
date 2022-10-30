using System.Collections.Generic;

public interface NetworkDevice
{
    public HashSet<NetworkInterface> NetworkInterfaces { get; set; }
}

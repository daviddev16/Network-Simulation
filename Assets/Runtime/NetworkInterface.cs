using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface NetworkInterface
{
    string MacAddress { get; set; }
    List<EthernetDataLinkPort> DataLinkPorts { get; set; }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface DataLinkPort
{
    /* conexão de outro dispositivo */
    DataLinkPort PluggedDevice { get; set; }
    NetworkInterface Parent { get; set;  }

}

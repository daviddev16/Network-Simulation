using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface DataLinkPort
{
    /* conex�o de outro dispositivo */
    DataLinkPort PluggedDevice { get; set; }
    NetworkInterface Parent { get; set;  }

}

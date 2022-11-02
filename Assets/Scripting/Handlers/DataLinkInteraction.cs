using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AbstractPhysicalLink))]
public class DataLinkInteraction : MonoBehaviour
{

    public bool dragging = false;

    public AbstractNetworkDevice ownerDevice;

    // Start is called before the first frame update
    void Start()
    {
        ownerDevice = GetComponentInParent<AbstractNetworkDevice>();
    }

    // Update is called once per frame
    void Update()
    {

       
    }
}

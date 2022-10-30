using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerDevice : BaseNetworkDevice
{
    public override void Initialize()
    {
        foreach(TestNetworkInterface netInt in NetworkInterfaces)
        {
            netInt.DataLinkPort.SendSignal();
        }
    }

    new void Awake()
    {
        base.Awake();
    }

    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataLake : MonoBehaviour
{

    public static DataLake dataLakeInstance;

    public GameObject dataBitPrefab;
    // Start is called before the first frame update
    void Start()
    {
        dataLakeInstance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static DataBitAnimation SpawnBit(AbstractPhysicalLink start, AbstractPhysicalLink end)
    {
        DataBitAnimation bit = Instantiate(dataLakeInstance.dataBitPrefab, Vector3.zero, Quaternion.identity, dataLakeInstance.transform).GetComponent<DataBitAnimation>();
        bit.start = ((AbstractPhysicalLink)start).transform;
        bit.end = ((AbstractPhysicalLink)end).transform;
        return bit;
    }
}

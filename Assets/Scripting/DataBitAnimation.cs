using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBitAnimation : MonoBehaviour
{

    public Transform end;
    public Transform start;
    void Start()
    {
        transform.position = start.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, end.position) <= 0.005f)
        {
            Destroy(gameObject);
        }
        transform.position = Vector3.Lerp(transform.position, end.position, Time.deltaTime * 5f);
    }
}

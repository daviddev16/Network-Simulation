using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*TODO: refatorar depois */
public class CableManager : MonoBehaviour
{

    public bool isClickedOver = false;
    public bool isDragging = false;


    public GameObject cablePrefab;

    public Cable currentTrackedCable;

    public GameObject datalinkSelected;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && currentTrackedCable == null)
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            var hits = Physics2D.GetRayIntersectionAll(ray, 10f);

            foreach (var hit in hits)
            {
                if (hit.collider.gameObject.GetComponent<DataLinkPort>() != null)
                {
                    if (hit.collider.gameObject.GetComponent<DataLinkPort>().PluggedDevice != null) 
                    {
                        continue;
                    }
                    datalinkSelected = hit.collider.gameObject;
                    isClickedOver = true;
                    return;
                }
            }
        }

        if (isClickedOver && Input.GetMouseButton(0))
        {
            isDragging = true;
        }
        else
        {
            isDragging = false;
        }

        if (isDragging && currentTrackedCable == null && datalinkSelected != null)
        {
            currentTrackedCable = Instantiate(cablePrefab, Vector3.zero, Quaternion.identity, transform).GetComponent<Cable>();
            currentTrackedCable.start.position = datalinkSelected.transform.position;
        }

        if (currentTrackedCable != null)
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0;
            currentTrackedCable.end.position = pos;
            if(!currentTrackedCable.GetComponent<LineRenderer>().enabled)
            {
                currentTrackedCable.GetComponent<LineRenderer>().enabled = true;
            }
        }

        if (!isDragging)
        {

            if(currentTrackedCable != null && datalinkSelected != null)
            {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                var hits = Physics2D.GetRayIntersectionAll(ray, 10f);
                /* tentar conectar */
                foreach (var hit in hits)
                {
                    if (hit.collider.gameObject.GetComponent<DataLinkPort>() != null && hit.collider.gameObject != datalinkSelected.gameObject)
                    {

                        GameObject newLink = hit.collider.gameObject;

                        if (newLink.GetComponent<DataLinkPort>().PluggedDevice != null)
                        {
                            continue;
                        }

                        Cable newCable = Instantiate(cablePrefab, Vector3.zero, Quaternion.identity, transform).GetComponent<Cable>();
                        newCable.GetComponent<LineRenderer>().enabled = true;
                        newCable.start = datalinkSelected.gameObject.transform;
                        newCable.end = newLink.transform;
                        newCable.b1 = false;

                        EthernetDataLinkPort dt1 = newLink.GetComponent<EthernetDataLinkPort>();
                        EthernetDataLinkPort dt2 = datalinkSelected.GetComponent<EthernetDataLinkPort>();

                        dt1.PluggedDevice = dt2;
                        dt2.PluggedDevice = dt1;

                        isClickedOver = false;
                        datalinkSelected = null;

                        break;
                    }
                }

            }

            if (currentTrackedCable != null)
            {
                Destroy(currentTrackedCable.gameObject);
            }
                datalinkSelected = null;
        }
    }
}

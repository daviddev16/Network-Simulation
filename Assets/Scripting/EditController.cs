using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditController : MonoBehaviour
{

    private CameraController cameraController;

    public bool IsDragging;
    public GameObject draggedObject;

    void Start()
    {
        cameraController = FindObjectOfType<CameraController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            var hits = Physics2D.GetRayIntersectionAll(ray, 10f);

            foreach (var hit in hits)
            {
                if (hit.collider.GetComponent<DataLinkInteraction>() != null) break;

                AbstractNetworkDevice device = hit.collider.GetComponent<AbstractNetworkDevice>();
                if (device != null)
                {
                    IsDragging = true;
                    draggedObject = device.gameObject;
                    break;
                }
            }
            
        }

        if (Input.GetMouseButtonUp(0))
        {
            IsDragging = false;
            draggedObject = null;
        }


        if (Input.GetMouseButton(0) && IsDragging && draggedObject != null)
        {
            Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            newPos.z = 0f;
            draggedObject.transform.position = newPos;
        }
    }
}

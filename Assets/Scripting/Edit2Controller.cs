using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* dragging datalinkport */
public class Edit2Controller : MonoBehaviour
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
        if (!Input.GetKey(KeyCode.LeftShift))
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            var hits = Physics2D.GetRayIntersectionAll(ray, 10f);

            foreach (var hit in hits)
            {
                DataLinkInteraction link = hit.collider.GetComponent<DataLinkInteraction>();
                if (link != null)
                {
                    IsDragging = true;
                    draggedObject = link.gameObject;
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
            newPos.z = 0;

            BoxCollider2D collider2D = draggedObject.GetComponentInParent<Test>().GetComponent<BoxCollider2D>();

            if (newPos.x > collider2D.bounds.max.x)
            {
                newPos.x = collider2D.bounds.max.x;
            }

            if (newPos.x < collider2D.bounds.min.x)
            {
                newPos.x = collider2D.bounds.min.x;
            }

            if (newPos.y > collider2D.bounds.max.y)
            {
                newPos.y = collider2D.bounds.max.y;
            }

            if (newPos.y < collider2D.bounds.min.y)
            {
                newPos.y = collider2D.bounds.min.y;
            }

            newPos.z = 0f;
            draggedObject.transform.position = newPos;
        }
    }
}

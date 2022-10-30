using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraController : MonoBehaviour
{

    [SerializeField] private float MinZoom = 0.5f;
    [SerializeField] private float MaxZoom = 10f;
    [SerializeField] private float ZoomAmount = 0.2f;

    private Camera CurrentCamera;

    private Vector3 DraggingPos;
    
    private bool IsDragging;
    
    public float ZoomValue = 4;

    private void Start()
    {
        CurrentCamera = GetComponent<Camera>();
    }

    void Update()
    {
        Panning();
        Zooming();
    }

    private void Zooming()
    {
        if (Input.mouseScrollDelta.y >= 1f)
        {
            ZoomValue = Utility.Clamp(ZoomValue - ZoomAmount, MinZoom, MaxZoom);

        }
        else if (Input.mouseScrollDelta.y <= -1f)
        {
            ZoomValue = Utility.Clamp(ZoomValue + ZoomAmount, MinZoom, MaxZoom);
        }

        CurrentCamera.orthographicSize = ZoomValue;
    }

    private void Panning()
    {
        if (!Input.GetKey(KeyCode.LeftControl))
        {
            IsDragging = false;
            return;
        }

        if (EventSystem.current.IsPointerOverGameObject() || enabled == false)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            DraggingPos = CurrentCamera.ScreenToWorldPoint(Input.mousePosition);
            IsDragging = true;
        }

        if (Input.GetMouseButton(0) && IsDragging)
        {
            Vector3 diff = DraggingPos - CurrentCamera.ScreenToWorldPoint(Input.mousePosition);
            diff.z = 0.0f;
            CurrentCamera.transform.position += diff;
        }

        if (Input.GetMouseButtonUp(0))
        {
            IsDragging = false;
        }
    }
}
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour
{

    public static CameraController Instance { get; private set; }

    [SerializeField] private Camera attachedCamera;

    [SerializeField] private float minZoon = 0.5f;
    [SerializeField] private float maxZoom = 10f;
    [SerializeField] private float zoomAmount = 0.2f;
    
    [SerializeField] private Vector3 draggingPos;
    [SerializeField] private bool isDragging;
    [SerializeField] private float zoomValue = 4;

    public static Camera Camera { get => Instance.attachedCamera; }
    
    void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);
        
        attachedCamera = GetComponent<Camera>();
        Instance = this;
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
            zoomValue = Utility.Clamp(zoomValue - zoomAmount, minZoon, maxZoom);

        }
        else if (Input.mouseScrollDelta.y <= -1f)
        {
            zoomValue = Utility.Clamp(zoomValue + zoomAmount, minZoon, maxZoom);
        }

        attachedCamera.orthographicSize = zoomValue;
    }

    private void Panning()
    {
        if (!Input.GetKey(KeyCode.LeftControl))
        {
            isDragging = false;
            return;
        }

        if (EventSystem.current.IsPointerOverGameObject() || enabled == false)
        {
            return;
        }

        CheckIsDragging();

        if (Input.GetMouseButton(0) && isDragging)
        {
            Vector3 nextPosition = draggingPos - attachedCamera.ScreenToWorldPoint(Input.mousePosition);
            nextPosition.z = 0.0f;
            transform.position += nextPosition;
        }
       
    }

    private void CheckIsDragging()
    {
        if (Input.GetMouseButtonDown(0))
        {
            draggingPos = attachedCamera.ScreenToWorldPoint(Input.mousePosition);
            isDragging = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }
    }
}
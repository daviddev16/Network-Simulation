
using UnityEngine;

public class MoveController : MonoBehaviour
{

    public static MoveController Instance { get; private set; }

    [SerializeField] public bool isDragging;
    [SerializeField] public AbstractNetworkDevice networkDevice;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        Instance = this;
    }

    void Update()
    {
        /* verificar se um physicallink não está sendo movindo antes */
        if (LinkMoveController.Instance.IsDragging)
            return;

        CheckIsDraggingADevice();
        UpdateDevicePosition();
    }

    private void CheckIsDraggingADevice()
    {
        if (Input.GetMouseButtonDown(0))
        {
            networkDevice = Utility.FindNetworkDeviceOnScreen();

            if (networkDevice == null)
                return;

            isDragging = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            networkDevice = null;
        }
    }

    private void UpdateDevicePosition()
    {
        if (Input.GetMouseButton(0) && isDragging && networkDevice != null)
        {
            Vector3 worldPosition = Utility.GetMouseWorldPosition();
            networkDevice.transform.position = worldPosition;
        }
    }
}

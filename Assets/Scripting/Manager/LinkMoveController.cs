using UnityEngine;

public class LinkMoveController : MonoBehaviour
{

    public static LinkMoveController Instance { get; private set; }

    [SerializeField] private bool isDragging;
    [SerializeField] private AbstractPhysicalLink physicalLink;
    public bool IsDragging { get => isDragging; }

    void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);
        
        Instance = this;
    }

    void Update()
    {
        if (!Input.GetKey(KeyCode.LeftShift) || Input.GetMouseButtonUp(0))
        {
            ClearSelection();
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            physicalLink = Utility.FindPhysicalLinkOnScreen();

            if (physicalLink != null)
            {
                isDragging = true;
            }
        }

        if (Input.GetMouseButton(0) && isDragging && physicalLink != null)
        {
            Vector3 worldPosition = Utility.GetMouseWorldPosition();

            BoxCollider2D collider = physicalLink.GetComponentInParent<LinkBoundsHandler>()
                .GetComponent<BoxCollider2D>();

            physicalLink.transform.position = ApplyBounds(ref worldPosition, collider.bounds);
        }

    }

    private Vector3 ApplyBounds(ref Vector3 position, Bounds bounds)
    {
        position.x = Mathf.Clamp(position.x, bounds.min.x, bounds.max.x);
        position.y = Mathf.Clamp(position.y, bounds.min.y, bounds.max.y);
        return position;
    }

    private void ClearSelection()
    {
        isDragging = false;
        physicalLink = null;
    }

}

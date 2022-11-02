using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Cable : MonoBehaviour
{

    [SerializeField] public Transform start;
    [SerializeField] public Transform end;
    [SerializeField] private LineRenderer lineRenderer;

    public Transform StartLocation
    {
        get => start;
        set => start = value;
    }
    public Transform EndLocation
    {
        get => end;
        set => end = value;
    }

    private Vector3[] positions = new Vector3[2];
    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
    }
    void Update()
    {
        positions[0] = start.position;
        positions[1] = end.position;
        lineRenderer.SetPositions(positions);
    }

    public void Show() 
        => lineRenderer.enabled = true;

    public void Hide() 
        => lineRenderer.enabled = false;

    public void Disconnect() => Destroy(gameObject);

}

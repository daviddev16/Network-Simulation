using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


[ExecuteInEditMode]
[RequireComponent(typeof(LineRenderer))]
public class Cable : MonoBehaviour
{

    public Transform start;
    public Transform end;

    private Vector3[] positions = new Vector3[4];

    private LineRenderer lineRenderer;

    [SerializeField] public bool b0;
    [SerializeField] public bool b1;

    private Vector3 endDiff;
    private Vector3 diff;

    void Start() 
    {
        endDiff = new Vector3(end.position.x, end.position.y, 0);
    }

    void Update()
    {
        if (lineRenderer == null)
            lineRenderer = GetComponent<LineRenderer>();

        positions[0] = start.position;
        positions[1] = start.position + (b0 ? Vector3.right :  Vector3.left) * 0.1f;

        positions[2] = end.position - (b1 ? Vector3.right : Vector3.left) * 0.1f;
        positions[3] = end.position;

        lineRenderer.positionCount = 4;
        lineRenderer.SetPositions(positions);

        if (diff.x < 0.01)
        {
            b1 = false;
        }
        else
        {
            b1 = true;
        }

    }

    private void FixedUpdate()
    {
        diff = end.position - endDiff;
        //Debug.Log(diff.x);
    }

}

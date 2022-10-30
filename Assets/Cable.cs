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

    [SerializeField] private bool b0;
    [SerializeField] private bool b1;


    void Start() { }

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



    }

}

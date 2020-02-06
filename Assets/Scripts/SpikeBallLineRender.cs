using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBallLineRender : MonoBehaviour
{
    private LineRenderer lineRenderer;
    public Transform startPoint;
    public Transform endPoint;
  
    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        lineRenderer.SetPosition(0, startPoint.position);
        lineRenderer.SetPosition(1, endPoint.position);
    }
}

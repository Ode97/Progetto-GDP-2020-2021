using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDraw : MonoBehaviour
{
    private LineRenderer _lineRenderer;
    public float range = 3f;
    public LayerMask layerMask;

    private Camera _mainCamera;
    private bool _inRange;
    private Vector3 _lastPosition;
    private Vector3 _firstPosition;

    void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.startWidth = 0.02f;
        _lineRenderer.endWidth = 0.02f; //thickness of line
        _lineRenderer.positionCount = 2;
        _mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitData;

        if(Physics.Raycast(ray, out hitData, 1000, layerMask))
        {
            var pos = hitData.point;
            pos = transform.InverseTransformPoint(pos);
            _firstPosition = transform.position;
            _lineRenderer.SetPosition(0, transform.localPosition);
            if (Mathf.Abs(Vector3.Distance(pos, transform.localPosition)) > range)
            {
                var dx = pos.x - transform.localPosition.x;
                var dz = pos.z - transform.localPosition.z;
                var theta = Mathf.Atan2(dz, dx);
                pos.x = range * Mathf.Cos(theta);
                pos.z = range * Mathf.Sin(theta);
                _inRange = false;
            }
            else
                _inRange = true;

            _lastPosition = pos;
            _lineRenderer.SetPosition(1, pos);
        }
    }

    public void ChangeRange(float r)
    {
        range = r;
    }
    
    public bool IsInRange()
    {
        return _inRange;
    }

    public Vector3 GetFirstPosition()
    {
        return _firstPosition;
    }
    public Vector3 GetLastPosition()
    {
        return transform.TransformPoint(_lastPosition);
    }
}

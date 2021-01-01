using UnityEngine;
using System.Collections;

public class CircleDraw : MonoBehaviour {   
  public float thetaScale = 0.01f;        //Set lower to add more points
  private int _size; //Total number of points in circle
  public float radius = 3f;
  private LineRenderer _lineRenderer;

  void Awake () {       
    float sizeValue = (2.0f * Mathf.PI) / thetaScale; 
    _size = (int)sizeValue;
    _size++;
    _lineRenderer = GetComponent<LineRenderer>();
    //_lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
    _lineRenderer.startWidth = 0.02f;
    _lineRenderer.endWidth = 0.02f; //thickness of line
    _lineRenderer.positionCount = _size;      
  }

  void Update () {      
    Vector3 pos;
    float theta = 0f;
    for(int i = 0; i < _size; i++){          
      theta += (2.0f * Mathf.PI * thetaScale);         
      float x = radius * Mathf.Cos(theta);
      float z = radius * Mathf.Sin(theta);          
      x += gameObject.transform.localPosition.x;
      z += gameObject.transform.localPosition.y;
      pos = new Vector3(x, 0, z);
      _lineRenderer.SetPosition(i, pos);
    }
  }

  public void ChangeRadius(float r)
  {
    radius = r;
  }
}
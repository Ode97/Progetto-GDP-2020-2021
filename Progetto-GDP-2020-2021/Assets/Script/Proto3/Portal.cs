using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private Vector3 _destination;

    private void Awake()
    {
        _destination = transform.GetChild(0).position;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered " + other.name);
        if (other.CompareTag("Player"))
        {
            other.transform.position = _destination;
        }
    }
}

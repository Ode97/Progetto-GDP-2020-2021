using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeTrigger : MonoBehaviour
{
    [SerializeField] private GameObject objectToActivate;
    [SerializeField] private bool destroyOnPlace = false;
    [SerializeField] private GameObject next;
    [SerializeField] string tag = "Box";
    
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(tag))
        {
            if (!other.GetComponent<ObjectProperties>().hold)
            {
                objectToActivate.SetActive(true);
                if (destroyOnPlace)
                {
                    if(tag!="Player")
                        Destroy(other.gameObject);
                    Destroy(this);
                }

                if (next)
                {
                    next.SetActive(true);
                }
            }
            else
            {
                objectToActivate.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(tag))
        {
            objectToActivate.SetActive(false);
        }
    }
}

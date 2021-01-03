using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeTrigger : MonoBehaviour
{
    [SerializeField] private GameObject objectToActivate;
    [SerializeField] private bool destroyOnPlace = false;
    [SerializeField] private GameObject next;
    
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Box"))
        {
            if (!other.GetComponent<ObjectProperties>().hold)
            {
                objectToActivate.SetActive(true);
                if (destroyOnPlace)
                {
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

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Box"))
        {
            objectToActivate.SetActive(false);
        }
    }
}

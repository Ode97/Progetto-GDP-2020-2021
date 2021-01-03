using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pietrificus : MonoBehaviour
{
    [SerializeField] private GameObject collectable;
    private bool castSpell = false;

    public bool CastSpell
    {
        set => castSpell = value;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (castSpell && other.CompareTag("Chicken"))
        {
            other.GetComponent<Animator>().speed = 0;
            collectable.SetActive(true);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pietrificus : MonoBehaviour
{

    private bool castSpell = false;

    public bool CastSpell
    {
        set => castSpell = value;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (castSpell && other.CompareTag("Box"))
        {
            other.GetComponent<Animator>().speed = 0;
        }
    }
}

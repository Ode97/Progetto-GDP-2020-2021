using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{

    [SerializeField] private float movmentSpeed = 50;
    void Update()
    {
        
        if(Input.GetAxis("Vertical") != 0)
        {
            transform.position += transform.forward * Time.deltaTime * movmentSpeed * Input.GetAxis("Vertical");
        }

        if(Input.GetAxis("Horizontal") != 0)
        {
            transform.position += transform.right * Time.deltaTime * movmentSpeed * Input.GetAxis("Horizontal");
        }
    }
}

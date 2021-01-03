using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waterfall : MonoBehaviour
{
    [SerializeField] private GameObject door;
    [SerializeField] private GameObject[] gos;
    
    void Start()
    {
        EventManager.StartListening("startNiagara", StartNiagara);
    }

    public void StartNiagara()
    {
        if (!door.activeSelf)
        {
            foreach (var go in gos)
            {
                go.SetActive(!go.activeSelf);
            }
            EventManager.StopListening("startNiagara", StartNiagara);
        }
        
    }
}

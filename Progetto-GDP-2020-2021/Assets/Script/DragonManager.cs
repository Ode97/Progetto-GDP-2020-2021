using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DragonManager : MonoBehaviour
{

    [SerializeField] private LevelManager levelManager;
    [SerializeField] private DragonManager[] dragons;
    private MeshRenderer meshRenderer;
    private bool on = false;

    public bool On{
        get
        { 
            return on;
        }
    }

    void Awake(){
        meshRenderer = GetComponent<MeshRenderer>();
    }
    void OnMouseDown(){
       foreach (DragonManager dm in dragons)
       {
           dm.ChangeColor();
       }
       levelManager.enigmaChecker.WinnerCheck();
    }       

    public void ChangeColor(){
        on = !on;
        if (on)
            meshRenderer.material.color = levelManager.on;
        else    
            meshRenderer.material.color = levelManager.off;

    }
}

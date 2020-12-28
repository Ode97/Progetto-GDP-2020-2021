using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class DragonManager : MonoBehaviour
{

    [FormerlySerializedAs("levelManager")] [SerializeField] private StatueColors statueColors;
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
       EventManager.TriggerEvent("OnStatueChange");
       //levelManager.enigmaChecker.WinnerCheck();
    }       

    public void ChangeColor(){
        on = !on;
        if (on)
            meshRenderer.material.color = statueColors.on;
        else    
            meshRenderer.material.color = statueColors.off;

    }
}

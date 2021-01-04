using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class DragonManager : MonoBehaviour
{

    [FormerlySerializedAs("levelManager")] [SerializeField] private StatueColors statueColors;
    [SerializeField] private DragonManager[] dragons_on;
    [SerializeField] private DragonManager[] dragons_off;

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
        if(on)
            foreach (DragonManager dm in dragons_on)
            {
               dm.ChangeColor();
            }
        else{
            foreach (DragonManager dm in dragons_off)
            {
               dm.ChangeColor();
            }
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

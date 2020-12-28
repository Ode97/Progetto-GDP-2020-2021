using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class EnigmaChecker : MonoBehaviour
{
    [SerializeField] private DragonManager[] dragonManager;
    [FormerlySerializedAs("levelManager")] [SerializeField] private StatueColors statueColors;
    [SerializeField] private Text text;

    void Start(){
        //levelManager.enigmaChecker = this;
        EventManager.StartListening("OnStatueChange", WinnerCheck);
    }
    public void WinnerCheck()
    {
        bool check = true;
        foreach (DragonManager dm in dragonManager)
        {
            check &= dm.On;
        }
        if (check)
            text.text = "SOLVED";
        else
            text.text = "FAIL";
    }
}

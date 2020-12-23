using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnigmaChecker : MonoBehaviour
{
    [SerializeField] private DragonManager[] dragonManager;
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private Text text;

    void Start(){
        levelManager.enigmaChecker = this;
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

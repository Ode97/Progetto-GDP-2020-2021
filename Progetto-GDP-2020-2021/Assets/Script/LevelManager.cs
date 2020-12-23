using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelManager", menuName = "Manager/LevelManager", order = 1)]
public class LevelManager : ScriptableObject

{

    public EnigmaChecker enigmaChecker;
    public Color on;
    public Color off;
}

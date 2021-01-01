using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Spell", menuName = "Player/Spell", order = 1)]
public class Spell : ScriptableObject
{
    public string name;
    public float range;
    public string[] tags;
}

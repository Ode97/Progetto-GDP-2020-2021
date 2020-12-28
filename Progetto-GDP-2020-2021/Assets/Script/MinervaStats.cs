using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MinervaStats", menuName = "Player/MinervaStats", order = 1)]

public class MinervaStats : ScriptableObject
{
  public int strenght;
  public int constitution;
  public int intelligence;
  public int wisdom;
  public int charisma;
  public int dexterity;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameConstants;

[CreateAssetMenu(fileName = "New ActionInfo", menuName = "Other SO/ActionInfo")]

public class ActionInfo : ScriptableObject
{
    public CommandID commandID;
    public int value = 20;
}

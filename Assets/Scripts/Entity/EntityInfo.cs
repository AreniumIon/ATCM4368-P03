using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameConstants;

public abstract class EntityInfo : ScriptableObject
{
    public new string name;
    public EntityType entityType;
}
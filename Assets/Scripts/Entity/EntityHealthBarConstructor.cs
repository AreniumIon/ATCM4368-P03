using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameConstants;
using System;

public static class EntityHealthBarConstructor
{
    static GameObject healthBarPrefab = Resources.Load<GameObject>("Prefabs/Health Bar");

    public static GameObject CreateHealthBar(Attackable attackable, Transform parent)
    {
        GameObject newHealthBar = GameObject.Instantiate(healthBarPrefab, parent, false);
        EntityHealthBar ehb = newHealthBar.GetComponent<EntityHealthBar>();

        ehb.SetParams(attackable);

        return newHealthBar;
    }
}

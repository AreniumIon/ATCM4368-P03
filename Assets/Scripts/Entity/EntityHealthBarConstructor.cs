using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameConstants;
using System;

public static class EntityHealthBarConstructor
{
    static GameObject healthBarPrefab = Resources.Load<GameObject>("Prefabs/Health Bar");

    static Vector2 healthBarOffset = new Vector2(0f, -100f);

    public static GameObject CreateHealthBar(Attackable attackable, Transform parent)
    {
        GameObject newHealthBar = GameObject.Instantiate(healthBarPrefab, parent, false);
        EntityHealthBar ehb = newHealthBar.GetComponent<EntityHealthBar>();

        newHealthBar.transform.Translate(healthBarOffset);

        ehb.SetParams(attackable);

        return newHealthBar;
    }
}

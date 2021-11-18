using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameConstants;
using System;

public static class FoeConstructor
{
    static GameObject foePrefab = Resources.Load<GameObject>("Prefabs/Foe");

    static Dictionary<FoeID, FoeInfo> foeDict = new Dictionary<FoeID, FoeInfo>()
    {
        {FoeID.Spikeder, Resources.Load<FoeInfo>("GameData/Data/FoeInfo/Spikeder")},
        //{FoeID.Hambiter, Resources.Load<FoeInfo>("GameData/Data/FoeInfo/Hambiter")},
        //{FoeID.Venus_Fly_Trap, Resources.Load<FoeInfo>("GameData/Data/FoeInfo/Venus_Fly_Trap")},
    };

    public static GameObject CreateFoe(FoeID newFoeID, Transform parent, Vector3 position)
    {
        GameObject newFoe = GameObject.Instantiate(foePrefab);

        // Transform
        TransformFunctions.SetTransform(newFoe.transform, position);
        if (parent != null)
            newFoe.transform.SetParent(parent);

        // Foe
        FoeMan fm = newFoe.GetComponent<FoeMan>();
        fm.SetParams(foeDict[newFoeID]);

        // Events
        CreateFoeEvent(fm);

        return newFoe;
    }

    // Events
    public static event Action<FoeMan> createFoeEvent;
    public static void CreateFoeEvent(FoeMan newFoe)
    {
        if (createFoeEvent != null)
            createFoeEvent(newFoe);
    }

    public static void ClearEvents()
    {
        createFoeEvent = null;
    }
}

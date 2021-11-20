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

    public static GameObject CreateFoe(FoeID newFoeID, Transform parent)
    {
        GameObject newFoe = GameObject.Instantiate(foePrefab, parent, false);
        FoeMan fm = newFoe.GetComponent<FoeMan>();
        FoeInfo foeInfo = foeDict[newFoeID];

        // Model
        GameObject modelPrefab = foeInfo.model;
        GameObject.Instantiate(modelPrefab, newFoe.transform);

        // Health Bar
        EntityHealthBarConstructor.CreateHealthBar(fm.FoeHealth, newFoe.transform);

        // Foe
        fm.SetParams(foeInfo);

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

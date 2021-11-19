using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameConstants;

[CreateAssetMenu(fileName = "New FoeInfo", menuName = "EntityInfo/FoeInfo")]
public class FoeInfo : EntityInfo
{
    public FoeInfo()
    {
        entityType = EntityType.Foe;
    }

    public FoeID foeID;
    public GameObject model;

    public int health = 20;
    //public List<FoeAction>
}

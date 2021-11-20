using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressionMan : MonoBehaviour
{
    [SerializeField] List<FoeInfo> foes = new List<FoeInfo>();

    int battleIndex = -1;

    private void Start()
    {
        
    }

    public void AdvanceBattle()
    {
        battleIndex++;
    }

    public bool HasCurrentFoe()
    {
        return foes.Count > battleIndex;
    }

    public FoeInfo GetCurrentFoe()
    {
        return foes[battleIndex];
    }
}

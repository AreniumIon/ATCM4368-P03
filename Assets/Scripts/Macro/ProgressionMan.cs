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

    public bool HasNextFoe()
    {
        return foes.Count > battleIndex + 1;
    }

    public FoeInfo GetCurrentFoe()
    {
        return foes[battleIndex];
    }
}

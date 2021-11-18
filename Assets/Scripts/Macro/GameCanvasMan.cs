using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCanvasMan : MonoBehaviour
{
    public static GameCanvasMan i;

    public GameObject PlayerCanvas;

    public GameObject FoeCanvas;

    public void Awake()
    {
        if (i == null)
        {
            i = this;
        }
        else
        {
            Destroy(this);
        }
    }
}

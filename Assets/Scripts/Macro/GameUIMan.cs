using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIMan : MonoBehaviour
{
    public GameCamera GameCamera;

    public PlayerUI PlayerUI;
    public PlayerTurnUI PlayerTurnUI;

    public FoeUI FoeUI;
    public FoeTurnUI FoeTurnUI;

    public WinScreenUI WinScreenUI;
    public LoseScreenUI LoseScreenUI;

    private void Awake()
    {
        ServiceLocator.Register<GameUIMan>(this);
    }

    private void Start()
    {
        
    }
}

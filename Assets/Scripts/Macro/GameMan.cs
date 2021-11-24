using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameConstants;

public class GameMan : MonoBehaviour
{
    public PlayerMan PlayerMan;
    public FoeMan FoeMan;

    public TokenGameSM CardGameSM;
    public StateTracker StateTracker;

    public InputController InputController;
    public CommandStack CommandStack;
    public ProgressionMan ProgressionMan;
    
    private void Awake()
    {
        ServiceLocator.Register<GameMan>(this);
    }
}

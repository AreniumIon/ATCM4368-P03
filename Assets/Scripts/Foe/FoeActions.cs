using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameConstants;
using System;

public class FoeActions : MonoBehaviour
{
    FoeMan fm;

    List<ActionInfo> actions = new List<ActionInfo>();

    private ActionInfo nextAction;
    public ActionInfo NextAction
    { 
        get { return nextAction; }
        set { nextAction = value; ChangeNextActionEvent(nextAction); }
    }

    // Events
    public event Action<ActionInfo> doActionEvent; //actionInfo
    private void DoActionEvent(ActionInfo actionInfo)
    {
        doActionEvent?.Invoke(actionInfo);
    }

    public event Action<ActionInfo> changeNextActionEvent; //actionInfo
    private void ChangeNextActionEvent(ActionInfo actionInfo)
    {
        changeNextActionEvent?.Invoke(actionInfo);
    }


    public void SetParams(FoeMan fm)
    {
        this.fm = fm;

        actions = fm.foeInfo.actions;

        AdvanceNextAction();
    }

    public void DoAction()
    {
        // Get command
        ICommand command = CommandConstructor.CreateCommand(NextAction.commandID, NextAction.value, GetTarget(NextAction.commandID));

        ServiceLocator.GetService<GameMan>().CommandStack.ExecuteCommand(command);

        DoActionEvent(NextAction);

        AdvanceNextAction();
    }

    private void AdvanceNextAction()
    {
        int currentIndex = actions.IndexOf(NextAction);
        int advancedIndex = (currentIndex + 1) % actions.Count;

        ActionInfo action = actions[advancedIndex];

        NextAction = action;
    }

    private Attackable GetTarget(CommandID commandID)
    {
        GameMan gameMan = ServiceLocator.GetService<GameMan>();

        switch (commandID)
        {
            default:
            case CommandID.Attack:
                return gameMan.PlayerMan.PlayerHealth;
            case CommandID.Defend:
                return gameMan.FoeMan.FoeHealth;
            case CommandID.Heal:
                return gameMan.FoeMan.FoeHealth;
        }
    }
}

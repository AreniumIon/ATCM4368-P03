using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameConstants;
using System;

public class FoeActions : MonoBehaviour
{
    FoeMan fm;

    List<ActionInfo> actions = new List<ActionInfo>();

    public ActionInfo nextAction { get; private set; }

    // Events
    public event Action<ActionInfo> doActionEvent; //actionInfo
    private void DoActionEvent(ActionInfo actionInfo)
    {
        doActionEvent?.Invoke(actionInfo);
    }



    public void SetParams(FoeMan fm)
    {
        this.fm = fm;

        actions = fm.foeInfo.actions;

        AdvanceNextAction(null);

        // Events
        doActionEvent += AdvanceNextAction;
    }

    public void DoAction()
    {
        // Get command
        ICommand command = CommandConstructor.CreateCommand(nextAction.commandID, nextAction.value, GetTarget(nextAction.commandID));

        ServiceLocator.GetService<GameMan>().CommandStack.ExecuteCommand(command);

        DoActionEvent(nextAction);

    }

    // Subscribed to doActionEvent
    private void AdvanceNextAction(ActionInfo actionInfo)
    {
        int currentIndex = actions.IndexOf(nextAction);
        int advancedIndex = (currentIndex + 1) % actions.Count;

        ActionInfo action = actions[advancedIndex];

        nextAction = action;
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

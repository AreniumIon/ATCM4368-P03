using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameConstants;

public class FoeActions : MonoBehaviour
{
    FoeMan fm;

    List<ActionInfo> actions = new List<ActionInfo>();

    ActionInfo lastAction;

    public void SetParams(FoeMan fm)
    {
        this.fm = fm;

        actions = fm.foeInfo.actions;
    }

    public void DoNextAction()
    {
        // Get command
        ActionInfo actionInfo = GetNextAction();
        ICommand command = CommandConstructor.CreateCommand(actionInfo.commandID, actionInfo.value, GetTarget(actionInfo.commandID));

        ServiceLocator.GetService<GameMan>().CommandStack.ExecuteCommand(command);
        lastAction = actionInfo;
    }

    private ActionInfo GetNextAction()
    {
        int lastActionIndex = actions.IndexOf(lastAction);
        int nextActionIndex = (lastActionIndex + 1) % actions.Count;

        ActionInfo action = actions[nextActionIndex];

        return action;
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

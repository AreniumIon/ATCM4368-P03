using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameConstants;

public class FoeActions : MonoBehaviour
{
    FoeMan fm;

    List<ActionInfo> actions = new List<ActionInfo>();

    public void SetParams(FoeMan fm)
    {
        this.fm = fm;

        actions = fm.foeInfo.actions;
    }

    public void DoRandomAction()
    {
        // Get command
        ActionInfo actionInfo = GetRandomAction();
        ICommand command = CommandConstructor.CreateCommand(actionInfo.commandID, actionInfo.value, GetTarget(actionInfo.commandID));

        ServiceLocator.GetService<GameMan>().CommandStack.ExecuteCommand(command);
    }

    private ActionInfo GetRandomAction()
    {
        int choice = Random.Range(0, actions.Count);
        ActionInfo action = actions[choice];

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

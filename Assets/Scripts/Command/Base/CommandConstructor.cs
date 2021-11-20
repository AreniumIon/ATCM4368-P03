using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameConstants;

public static class CommandConstructor
{
    public static ICommand CreateCommand(CommandID commandID, int value, Attackable target)
    {
        switch (commandID)
        {
            default:
            case CommandID.Attack:
                return CreateAttack(target, value);
            case CommandID.Defend:
                return CreateDefend(target, value);
            case CommandID.Heal:
                return CreateHeal(target, value);
        }
    }

    private static ICommand CreateAttack(Attackable target, int value)
    {
        return new AttackCommand(target, value);
    }

    private static ICommand CreateDefend(Attackable target, int value)
    {
        return new DefendCommand(target, value);
    }

    private static ICommand CreateHeal(Attackable target, int value)
    {
        return new HealCommand(target, value);
    }
}

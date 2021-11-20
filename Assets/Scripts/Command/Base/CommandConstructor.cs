using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameConstants;

public static class CommandConstructor
{
    public static ICommand CreateCommand(TokenID tokenID, int value, Attackable target)
    {
        switch (tokenID)
        {
            default:
            case TokenID.Attack:
                return CreateAttack(target, value);
            case TokenID.Defend:
                return CreateDefend(target, value);
            case TokenID.Heal:
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

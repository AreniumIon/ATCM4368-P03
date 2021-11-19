using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealCommand : ICommand
{
    Attackable target;
    int amount;

    public HealCommand(Attackable target, int amount)
    {
        this.target = target;
        this.amount = amount;
    }

    public void Execute()
    {
        if (target != null)
        {
            target.Heal(amount);
        }
    }
}

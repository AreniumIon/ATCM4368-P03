using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefendCommand : ICommand
{
    Attackable target;
    int block;

    public DefendCommand(Attackable target, int block)
    {
        this.target = target;
        this.block = block;
    }

    public void Execute()
    {
        if (target != null)
        {
            target.Defend(block);
        }
    }
}

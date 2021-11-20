using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCommand : ICommand
{
    Attackable target;
    int damage;

    public AttackCommand(Attackable target, int damage)
    {
        this.target = target;
        this.damage = damage;
    }

    public void Execute()
    {
        if (target != null)
        {
            target.TakeDamage(damage);
        }
    }
}

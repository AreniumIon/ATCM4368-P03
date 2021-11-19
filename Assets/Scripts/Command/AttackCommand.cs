using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCommand : ICommand
{
    Attackable attacker;
    Attackable target;
    int damage;

    public AttackCommand(Attackable attacker, Attackable target, int damage)
    {
        this.attacker = attacker;
        this.target = target;
        this.damage = damage;
    }

    public void Execute()
    {
        if (attacker != null && target != null)
        {
            target.TakeDamage(damage);
        }
    }
}

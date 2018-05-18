﻿using UnityEngine.AI;
using Project.Game.Player;

public class FreezeAttack : Attack
{
    public override void AttackTarget()
    {
        base.AttackTarget();
        sight.target.GetComponent<PlayerEngine>().speed = 0;
    }
}

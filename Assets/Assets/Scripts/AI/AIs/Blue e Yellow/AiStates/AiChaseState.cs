using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiChaseState : AiBaseState
{
    public override void EnterState(AiStateManager ai)
    {

    }

    public override void UpdateState(AiStateManager ai)
    {
        ai.Body.AddForce((ai.Player.transform.position - ai.transform.position).normalized * ai.Speed);
        ai.transform.LookAt(ai.Player.transform);
        ai.EnemyWeapon.Shoot(ai.pooler);
    }
}
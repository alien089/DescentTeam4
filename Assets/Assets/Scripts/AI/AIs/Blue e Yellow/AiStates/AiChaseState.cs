using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiChaseState : AiBaseState
{

    public override void EnterState(AiStateManager ai)
    {

    }

    /// <summary>
    /// go in direction of player and shoot him
    /// </summary>
    /// <param name="ai"></param>
    public override void UpdateState(AiStateManager ai)
    {
        ai.Body.AddForce((ai.Player.transform.position - ai.transform.position).normalized * ai.Speed);
        ai.EnemyWeapon.Shoot();
    }
}

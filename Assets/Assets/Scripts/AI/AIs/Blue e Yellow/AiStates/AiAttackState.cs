using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiAttackState : AiBaseState
{
    public override void EnterState(AiStateManager ai)
    {
        ai.transform.position = (ai.transform.position - ai.Player.transform.position).normalized * ai.Radius + ai.Player.transform.position;
    }

    /// <summary>
    /// rotate around player
    /// </summary>
    /// <param name="ai"></param>
    public override void UpdateState(AiStateManager ai)
    {
        ai.transform.RotateAround(ai.Player.transform.position, Vector3.up, ai.RotationSpeed * Time.deltaTime);
        Vector3 nextPos = (ai.transform.position - ai.Player.transform.position).normalized * ai.Radius + ai.Player.transform.position;
        ai.transform.position = Vector3.MoveTowards(ai.transform.position, nextPos, Time.deltaTime * ai.RadiusSpeed);
        ai.transform.LookAt(ai.Player.transform);
        ai.EnemyWeapon.Shoot();
    }
}

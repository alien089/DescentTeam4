using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenDodgeState : GreenAiBaseState
{
    public override void EnterState(GreenAiManager ai)
    {

    }
    public override void UpdateState(GreenAiManager ai)
    {
        ai.transform.LookAt(ai.Player.transform);
        ai.Body.AddForce(Random.onUnitSphere * ai.Speed);
        //if (true)
        //{
        //    ai.StartCoroutine(MoveRandomDistance(ai));
        //}
    }
    private IEnumerator MoveRandomDistance(GreenAiManager ai)
    {
        yield return new WaitForFixedUpdate();
        ai.Body.AddForce(Random.onUnitSphere * ai.Speed);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenGoBack : GreenAiBaseState
{
    public override void EnterState(GreenAiManager ai)
    {

    }
    public override void UpdateState(GreenAiManager ai)
    {
        ai.Body.AddForce((ai.InitialPos - ai.transform.position).normalized * ai.Speed);
        
        if (ai.transform.position == ai.InitialPos)
        {
            ai.SwitchState(ai.SpawnState);
        }
    }
    public override void OnTriggerEnter(GreenAiManager ai, Collider other)
    {

    }
}

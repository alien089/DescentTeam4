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

        #region ImpossibleMode
        //ai.Body.AddForce(Random.onUnitSphere * ai.Speed * 10);
        #endregion
        
        ai.EnemyWeapon.Shoot(ai.pooler);

    }
    public override void OnTriggerEnter(GreenAiManager ai, Collider other)
    {
        //if (other.gameObject.layer == 6)
        //{
        //    ai.Body.AddForce(Random.onUnitSphere * ai.Speed * 100);
        //    Debug.Log("CIAO1");
        //}
        if (other.gameObject.tag == "baseProjectile")
        {
            ai.Body.AddForce(Random.onUnitSphere * ai.Speed * 100);
            Debug.Log("CIAO2");
        }
    }

}

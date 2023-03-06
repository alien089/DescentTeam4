using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissile : SecondaryWeapon
{
    public Transform[] SpawnPoints = new Transform[2];
    
    public HomingMissile(Transform left, Transform right)
    {
        SpawnPoints[0] = left;
        SpawnPoints[1] = right;
    }

    public void Shoot()
    {

    }
}

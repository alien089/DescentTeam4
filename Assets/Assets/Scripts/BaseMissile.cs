using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMissile : SecondaryWeapon
{
    public Transform[] SpawnPoints = new Transform[2];
    
    public BaseMissile(Transform left, Transform right)
    {
        SpawnPoints[0] = left;
        SpawnPoints[1] = right;
    }

    public void Shoot()
    {

    }
}

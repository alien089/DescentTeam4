using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcussionMissile : SecondaryWeapon
{
    public int AmmoCount;
    private int AmmoCost;

    private Transform[] SpawnPoints = new Transform[2];
    private GameObject ConcussionProjectile;
    private float _Deelay;
    private int _ActualShot;
    private int _NextShot;

    public ConcussionMissile(Transform left, Transform right, int ammoCount, int ammoCost, GameObject concussionProjectile, float deelay)
    {
        SpawnPoints[0] = left;
        SpawnPoints[1] = right;
        AmmoCount = ammoCount;
        AmmoCost = ammoCost;
        ConcussionProjectile = concussionProjectile;
        _Deelay = deelay;
        _ActualShot = 0;
        _NextShot = 1;
    }
     
    public bool Shoot()
    {
        bool shooted = false;

        if (AmmoCount - AmmoCost > 0)
        {
            GameObject tmp;
            tmp = Instantiate(ConcussionProjectile, SpawnPoints[_ActualShot].position, Quaternion.identity);

            int temp = _ActualShot;
            _ActualShot = _NextShot;
            _NextShot = temp;
        }

        return shooted;
    }
}

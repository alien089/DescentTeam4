using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : PrimaryWeapon
{
    public int AmmoCount;
    private float AmmoCost;

    private Transform[] SpawnPoints = new Transform[2];
    private GameObject _EnergyProjectile;
    private float _Deelay;

    public Laser(Transform left, Transform right, int ammoCount, float ammoCost, GameObject energyProjectile, float deelay)
    {
        SpawnPoints[0] = left;
        SpawnPoints[1] = right;
        AmmoCost = ammoCost;
        AmmoCount = ammoCount;
        _EnergyProjectile = energyProjectile;
        _Deelay = deelay;
    }

    public bool Shoot()
    {
        bool shooted = false;

        if (AmmoCount - AmmoCost > 0)
        {
            if (IsCreating == false)
            {
                GameObject left;
                GameObject right;

                left = Instantiate(_EnergyProjectile, SpawnPoints[0].position, SpawnPoints[0].rotation);
                right = Instantiate(_EnergyProjectile, SpawnPoints[1].position, SpawnPoints[1].rotation);
                StartCoroutine(WaitAfterCreate(_Deelay));
            }
        }

        return shooted;
    }
}

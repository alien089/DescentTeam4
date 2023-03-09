using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : PrimaryWeapon
{
    public float AmmoCount;
    private float AmmoCost;

    private Transform[] SpawnPoints = new Transform[2];
    private GameObject _EnergyProjectile;
    private float _Deelay;

    private TimerComponent _Timer;
    public Laser(Transform left, Transform right, float ammoCount, float ammoCost, GameObject energyProjectile, float deelay, TimerComponent timer)
    {
        SpawnPoints[0] = left;
        SpawnPoints[1] = right;
        AmmoCost = ammoCost;
        AmmoCount = ammoCount;
        _EnergyProjectile = energyProjectile;
        _Deelay = deelay;
        _Timer = timer;
    }

    public void Shoot()
    {
        if (AmmoCount - AmmoCost >= 0f)
        {
            if (_Timer.CanShoot == true)
            {
                GameObject left;
                GameObject right;

                left = UnityEngine.Object.Instantiate(_EnergyProjectile, SpawnPoints[0].position, SpawnPoints[0].rotation);
                right = UnityEngine.Object.Instantiate(_EnergyProjectile, SpawnPoints[1].position, SpawnPoints[1].rotation);

                _Timer.Coroutine(_Deelay);

                AmmoCount -= AmmoCost;
            }
        }
    }
}
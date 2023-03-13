using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vulcan : PrimaryWeapon
{
    public float AmmoCount;
    private float AmmoCost;

    private Transform SpawnPoints;
    private GameObject _VulcanProjectile;
    private float _Deelay;

    private TimerComponent _Timer;
    public Vulcan(Transform spawn, float ammoCount, float ammoCost, GameObject vulcanProjectile, float deelay, TimerComponent timer)
    {
        SpawnPoints = spawn;
        AmmoCost = ammoCost;
        AmmoCount = ammoCount;
        _VulcanProjectile = vulcanProjectile;
        _Deelay = deelay;
        _Timer = timer;
    }

    public void Shoot()
    {
        if (AmmoCount - AmmoCost >= 0f)
        {
            if (_Timer.CanShoot == true)
            {
                GameObject bullet;

                bullet = UnityEngine.Object.Instantiate(_VulcanProjectile, SpawnPoints.position, SpawnPoints.rotation);

                _Timer.Coroutine(_Deelay);

                AmmoCount -= AmmoCost;
            }
        }
    }
}

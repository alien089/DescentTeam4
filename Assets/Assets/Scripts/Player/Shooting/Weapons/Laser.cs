using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : PrimaryWeapon
{
    public new float AmmoCount;
    private new float m_AmmoCost;

    private GameObject m_LaserProjectile;
    public Laser(Transform left, Transform right, float ammoCount, float ammoCost, GameObject energyProjectile, float deelay, TimerComponent timer)
    {
        m_SpawnBullets[0] = left;
        m_SpawnBullets[1] = right;
        m_AmmoCost = ammoCost;
        AmmoCount = ammoCount;
        m_LaserProjectile = energyProjectile;
        m_Deelay = deelay;
        m_Timer = timer;
    }

    public override bool Shoot(Pooler pooler)
    {
        bool shooted = false;
        if (AmmoCount - m_AmmoCost >= 0f)
        {
            if (m_Timer.CanShoot == true)
            {
                GameObject left;
                GameObject right;

                pooler.GetObject(m_SpawnBullets[0]);
                pooler.GetObject(m_SpawnBullets[1]);
                //left = UnityEngine.Object.Instantiate(m_LaserProjectile, m_SpawnBullets[0].position, m_SpawnBullets[0].rotation);
                //right = UnityEngine.Object.Instantiate(m_LaserProjectile, m_SpawnBullets[1].position, m_SpawnBullets[1].rotation);

                m_Timer.Coroutine(m_Deelay);

                AmmoCount -= m_AmmoCost;

                shooted = true;
            }
        }

        return shooted;
    }
}
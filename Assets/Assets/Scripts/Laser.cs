using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : PrimaryWeapon
{
    public float AmmoCount;
    private float m_AmmoCost;

    private Transform[] m_SpawnPoints = new Transform[2];
    private GameObject m_LaserProjectile;
    private float m_Deelay;

    private TimerComponent m_Timer;
    public Laser(Transform left, Transform right, float ammoCount, float ammoCost, GameObject energyProjectile, float deelay, TimerComponent timer)
    {
        m_SpawnPoints[0] = left;
        m_SpawnPoints[1] = right;
        m_AmmoCost = ammoCost;
        AmmoCount = ammoCount;
        m_LaserProjectile = energyProjectile;
        m_Deelay = deelay;
        m_Timer = timer;
    }

    public override bool Shoot()
    {
        bool shooted = false;
        if (AmmoCount - m_AmmoCost >= 0f)
        {
            if (m_Timer.CanShoot == true)
            {
                GameObject left;
                GameObject right;

                left = UnityEngine.Object.Instantiate(m_LaserProjectile, m_SpawnPoints[0].position, m_SpawnPoints[0].rotation);
                right = UnityEngine.Object.Instantiate(m_LaserProjectile, m_SpawnPoints[1].position, m_SpawnPoints[1].rotation);

                m_Timer.Coroutine(m_Deelay);

                AmmoCount -= m_AmmoCost;

                shooted = true;
            }
        }

        return shooted;
    }
}
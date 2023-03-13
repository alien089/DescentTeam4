using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vulcan : PrimaryWeapon
{
    public float AmmoCount;
    private float m_AmmoCost;

    private Transform SpawnPoints;
    private GameObject m_VulcanProjectile;
    private float m_Deelay;

    private TimerComponent m_Timer;
    public Vulcan(Transform spawn, float ammoCount, float ammoCost, GameObject vulcanProjectile, float deelay, TimerComponent timer)
    {
        SpawnPoints = spawn;
        m_AmmoCost = ammoCost;
        AmmoCount = ammoCount;
        m_VulcanProjectile = vulcanProjectile;
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
                GameObject bullet;

                bullet = UnityEngine.Object.Instantiate(m_VulcanProjectile, SpawnPoints.position, SpawnPoints.rotation);

                m_Timer.Coroutine(m_Deelay);

                AmmoCount -= m_AmmoCost;

                shooted = true;
            }
        }
        return shooted;
    }
}

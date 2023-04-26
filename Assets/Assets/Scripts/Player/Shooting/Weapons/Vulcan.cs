using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vulcan : PrimaryWeapon
{
    private GameObject m_VulcanProjectile;
    
    public Vulcan(Transform spawn, int ammoCount, int ammoCost, GameObject vulcanProjectile, float deelay, TimerComponent timer)
    {
        m_SpawnBullet = spawn;
        m_AmmoCost = ammoCost;
        AmmoCount = ammoCount;
        m_VulcanProjectile = vulcanProjectile;
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
                GameObject bullet;

                bullet = UnityEngine.Object.Instantiate(m_VulcanProjectile, m_SpawnBullet.position, m_SpawnBullet.rotation);

                m_Timer.Coroutine(m_Deelay);

                AmmoCount -= m_AmmoCost;

                shooted = true;
            }
        }
        return shooted;
    }
}

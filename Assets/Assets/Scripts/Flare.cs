using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flare : PrimaryWeapon
{
    public new float AmmoCount;
    private new float m_AmmoCost;

    private GameObject m_FlareProjectile;
    public Flare(Transform spawn, float ammoCount, float ammoCost, GameObject flareProjectile, float deelay, TimerComponent timer)
    {
        m_SpawnBullet = spawn;
        m_AmmoCost = ammoCost;
        AmmoCount = ammoCount;
        m_FlareProjectile = flareProjectile;
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

                bullet = UnityEngine.Object.Instantiate(m_FlareProjectile, m_SpawnBullet.position, m_SpawnBullet.rotation);

                m_Timer.Coroutine(m_Deelay);

                AmmoCount -= m_AmmoCost;

                shooted = true;
            }
        }
        return shooted;
    }
}

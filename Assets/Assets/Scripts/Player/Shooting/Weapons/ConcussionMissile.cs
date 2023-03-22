using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcussionMissile : SecondaryWeapon
{
    private GameObject m_ConcussionProjectile;
    public ConcussionMissile(Transform left, Transform right, int ammoCount, int ammoCost, GameObject concussionProjectile, float deelay)
    {
        m_SpawnPoints[0] = left;
        m_SpawnPoints[1] = right;
        AmmoCount = ammoCount;
        m_AmmoCost = ammoCost;
        m_ConcussionProjectile = concussionProjectile;
        m_Deelay = deelay;
        m_ActualShot = 0;
        m_NextShot = 1;
    }
     
    public override bool Shoot()
    {
        bool shooted = false;

        if (AmmoCount - m_AmmoCost >= 0)
        {
            GameObject tmp;
            tmp = UnityEngine.Object.Instantiate(m_ConcussionProjectile, m_SpawnPoints[m_ActualShot].position, m_SpawnPoints[m_ActualShot].rotation);

            int temp = m_ActualShot;
            m_ActualShot = m_NextShot;
            m_NextShot = temp;

            AmmoCount -= m_AmmoCost;
        }

        return shooted;
    }
}

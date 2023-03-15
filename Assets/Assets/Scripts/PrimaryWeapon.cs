using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PrimaryWeapon
{
    public int AmmoCount;

    protected int m_AmmoCost;
    protected float m_Deelay;
    protected Transform[] m_SpawnBullets = new Transform[2];
    protected Transform m_SpawnBullet;
    protected TimerComponent m_Timer;
    public abstract bool Shoot();
}

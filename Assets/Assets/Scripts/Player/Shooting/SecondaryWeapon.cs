using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SecondaryWeapon
{
    public int AmmoCount;
    protected int m_AmmoCost;

    protected Transform[] m_SpawnPoints = new Transform[2];
    protected float m_Deelay;
    protected int m_ActualShot;
    protected int m_NextShot;

    public abstract bool Shoot();
}

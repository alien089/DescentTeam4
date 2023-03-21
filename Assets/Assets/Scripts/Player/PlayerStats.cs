using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerShooting))]
[RequireComponent(typeof(Bobbing))]
[RequireComponent(typeof(TimerComponent))]
[RequireComponent(typeof(CameraManager))]
public class PlayerStats : MonoBehaviour, IDamageable, IPlayer
{
    public int MaxShield;
    public int Shield;
    public void Damage(int damage)
    {
        Shield -= damage;
    }

    public void LifeCheck()
    {
        if (Shield <= 0)
        {

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

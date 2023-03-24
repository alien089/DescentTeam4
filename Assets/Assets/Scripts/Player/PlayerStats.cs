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
    //public static PlayerStats instance;

    public int MaxShield;
    public int Shield;

    private void Start()
    {
        Shield = MaxShield;

        //if (instance == null)
        //    if (TryGetComponent<PlayerStats>(out instance))
        //        instance = gameObject.AddComponent<PlayerStats>();
        //    else
        //        Destroy(gameObject);

        //DontDestroyOnLoad(instance);
    }

    private void Update()
    {
        if(Shield <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StageManager.instance.Respawn(gameObject);
            }
        }
    }

    public void Damage(int damage)
    {
        Shield -= damage;
    }

    public void LifeCheck()
    {
        if (Shield <= 0)
        {
            StageManager.instance.Death();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<IBullet>(out IBullet bullet))
            if (collision.gameObject.GetComponent<GenericProjectile>().IsPlayer == false)
            {
                Damage(collision.gameObject.GetComponent<GenericProjectile>().Damage);
                LifeCheck();
            }
    }
}

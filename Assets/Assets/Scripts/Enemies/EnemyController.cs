using System;
using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;

public class EnemyController : MonoBehaviour, IDamageable, IEnemy
{
    public int Health = 5;

    private void Update()
    {
        LifeCheck();
    }

    public void LifeCheck()
    {
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Damage(int damage)
    {
        Health -= damage;
    }

    protected void OnBecameVisible()
    {
        gameObject.layer = 3;
    }

    protected void OnBecameInvisible()
    {
        gameObject.layer = 0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<IBullet>(out IBullet bullet))
        {
            if(collision.gameObject.GetComponent<GenericProjectile>().IsPlayer)
                Damage(collision.gameObject.GetComponent<GenericProjectile>().Damage);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BaseProjectile : GenericProjectile, IBullet
{
    //private Rigidbody rb;

    private void Start()
    {
        //rb = transform.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();
    }

    protected override void Move()
    {
        transform.Translate(transform.forward * Speed * Time.deltaTime, Space.World);
        //rb.velocity = transform.forward * Speed;
    }

    protected override void Explode()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.TryGetComponent<IPlayer>(out IPlayer player))
            Explode();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseProjectile : MonoBehaviour
{
    public int Damage;
    public float Speed;
    private CapsuleCollider collider;

    private void Start()
    {
        collider = transform.GetComponent<CapsuleCollider>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(transform.forward * Speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}

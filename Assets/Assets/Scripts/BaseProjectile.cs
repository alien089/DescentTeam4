using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BaseProjectile : MonoBehaviour
{
    public int Damage;
    public float Speed;
    //private Rigidbody rb;

    private void Start()
    {
        //rb = transform.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(transform.forward * Speed * Time.deltaTime, Space.World);
        //rb.velocity = transform.forward * Speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(!collision.gameObject.CompareTag("Player"))
            Destroy(gameObject);
    }
}

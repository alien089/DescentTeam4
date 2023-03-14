using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FlareProjectile : MonoBehaviour
{
    public float Speed;
    public float TimeBeforeDestroy;
    //private Rigidbody rb;

    private bool m_CanMove = true;
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
        if (m_CanMove)
            transform.Translate(transform.forward * Speed * Time.deltaTime, Space.World);
        //rb.velocity = transform.forward * Speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            m_CanMove = false;
            StartCoroutine(TimerBeforeDestroy());
        }
    }

    private IEnumerator TimerBeforeDestroy()
    {
        yield return new WaitForSeconds(TimeBeforeDestroy);
        Destroy(gameObject);
    }
}

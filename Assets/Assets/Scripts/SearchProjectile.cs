using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SearchProjectile : MonoBehaviour
{
    public int Damage;
    public float Speed;

    private Transform m_Target;

    private void Start()
    {
        FindTarget();
    }

    private void Update()
    {
        Move();
    }

    private void FindTarget()
    {
        List<GameObject> inViewEnemies = new List<GameObject>();

        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            if (enemy.layer == 3)
            {
                inViewEnemies.Add(enemy);
            }
        }

        float finalDistance = 10000f;
        int finalIndex = 0;

        for (int i = 0; i < inViewEnemies.Count; i++)
        {
            float distance = Vector3.Distance(transform.position, inViewEnemies[i].transform.position);
            if (distance < finalDistance)
            {
                finalDistance = distance;
                finalIndex = i;
            }
        }

        m_Target = inViewEnemies[finalIndex].transform;
    }

    private void Move()
    {
        try
        {
            transform.position = Vector3.MoveTowards(transform.position, m_Target.position, Speed * Time.deltaTime);
        }
        catch (System.Exception e)
        {
            transform.Translate(transform.forward * Speed * Time.deltaTime, Space.World);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
            Destroy(gameObject);
    }
}

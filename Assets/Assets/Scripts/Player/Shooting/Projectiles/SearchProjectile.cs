using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SearchProjectile : GenericProjectile, IBullet
{
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
                RaycastHit hit;

                Debug.DrawLine(transform.position, enemy.transform.position, Color.red);
                if (Physics.Linecast(transform.position, enemy.transform.position, out hit, 3 << 3))
                {
                    if (hit.collider.TryGetComponent(out IEnemy enemy1))
                    {
                        inViewEnemies.Add(enemy);
                    }
                }

                //if(Physics.Linecast(transform.position, enemy.transform.position, out hit))
                //{
                //    if (hit.collider.TryGetComponent(out IEnemy enemy1))
                //        inViewEnemies.Add(enemy);
                //}
                //inViewEnemies.Add(enemy);
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
        inViewEnemies.RemoveAt(finalIndex);
    }

    protected override void Move()
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

    protected override void Explode()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
            Explode();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public float Health = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LifeCheck();
    }

    private void LifeCheck()
    {
        if(Health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("baseProjectile"))
        {
            Health -= collision.gameObject.GetComponent<BaseProjectile>().Damage;
        }
        if (collision.gameObject.CompareTag("searchProjectile"))
        {
            //Heatlh -= collision.gameObject.GetComponent<SearchProjectile>().Damage;
        }
    }
}

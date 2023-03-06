using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableItem : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Laser laser;
            other.gameObject.GetComponent<ShootingManager>()._PrimaryList.Add(new Laser(transform, transform));
        }
    }
}

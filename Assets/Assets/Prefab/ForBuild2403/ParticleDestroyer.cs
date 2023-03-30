using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDestroyer : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject,2f);
    }
    private void OnDisable()
    {
        Destroy(gameObject);
    }
}

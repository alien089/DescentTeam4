using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HealthManager))]
public class ChangeMaterials : MonoBehaviour
{
    #region Backingields

    [SerializeField]
    private Material[] _material;

    [SerializeField]
    private float[] _health;

    #endregion

    #region Fields

    private HealthManager _hp;
    float currentHealth;

    #endregion

    #region Body
    private void Start()
    {
        TryGetComponent<HealthManager>(out _hp);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == 6)
        {
            currentHealth = _hp.Health;
            for (int i = 0; i < _health.Length; i++)
            {
                if (currentHealth <= _health[i])
                {
                    GetComponent<Renderer>().material = _material[i];
                }
            }
        }
    }

    #endregion
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HealthManager))]
public class ChangeMaterials : MonoBehaviour
{
    #region Backingields

    [SerializeField]
    private Material[] m_material;

    [SerializeField]
    private float[] m_health;

    #endregion

    #region Fields

    private HealthManager m_hp;
    private float m_currentHealth;

    #endregion

    #region Body
    private void Start()
    {
        TryGetComponent<HealthManager>(out m_hp);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == 6)
        {
            m_currentHealth = m_hp.Health;
            for (int i = 0; i < m_health.Length; i++)
            {
                if (m_currentHealth <= m_health[i])
                {
                    GetComponent<Renderer>().material = m_material[i];
                }
            }
        }
    }

    #endregion
}

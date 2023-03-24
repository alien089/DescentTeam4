using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterials : MonoBehaviour, IDamageable
{
    #region Backingields

    [SerializeField]
    private Material[] m_material;

    [SerializeField]
    private float[] m_health;

    #endregion

    #region Fields

    [SerializeField]
    private float m_CurrentHealth;

    #endregion

    #region Body
    private void Start()
    {

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent<IBullet>(out IBullet bullet))
        {
            Damage(other.gameObject.GetComponent<GenericProjectile>().Damage);
            LifeCheck();
            for (int i = 0; i < m_health.Length; i++)
            {
                if (m_CurrentHealth <= m_health[i])
                {
                    GetComponent<Renderer>().material = m_material[i];
                }
            }
        }
    }

    public void Damage(int damage)
    {
        m_CurrentHealth -= damage;
    }

    public void LifeCheck()
    {
        if(m_CurrentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    #endregion
}

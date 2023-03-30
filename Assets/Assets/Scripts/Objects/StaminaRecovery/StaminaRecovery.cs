using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaRecovery : MonoBehaviour
{
    [SerializeField]
    private int m_addEveryUpdate;
    [SerializeField]
    private float m_maxRecovery = 100;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && other.gameObject.TryGetComponent<PlayerStats>(out PlayerStats Player))
        {
            if (Player.Shield < m_maxRecovery)
            {
                Player.Shield += m_addEveryUpdate;
            }
        }
    }
}

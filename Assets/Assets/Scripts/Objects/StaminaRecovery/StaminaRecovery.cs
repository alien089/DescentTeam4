using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaRecovery : MonoBehaviour
{
    [SerializeField]
    private float m_addEveryUpdate;
    [SerializeField]
    private float m_maxRecovery;

    [Header("Dont Change it , its just to see")]
    [SerializeField]
    private float m_current;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (m_current < 100)
            {
                m_current += m_addEveryUpdate;
            }

        }
    }
}

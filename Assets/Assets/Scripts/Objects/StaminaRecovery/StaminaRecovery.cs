using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaRecovery : MonoBehaviour
{
    [SerializeField]
    private float m_addEveryUpdate;
    [SerializeField]
    private float m_maxRecovery = 100;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && other.gameObject.TryGetComponent<PlayerShooting>(out PlayerShooting Player))
        {
            if (((Laser)Player.PrimaryList[0]).AmmoCount < m_maxRecovery)
            {
                ((Laser)Player.PrimaryList[0]).AmmoCount += m_addEveryUpdate;
            }
        }
    }
}

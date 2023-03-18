using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaRecovery : MonoBehaviour
{
    [SerializeField]
    private float _addEveryUpdate;
    [SerializeField]
    private float _maxRecovery;

    [SerializeField]
    private float current;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (current < 100)
            {
                current += _addEveryUpdate;
            }

        }
    }
}

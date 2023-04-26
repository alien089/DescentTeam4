using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEffect : MonoBehaviour
{
    [SerializeField]
    private GameObject m_effect;

    private void OnDisable()
    {
        Instantiate(m_effect, transform.position, transform.rotation);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeObject : MonoBehaviour
{
    [SerializeField]
    private GameObject m_newObject;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6)
        {
            GameObject obj =Instantiate(m_newObject, transform.position, transform.rotation, transform.parent);
            Destroy(gameObject);
        }
    }
}

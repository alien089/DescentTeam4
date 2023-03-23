using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropRate : MonoBehaviour
{
    [SerializeField]
    [Range(0f, 100f)]
    private int _probabilityOfDrop;

    [SerializeField]
    private GameObject _drop;

    private void OnDestroy()
    {
        if (Random.Range(0f,100f) <= _probabilityOfDrop)
        {
            Instantiate(_drop, transform.position ,transform.rotation, transform.parent);
        }

    }
}

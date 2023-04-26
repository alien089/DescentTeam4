using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObject : MonoBehaviour
{

    public Pooler pooler;

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        transform.SetParent(pooler.transform);
    }
}

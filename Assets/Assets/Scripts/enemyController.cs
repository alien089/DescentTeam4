using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    protected void OnBecameVisible()
    {
        gameObject.layer = 3;
    }

    protected void OnBecameInvisible()
    {
        gameObject.layer = 0;
    }
}

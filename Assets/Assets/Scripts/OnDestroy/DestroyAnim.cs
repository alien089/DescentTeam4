using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAnim : MonoBehaviour
{
    [SerializeField]
    private GameObject _effect;

    private void OnDestroy()
    {
        Instantiate(_effect, transform.position, transform.rotation);
    }
}

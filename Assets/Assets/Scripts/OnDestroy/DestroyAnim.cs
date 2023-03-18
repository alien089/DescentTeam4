using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAnim1 : MonoBehaviour
{
    [SerializeField]
    private Animator _animation;
    [SerializeField]
    private string _nameOfBoolean;
    [SerializeField]
    private bool _closeAnimation;
    [SerializeField]
    private float _waitToClose;

    private void OnDestroy()
    {
        _animation.SetBool(_nameOfBoolean, true);
        if (_closeAnimation == true)
        {
            StartCoroutine(Close(_waitToClose, _nameOfBoolean));
        }
    }
    private IEnumerator Close(float value, string boolean)
    {
        yield return new WaitForSeconds(value);
        _animation.SetBool(boolean, false);
    }
}

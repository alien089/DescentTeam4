using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;

    [SerializeField]
    private string _nameRequiredBool;

    [SerializeField]
    private float _timeToClose;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6 || collision.gameObject.tag == "Player")
        {
            _animator.SetBool(_nameRequiredBool, true);
            StartCoroutine(CloseDoor(_timeToClose));
        }
    }
    private IEnumerator CloseDoor (float value)
    {
        yield return new WaitForSeconds(value);
        _animator.SetBool(_nameRequiredBool, false);
    }
}

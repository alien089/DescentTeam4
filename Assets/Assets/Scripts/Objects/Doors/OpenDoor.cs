using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField]
    private Animator _doorAnimation;

    [SerializeField]
    private string _nameRequiredDoorBool;

    [SerializeField]
    private float _timeToClose;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6 || collision.gameObject.tag == "Player")
        {
            _doorAnimation.SetBool(_nameRequiredDoorBool, true);
            StartCoroutine(CloseDoor(_timeToClose));
        }
    }
    private IEnumerator CloseDoor (float value)
    {
        yield return new WaitForSeconds(value);
        _doorAnimation.SetBool(_nameRequiredDoorBool, false);
    }
}

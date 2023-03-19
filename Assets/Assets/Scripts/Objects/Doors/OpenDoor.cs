using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField]
    private Animator m_doorAnimation;

    [SerializeField]
    private string m_nameRequiredDoorBool;

    [SerializeField]
    private float m_timeToClose;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6 || collision.gameObject.tag == "Player")
        {
            m_doorAnimation.SetBool(m_nameRequiredDoorBool, true);
            StartCoroutine(CloseDoor(m_timeToClose));
        }
    }
    private IEnumerator CloseDoor (float value)
    {
        yield return new WaitForSeconds(value);
        m_doorAnimation.SetBool(m_nameRequiredDoorBool, false);
    }
}

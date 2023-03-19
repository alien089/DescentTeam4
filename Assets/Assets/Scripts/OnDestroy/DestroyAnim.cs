using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAnim1 : MonoBehaviour
{
    [SerializeField]
    private Animator m_animation;
    [SerializeField]
    private string m_nameOfBoolean;
    [SerializeField]
    private bool m_closeAnimation;
    [SerializeField]
    private float m_waitToClose;

    private void OnDestroy()
    {
        m_animation.SetBool(m_nameOfBoolean, true);
        if (m_closeAnimation == true)
        {
            StartCoroutine(Close(m_waitToClose, m_nameOfBoolean));
        }
    }
    private IEnumerator Close(float value, string boolean)
    {
        yield return new WaitForSeconds(value);
        m_animation.SetBool(boolean, false);
    }
}

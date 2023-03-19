using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum KeyCardNumber
{
    KeyCard1,
    KeyCard2,
    keyCard3,
}

public class KeyCard : MonoBehaviour
{
    #region BackingFields

    [SerializeField]
    private Animator m_openDoor;

    [SerializeField]
    private float m_timeToClose;

    [SerializeField]
    private KeyCardNumber m_currentKeyCard;

    #endregion

    #region Fields

    private PickUpCard PickUp;

    private static bool k1, k2, k3;

    #endregion

    void Start()
    {
        PickUp = FindObjectOfType<PickUpCard>();
    }

    void Update()
    {
        k1 = PickUp.KeyCard1;
        k2 = PickUp.KeyCard2;
        k3 = PickUp.KeyCard3;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6 || collision.gameObject.tag == "Player")
        {
            if (k1 && m_currentKeyCard == KeyCardNumber.KeyCard1)
            {
                m_openDoor.SetBool("open", true);
                StartCoroutine(CloseDoor(m_timeToClose, m_openDoor, "open"));
            }
            if (k2 && m_currentKeyCard == KeyCardNumber.KeyCard2)
            {
                m_openDoor.SetBool("open", true);
                StartCoroutine(CloseDoor(m_timeToClose, m_openDoor, "open"));
            }
            if (k3 && m_currentKeyCard == KeyCardNumber.keyCard3)
            {
                m_openDoor.SetBool("open", true);
                StartCoroutine(CloseDoor(m_timeToClose, m_openDoor, "open"));
            }
        }
    }
    private IEnumerator CloseDoor(float value, Animator anim, string text)
    {
        yield return new WaitForSeconds(value);
        anim.SetBool(text, false);
    }

}

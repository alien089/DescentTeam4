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
    [SerializeField]
    private Animator _openDoor;
    [SerializeField]
    private float _timeToClose;
    [SerializeField]
    private KeyCardNumber currentKeyCard;
    private PickUpCard PickUp;
    private static bool k1, k2, k3;
    // Start is called before the first frame update
    void Start()
    {
        PickUp = FindObjectOfType<PickUpCard>();
    }

    // Update is called once per frame
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
            if (k1 && currentKeyCard == KeyCardNumber.KeyCard1)
            {
                _openDoor.SetBool("open", true);
                StartCoroutine(CloseDoor(_timeToClose, _openDoor, "open"));
            }
            if (k2 && currentKeyCard == KeyCardNumber.KeyCard2)
            {
                _openDoor.SetBool("open", true);
                StartCoroutine(CloseDoor(_timeToClose, _openDoor, "open"));
            }
            if (k3 && currentKeyCard == KeyCardNumber.keyCard3)
            {
                _openDoor.SetBool("open", true);
                StartCoroutine(CloseDoor(_timeToClose, _openDoor, "open"));
            }
        }
    }
    private IEnumerator CloseDoor(float value, Animator anim, string text)
    {
        yield return new WaitForSeconds(value);
        anim.SetBool(text, false);
    }

}

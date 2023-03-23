using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCard : MonoBehaviour
{
    public bool KeyCard1 { get; private set; }
    public bool KeyCard2 { get; private set; }
    public bool KeyCard3 { get; private set; }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "KeyCard1":
                KeyCard1 = true;
                Destroy(collision.gameObject);
                break;
            case "KeyCard2":
                KeyCard2 = true;
                Destroy(collision.gameObject);
                break;
            case "KeyCard3":
                KeyCard3 = true;
                Destroy(collision.gameObject);
                break;
            default:
                break;

        }
    }
}

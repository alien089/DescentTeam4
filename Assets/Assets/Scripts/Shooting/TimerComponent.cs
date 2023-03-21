using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerComponent : MonoBehaviour
{
    public bool CanShoot = true;

    public void Coroutine(float deelay)
    {
        StartCoroutine(WaitAfterShoot(deelay));
    }

    public IEnumerator WaitAfterShoot(float deelay)
    {
        CanShoot = false;
        yield return new WaitForSeconds(deelay);
        CanShoot = true;
    }
}

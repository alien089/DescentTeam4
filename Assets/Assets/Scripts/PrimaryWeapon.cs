using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimaryWeapon: MonoBehaviour
{
    public bool IsCreating = false;
    public IEnumerator WaitAfterCreate(float _Deelay)
    {
        IsCreating = true;
        yield return new WaitForSeconds(_Deelay);
        IsCreating = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon Data", menuName = "Weapon Data")]
public class DataWeapon : ScriptableObject
{
    public GameObject Projectile;
    public float AmmoSetupCount;
    public float AmmoCost;
    public float Deelay;
    public PickableType Type;
}

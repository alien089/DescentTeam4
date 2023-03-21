using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GenericProjectile : MonoBehaviour
{
    public int Damage = 0;
    public float Speed;
    public bool IsPlayer = false;

    protected abstract void Move();
    protected abstract void Explode();
}

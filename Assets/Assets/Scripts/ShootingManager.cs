using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingManager : MonoBehaviour
{
    public List<PrimaryWeapon> _PrimaryList = new List<PrimaryWeapon>();
    public List<SecondaryWeapon> _SecondaryList = new List<SecondaryWeapon>();

    public int ActualPrimary;
    public int ActualSecondary;

    public float PrimaryAmmo;
    public int SecondaryAmmo;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

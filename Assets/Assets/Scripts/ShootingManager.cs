using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingManager : MonoBehaviour
{
    public Transform RightWeapon;
    public Transform LeftWeapon;
    public Transform CentralWeapon;

    public int ActualPrimary;
    public int ActualSecondary;

    [Header("Laser")]
    public GameObject EnergyProjectile;
    public int EnergyAmmoCount;
    public float EnergyAmmoCost;
    public float LaserDeelay;

    [Header("Vulcan")]
    public GameObject VulcanProjectile;
    public int VulcanAmmoCount;
    public int VulcanAmmoCost;
    public float VulcanDeelay;

    [Header("Concussion")]
    public GameObject ConcussionProjectile;
    public int ConcussionAmmoCount;
    public int ConcussionAmmoCost;
    public float ConcussionDeelay;

    [Header("Homing")]
    public GameObject HomingProjectile;
    public int HomingAmmoCount;
    public int HomingAmmoCost;
    public float HomingDeelay;

    public List<PrimaryWeapon> _PrimaryList = new List<PrimaryWeapon>();
    public List<SecondaryWeapon> _SecondaryList = new List<SecondaryWeapon>();

    private WeaponType _PrimaryType;
    private WeaponType _SecondaryType;
    // Start is called before the first frame update
    void Start()
    {
        _PrimaryList.Add(new Laser(LeftWeapon, RightWeapon, EnergyAmmoCount, EnergyAmmoCost, EnergyProjectile, LaserDeelay));
        _SecondaryList.Add(new ConcussionMissile(LeftWeapon, RightWeapon, ConcussionAmmoCount, ConcussionAmmoCost, ConcussionProjectile, ConcussionDeelay));

        _PrimaryType = WeaponType.Laser;
        _SecondaryType = WeaponType.ConcussionMissile;
    }

    // Update is called once per frame
    void Update()
    {
        ChoosingPrimary();
        ShootPrimary();
        ChoosingSecondary();
        ShootSecondary();
    }

    private void ShootPrimary()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            switch (_PrimaryType)
            {
                case WeaponType.Laser:
                    var weaponLaser = _PrimaryList[ActualPrimary] as Laser;
                    weaponLaser.Shoot();
                    break;
                case WeaponType.Vulcan:
                    var weaponVulcan = _PrimaryList[ActualPrimary] as Vulcan;
                    weaponVulcan.Shoot();
                    break;
            }
        }
    }
    
    private void ShootSecondary()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            switch (_SecondaryType)
            {
                case WeaponType.ConcussionMissile:
                    var weaponConcussionMissile = _SecondaryList[ActualSecondary] as ConcussionMissile;
                    weaponConcussionMissile.Shoot();
                    break;
                case WeaponType.HomingMissile:
                    var weaponHomingMissilen = _SecondaryList[ActualSecondary] as HomingMissile;
                    weaponHomingMissilen.Shoot();
                    break;
            }
        }
    }

    private void ChoosingPrimary()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            _PrimaryType = WeaponType.Laser;
        if (Input.GetKeyDown(KeyCode.Alpha2))
            _PrimaryType = WeaponType.Vulcan;
    }

    private void ChoosingSecondary()
    {
        if (Input.GetKeyDown(KeyCode.Alpha6))
            _SecondaryType = WeaponType.ConcussionMissile;
        if (Input.GetKeyDown(KeyCode.Alpha7))
            _SecondaryType = WeaponType.HomingMissile;
    }
}

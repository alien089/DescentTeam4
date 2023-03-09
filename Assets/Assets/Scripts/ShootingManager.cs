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
    public GameObject LaserProjectile;
    public float LaserAmmoSetupCount;
    public float LaserAmmoCost;
    public float LaserDeelay;

    [Header("Vulcan")]
    public GameObject VulcanProjectile;
    public int VulcanAmmoSetupCount;
    public int VulcanAmmoCost;
    public float VulcanDeelay;

    [Header("Concussion")]
    public GameObject ConcussionProjectile;
    public int ConcussionAmmoSetupCount;
    public int ConcussionAmmoCost;
    public float ConcussionDeelay;

    [Header("Homing")]
    public GameObject HomingProjectile;
    public int HomingAmmoSetupCount;
    public int HomingAmmoCost;
    public float HomingDeelay;

    public List<PrimaryWeapon> _PrimaryList = new List<PrimaryWeapon>();
    public List<SecondaryWeapon> _SecondaryList = new List<SecondaryWeapon>();

    private WeaponType _PrimaryType;
    private Type _PrimaryClass;
    private WeaponType _SecondaryType;
    private Type _SecondaryClass;

    private TimerComponent _Timer;
    // Start is called before the first frame update
    void Start()
    {
        _Timer = GetComponent<TimerComponent>();

        _PrimaryList.Add(new Laser(LeftWeapon, RightWeapon, LaserAmmoSetupCount, LaserAmmoCost, LaserProjectile, LaserDeelay, _Timer));
        _SecondaryList.Add(new ConcussionMissile(LeftWeapon, RightWeapon, ConcussionAmmoSetupCount, ConcussionAmmoCost, ConcussionProjectile, ConcussionDeelay));

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
        {
            _PrimaryType = WeaponType.Laser;
            _PrimaryClass = typeof(Laser);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _PrimaryType = WeaponType.Vulcan;
            _PrimaryClass = typeof(Vulcan);
        }
    }

    private void ChoosingSecondary()
    {
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            _SecondaryType = WeaponType.ConcussionMissile;
            _SecondaryClass = typeof(ConcussionMissile);
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            _SecondaryType = WeaponType.HomingMissile;
            _SecondaryClass = typeof(HomingMissile);
        }
    }
}

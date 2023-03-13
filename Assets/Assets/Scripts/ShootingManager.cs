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

    [Header("Input")]
    public KeyCode PrimaryWeapon = KeyCode.Mouse0;
    public KeyCode SecondaryWeapon = KeyCode.Mouse1;
    public KeyCode ChooseFirstPrimary = KeyCode.Alpha1;
    public KeyCode ChooseSecondPrimary = KeyCode.Alpha2;
    public KeyCode ChooseFirstSecondary = KeyCode.Alpha6;
    public KeyCode ChooseSecondSecondary = KeyCode.Alpha7;

    private List<PrimaryWeapon> m_PrimaryList = new List<PrimaryWeapon>();
    private List<SecondaryWeapon> m_SecondaryList = new List<SecondaryWeapon>();

    private TimerComponent m_Timer = new TimerComponent();
    // Start is called before the first frame update
    void Start()
    {
        m_PrimaryList.Add(new Laser(LeftWeapon, RightWeapon, LaserAmmoSetupCount, LaserAmmoCost, LaserProjectile, LaserDeelay, m_Timer));
        m_PrimaryList.Add(new Vulcan(CentralWeapon, VulcanAmmoSetupCount, VulcanAmmoCost, VulcanProjectile, VulcanDeelay, m_Timer));

        m_SecondaryList.Add(new ConcussionMissile(LeftWeapon, RightWeapon, ConcussionAmmoSetupCount, ConcussionAmmoCost, ConcussionProjectile, ConcussionDeelay));
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
        if (Input.GetKey(PrimaryWeapon))
        {
            PrimaryWeapon weapon = m_PrimaryList[ActualPrimary];
            weapon.Shoot();
        }
    }

    private void ShootSecondary()
    {
        if (Input.GetKeyDown(SecondaryWeapon))
        {
            SecondaryWeapon weapon = m_SecondaryList[ActualSecondary];
            weapon.Shoot();
        }
    }

    private void ChoosingPrimary()
    {
        if (Input.GetKeyDown(ChooseFirstPrimary))
        {
            ActualPrimary = 0;
        }
        if (Input.GetKeyDown(ChooseSecondPrimary))
        {
            ActualPrimary = 1;
        }
    }

    private void ChoosingSecondary()
    {
        if (Input.GetKeyDown(ChooseFirstSecondary))
        {
            ActualSecondary = 0;
        }
        if (Input.GetKeyDown(ChooseSecondSecondary))
        {
            ActualSecondary = 1;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TimerComponent))]
[RequireComponent(typeof(SphereCollider))]
public class ReactorController : enemyController
{
    public Transform[] SpawnList;

    [Header("Weapon Data")]
    public GameObject BossProjectile;
    public int BossAmmoSetupCount;
    public int BossAmmoCost;
    public float BossDeelay;

    private PrimaryWeapon[] m_WeaponsList;
    private TimerComponent m_TimerComponent;
    private GameObject m_Player;
    private SphereCollider m_VisibileArea;

    private int m_ActualChoosedWeapon;
    // Start is called before the first frame update
    void Start()
    {
        m_WeaponsList = new PrimaryWeapon[SpawnList.Length];
        m_TimerComponent = GetComponent<TimerComponent>();

        m_VisibileArea = GetComponent<SphereCollider>();
        m_VisibileArea.isTrigger = true;

        for (int i = 0; i < SpawnList.Length; i++)
        {
            m_WeaponsList[i] = new Vulcan(SpawnList[i], BossAmmoCost, BossAmmoSetupCount, BossProjectile, BossDeelay, m_TimerComponent);
        }
    }

    // Update is called once per frame
    void Update()
    {
        ChooseNearerWeapon();
        DirectWeaponToPlayer();
        Shoot();
    }


    private void ChooseNearerWeapon()
    {
        float finalDistance = 10000f;
        int finalIndex = 0;

        for (int i = 0; i < SpawnList.Length; i++)
        {
            float distance = Vector3.Distance(SpawnList[i].position, m_Player.transform.position);
            if (distance < finalDistance)
            {
                finalDistance = distance;
                finalIndex = i;
            }
        }

        m_ActualChoosedWeapon = finalIndex;
    }

    private void DirectWeaponToPlayer()
    {
        
    }

    private void Shoot()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.TryGetComponent<IPlayer>(out IPlayer component))
            m_Player = other.gameObject;
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("");
    }
}

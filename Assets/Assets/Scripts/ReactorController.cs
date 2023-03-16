using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    // Start is called before the first frame update
    void Start()
    {
        m_WeaponsList = new PrimaryWeapon[SpawnList.Length];
        m_TimerComponent = GetComponent<TimerComponent>();

        for(int i = 0; i < SpawnList.Length; i++)
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
            float distance = Vector3.Distance(SpawnList[i].position, .transform.position);
            if (distance < finalDistance)
            {
                finalDistance = distance;
                finalIndex = i;
            }
        }
    }

    private void DirectWeaponToPlayer()
    {
        
    }

    private void Shoot()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
            m_Player = other.gameObject;
    }
}

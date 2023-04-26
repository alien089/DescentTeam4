using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TimerComponent))]
[RequireComponent(typeof(SphereCollider))]
public class ReactorController : EnemyController
{
    public Transform[] SpawnList;
    public Pooler pooler;

    [Header("Weapon Data")]
    public GameObject BossProjectile;
    public int BossAmmoSetupCount;
    public int BossAmmoCost;
    public float BossDeelay;

    public Animator ExitDoor;

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
            m_WeaponsList[i] = new Vulcan(SpawnList[i], BossAmmoSetupCount, BossAmmoCost, BossProjectile, BossDeelay, m_TimerComponent);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Player)
        {
            ChooseNearerWeapon();
            DirectWeaponToPlayer();
            Shoot();
        }
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
        float directionX = m_Player.transform.position.x - SpawnList[m_ActualChoosedWeapon].transform.position.x;
        float directionY = m_Player.transform.position.y - SpawnList[m_ActualChoosedWeapon].transform.position.y;
        float directionZ = m_Player.transform.position.z - SpawnList[m_ActualChoosedWeapon].transform.position.z;

        Vector3 m_Direction = new Vector3(directionX, directionY, directionZ);

        SpawnList[m_ActualChoosedWeapon].transform.forward = m_Direction.normalized;
    }

    private void Shoot()
    {
        if (CheckInView())
        {
            PrimaryWeapon weapon = m_WeaponsList[m_ActualChoosedWeapon];
            weapon.Shoot(pooler);
        }
    }

    private bool CheckInView()
    {
        RaycastHit hit;
        if(Physics.Linecast(transform.position, m_Player.transform.position, out hit))
        {
            if (hit.collider.gameObject.TryGetComponent<IPlayer>(out IPlayer player))
            {
                return true;
            }
        }
        return false;
    }

    private void OnDestroy()
    {
        StageManager.instance.BossDead = true;
        ExitDoor.SetBool("exit", true);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.TryGetComponent<IPlayer>(out IPlayer component))
            m_Player = other.gameObject;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TimerComponent))]
public class GreenAiManager : EnemyController
{
    [Serializable]
    private struct HeaderSpace
    {
        [field: SerializeField]
        public string Description { get; set; }
    }

    #region Editor

    [Space(15)]
    [SerializeField]
    HeaderSpace m_playerStats = new HeaderSpace() { Description = "A set of values for basic functions" };

    [field: SerializeField]
    public float Speed { get; set; }

    [field: SerializeField]
    public Rigidbody Body;

    [field: SerializeField]
    public GameObject Player { get; set; }


    [Space(15)]
    [SerializeField]
    private HeaderSpace m_shootingStats = new HeaderSpace() { Description = "A set of values for shooting settings" };

    [field: SerializeField]
    public Transform[] SpawnPoints { get; set; } = new Transform[2];

    [field: SerializeField]
    public GameObject EnemyProjectile { get; set; }

    [field: SerializeField]
    public float EnemyDeelay { get; set; }



    #endregion


    public FOV FOV { get; set; }
    public Vector3 InitialPos { get; set; }
    public TimerComponent Timer { get; set; }
    public int EnemyAmmoSetupCount { get; set; }
    public PrimaryWeapon EnemyWeapon { get; set; }
    public int EnemyAmmoCost { get; } = 0;


    public GreenAiBaseState Current;

    public GreenDodgeState DodgeState { get; set; } = new GreenDodgeState();
    public GreenSpawnState SpawnState { get; set; } = new GreenSpawnState();
    public GreenGoBack GoBack { get; set; } = new GreenGoBack();

    private void Awake()
    {
        Body = GetComponent<Rigidbody>();
        Timer = GetComponent<TimerComponent>();
        EnemyWeapon = new Laser(SpawnPoints[0], SpawnPoints[1], EnemyAmmoSetupCount, EnemyAmmoCost, EnemyProjectile, EnemyDeelay, Timer);
    }
    private void Start()
    {
        FOV = GetComponent<FOV>();
        InitialPos = transform.position;
        Current = SpawnState;
        Current.EnterState(this);
    }

    private void Update()
    {
        Current.UpdateState(this);
        if (FOV.AiCanSee)
        {
            Current = DodgeState;
        }
        else
        {
            Current = GoBack;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Current.OnTriggerEnter(this, other);
    }
    public void SwitchState(GreenAiBaseState state)
    {
        Current = state;
        state.EnterState(this);
    }
}

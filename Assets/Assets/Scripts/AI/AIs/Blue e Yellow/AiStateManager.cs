using System;
using System.Collections;
using UnityEngine;

#pragma warning disable IDE0052

[RequireComponent(typeof(TimerComponent))]
public class AiStateManager : EnemyController
{
    public Pooler pooler;
    [Serializable]
    private struct HeaderSpace
    {
        [field: SerializeField]
        public string Description { get; set; }
    }

    private AiBaseState m_current;

    #region Editor

    [Space(15)]
    [SerializeField]
    HeaderSpace m_playerStats = new HeaderSpace() { Description = "A set of values for basic functions" };

    [field: SerializeField]
    public float Speed { get; set; }

    [field: SerializeField]
    public GameObject Player { get; set; }

    [Space(15)]
    [SerializeField]
    private HeaderSpace m_searchState = new HeaderSpace() { Description = "A set of values for SearchState functions" };

    [field: SerializeField]
    public float TimeToMove { get; set; }

    [field: SerializeField]
    public float MovingTime { get; set; }

    [field: SerializeField]
    public float WanderMovingSpeed { get; set; }

    [Space(15)]
    [SerializeField]
    private HeaderSpace m_attackState  = new HeaderSpace() { Description = "A set of values for AttackState functions" };

    [field: SerializeField]
    public float MaxRange { get; set; }

    [field: SerializeField]
    public float RotationSpeed { get; set; }

    [field: SerializeField]
    public float Radius { get; set; }

    [field: SerializeField]
    public float RadiusSpeed { get; set; }

    [Space(15)]
    [SerializeField]
    private HeaderSpace m_shooting = new HeaderSpace() { Description = "A set of values for shooting settings" };

    [field: SerializeField]
    public Transform[] SpawnPoints { get; set; }  = new Transform[2];

    [field: SerializeField]
    public GameObject EnemyProjectile { get; set; }

    [field: SerializeField]
    public float EnemyDeelay { get; set; }

    #endregion

    #region Property not in editor

    public Rigidbody Body { get; set; }
    public FOV FOV { get; set; }
    public bool IsSpawned { get; set; }
    public TimerComponent Timer { get; set; }
    public int EnemyAmmoSetupCount { get; set; }
    public PrimaryWeapon EnemyWeapon { get; set; }
    public bool CanShoot { get; set; } = true;

    private readonly int EnemyAmmoCost = 0;

    public AiBaseState Current
    {
        get => m_current;
        private set
        {
            if (m_current == value)
                return;

            (m_current = value).EnterState(this);
        }
    }
    public AiChaseState ChaseState { get; set; } = new AiChaseState();
    public AiAttackState AttackState { get; set; } = new AiAttackState();
    public AiSearchState SearchState { get; set; } = new AiSearchState();

    #endregion

    public float Distance => Vector3.Distance(Body.transform.position, Player.transform.position);

    private void Awake()
    {
        Body = GetComponent<Rigidbody>();
        Timer = GetComponent<TimerComponent>();
        EnemyWeapon = new Laser(SpawnPoints[0], SpawnPoints[1], EnemyAmmoSetupCount, EnemyAmmoCost,  EnemyProjectile, EnemyDeelay, Timer);
    }

    void Start()
    {
        FOV = GetComponent<FOV>();
        Current = SearchState;
    }

    // Update is called once per frame
    void Update()
    {
        if (FOV.AiCanSee)
        {
            if (Distance > MaxRange)
                Current = ChaseState;
            else
                Current = AttackState;
        }
        else if (IsSpawned && !FOV.AiCanSee)
        {
            Current = SearchState;
        }
        Current.UpdateState(this);
    }
}


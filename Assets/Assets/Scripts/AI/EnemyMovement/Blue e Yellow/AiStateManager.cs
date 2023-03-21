using System;
using UnityEngine;

#pragma warning disable IDE0052

public class AiStateManager : MonoBehaviour
{
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

    #endregion

    #region Property not in editor

    public Rigidbody Body { get; set; }
    public FOV FOV { get; set; }
    public bool IsSpawned { get; set; }

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

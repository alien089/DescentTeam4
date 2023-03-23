using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOV : MonoBehaviour
{
    #region BackingFields

    [SerializeField]
    [Range(0f,360f)]
    private float m_angle;

    [SerializeField]
    private float m_range;
    [SerializeField]
    private LayerMask m_target, m_obstacle;
    [SerializeField]
    private GameObject m_player;

    #endregion

    #region Fields



    public bool AiCanSee { get; set; }
    public float Range => m_range;
    public float Angle => m_angle;
    public GameObject Player => m_player;

    #endregion

    private void Start()
    {
        m_player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(Check());
    }

    private IEnumerator Check()
    {
        while (true)
        {
            yield return 0.2f;
            FindPlayer();
        }
    }

    private void FindPlayer()
    {

        Collider[] range = Physics.OverlapSphere(transform.position, m_range, m_target);

        if (range.Length != 0)
        {
            Transform target = range[0].transform;
            Vector3 directionalTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionalTarget) < m_angle / 2)
            {
                float distanceTarget = Vector3.Distance(transform.position, target.position);

                AiCanSee = !Physics.Raycast(transform.position, directionalTarget, distanceTarget, m_obstacle);
            }
            else
                AiCanSee = false;
        }
        else if (AiCanSee)
        {
            AiCanSee = false;
        }
    }
}

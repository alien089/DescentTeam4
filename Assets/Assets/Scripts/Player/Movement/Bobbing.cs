using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bobbing : MonoBehaviour
{
    #region BackingFields
    [SerializeField]
    private float m_bobbingSpeed;

    [SerializeField]
    private float m_bobbingPower;

    [SerializeField]
    private bool m_CasePlayer;

    [SerializeField]
    private bool m_CaseAI;

    #endregion

    #region Field

    private Vector3 m_startingPosition;
    private PlayerMovement Player;
    private bool m_isMoving;
    private Rigidbody m_rigidBody;

    #endregion

    private void Start()
    {
        TryGetComponent<PlayerMovement>(out Player);
        TryGetComponent<Rigidbody>(out m_rigidBody);

        m_isMoving = Player.IsMoving;
        m_startingPosition = transform.position;
    }

    private void FixedUpdate()
    {
        if (m_CasePlayer)
            FixedPlayerBobbing();
        else
            FixedEnemyBobbing();
    }

    private void FixedPlayerBobbing()
    {
        m_isMoving = Player.IsMoving;
        float bobbing = Mathf.Sin(Time.time * m_bobbingSpeed) * m_bobbingPower;

        Vector3 bobbingForce = new Vector3(0f, bobbing, 0f);
        if (m_isMoving == false)
        {

            m_rigidBody.AddForce(bobbingForce, ForceMode.Force);
        }
    }

    private void FixedEnemyBobbing()
    {
        float bobbing = Mathf.Sin(Time.time * m_bobbingSpeed) * m_bobbingPower;

        Vector3 bobbingForce = new Vector3(0f, bobbing, 0f);

        m_rigidBody.AddForce(bobbingForce, ForceMode.Force);
    }
}
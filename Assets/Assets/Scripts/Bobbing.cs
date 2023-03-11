using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bobbing : MonoBehaviour
{
    #region BackingFields
    [SerializeField]
    private float _bobbingSpeed;

    [SerializeField]
    private float _bobbingPower;

    [SerializeField]
    private bool _CasePlayer;

    [SerializeField]
    private bool _CaseAI;

    #endregion

    #region Field

    private Vector3 _startingPosition;
    private PlayerController Player;
    private bool _isMoving;
    private Rigidbody _rigidBody;

    #endregion

    private void Start()
    {
        TryGetComponent<PlayerController>(out Player);
        TryGetComponent<Rigidbody>(out _rigidBody);

        _isMoving = Player.IsMoving;
        _startingPosition = transform.position;
    }

    private void FixedUpdate()
    {
        _isMoving = Player.IsMoving;
        float bobbing = Mathf.Sin(Time.time * _bobbingSpeed) * _bobbingPower;
        
        Vector3 playerPos = transform.position;
        Vector3 bobbingForce = new Vector3(0f, bobbing, 0f);
        if (_CasePlayer)
        {
            if (_isMoving == false)
            {

                _rigidBody.AddForce(bobbingForce, ForceMode.Force); print("is Bobbing");
            }
        }
        if (_CaseAI)
        {
            _rigidBody.AddForce(bobbingForce, ForceMode.Force);
        }
    }
}
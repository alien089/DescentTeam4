using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region BackingFields

    [Header("Sensibility")]
    [SerializeField]
    private float _sentibilityVertical = 1;

    [SerializeField]
    private float _sensibilityHorizontal = 1;

    [Header("Speeds")]
    [SerializeField]
    private float _forwardSpeed = 1;

    [SerializeField]
    private float _slideSpeed = 1;

    [SerializeField]
    private float _upAndDownSpeed = 1;

    [SerializeField]
    private int _rotation = 50;


    #endregion

    #region Fields

    private bool _isMoving, _canMove;
    private float _horizontalRotation, _verticalRotation;
    private Rigidbody _rigidBody;

    private ChangeCamera Camera;

    public float MoveUpwards { get => Input.GetAxisRaw("Fly") * _upAndDownSpeed; private set => MoveUpwards = value; }
    public float MoveSideWays { get => Input.GetAxisRaw("Horizontal") * _slideSpeed; private set => MoveSideWays = value; }
    public float MoveForward { get => Input.GetAxisRaw("Vertical") * _forwardSpeed; private set => MoveSideWays = value; }
    public bool LockedCursor { get; private set; } = true;
    public bool IsMoving { get => _isMoving; private set => _isMoving = value; }

    #endregion

    #region Body

    /// <summary>
    /// If adding Camera do <see cref="_cameraValue.add(Camera camere, CameraMode.newCameraMode);"/>
    /// </summary>
    private void Awake()
    {
        TryGetComponent<Rigidbody>(out _rigidBody);
        TryGetComponent<ChangeCamera>(out Camera);
    }
    private void FixedUpdate()
    {
        MovementHandler();
    }

    private void Update()
    {
        LockCursor();
        RotationHandler();
    }
    #endregion

    /// <summary>
    /// player direction follows view and sensibility option <br/>
    /// <see cref="_sensibilityHorizontal"/> <seealso cref="_sentibilityVertical"/> multiplies normal sensibility <br/>
    /// working on rotation
    /// </summary>
    private void RotationHandler()
    {
        float mouseHorizontal = Input.GetAxis("Mouse X") * _sensibilityHorizontal;
        float mouseVertical = Input.GetAxis("Mouse Y") * _sentibilityVertical;
        float rotationInput = Input.GetAxisRaw("Rotate") * _rotation;

        _verticalRotation += mouseHorizontal;
        _horizontalRotation -= mouseVertical;
        _rotation = Mathf.Clamp(_rotation, -90, 90);

        if (rotationInput != 0)
        {
            transform.Rotate((rotationInput * Time.deltaTime * Vector3.forward), Space.Self);
        }
        else
        {
            transform.rotation = Quaternion.Euler(_horizontalRotation, _verticalRotation, transform.rotation.z);
        }
    }
    // add.Torque , if rotate not 0 rotate , if rotate is 0 go to nearest angle.

    /// <summary>
    /// if it can <see cref="_canMove"/> = true <see cref="_isMoving = true"/> <br/>
    /// Adds force in the desired direction by doing <see cref=" _rigidBody.AddForce(_rigidBody.mass * (desiredAxis * desiredDirection));"/>
    /// </summary>
    private void MovementHandler()
    {
        _canMove = Camera.CanMove;
        if (_canMove)
        {
            if (MoveUpwards != 0)
            {
                _rigidBody.AddForce(_rigidBody.mass * (MoveUpwards * transform.up));
                _isMoving = true;
            }
            if (MoveSideWays != 0)
            {
                _rigidBody.AddForce(_rigidBody.mass * (MoveSideWays * transform.right));
                _isMoving = true;
            }
            if (MoveForward != 0)
            {
                _rigidBody.AddForce(_rigidBody.mass * (MoveForward * transform.forward));
                _isMoving = true;
            }
            else
            {
                _isMoving = false;
            }

        }
    }

    /// <summary>
    /// Based on bool <see cref="LockedCursor"/> ,<br/> 
    /// sets <see cref="Cursor.visible = false"/> making it so you cant see your cursor and, <br/>
    /// sets <see cref="Cursor.lockState "/> Locked making it so your cursor stays at the middle of the screen.
    /// </summary>
    private void LockCursor()
    {
        if (LockedCursor)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}

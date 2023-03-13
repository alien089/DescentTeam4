using System;
using System.Collections;
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

    [Header("zRotation Speeds")]
    [SerializeField]
    private int _rotation = 50;

    [SerializeField]
    private float _goToClosestAngleSpeed;

    [Header("Rotation When mouse X")]
    [SerializeField]
    private byte _angleToSum;


    #endregion

    #region Fields

    private float _smoothness = 2000;
    private bool _isMoving, _canMove;
    private float _horizontalRotation, _verticalRotation;
    private Rigidbody _rigidBody;
    private bool _rotateAngle = false;
    private Quaternion targetRotation;

    private CameraManager Camera;

    public float MoveUpwards { get => Input.GetAxisRaw("Fly") * _upAndDownSpeed; private set => MoveUpwards = value; }
    public float MoveSideWays { get => Input.GetAxisRaw("Horizontal") * _slideSpeed; private set => MoveSideWays = value; }
    public float MoveForward { get => Input.GetAxisRaw("Vertical") * _forwardSpeed; private set => MoveSideWays = value; }
    public bool LockedCursor { get; private set; } = true;
    public bool IsMoving { get => _isMoving; private set => _isMoving = value; }

    #endregion

    #region Body

    /// <summary>
    /// If adding Camera do <see cref="_cameraValue.add(Camera camere, ECameraMode.newCameraMode);"/>
    /// </summary>
    private void Awake()
    {
        TryGetComponent<Rigidbody>(out _rigidBody);
        TryGetComponent<CameraManager>(out Camera);
    }

    private void Start()
    {
        _rigidBody.freezeRotation = true;
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
    /// new rotation works kinda like this if the angle is 46 it rounds and divide by 90 and result is 1 than multiplies by 90 and thats the new rotaion it will have
    /// </summary>
    private void RotationHandler()
    {
        float mouseHorizontal = Input.GetAxis("Mouse X") * _sensibilityHorizontal;
        float mouseVertical = Input.GetAxis("Mouse Y") * _sentibilityVertical;
        float rotationInput = Input.GetAxisRaw("Rotate") * _rotation;

        _verticalRotation += mouseHorizontal;
        _horizontalRotation -= mouseVertical;

        float _newHorizontalRotation = Mathf.Clamp(_horizontalRotation, -89, 89);

        targetRotation = Quaternion.Euler(_newHorizontalRotation, _verticalRotation, transform.localEulerAngles.z);
        //Quaternion targetRotation = Quaternion.Euler(_newHorizontalRotation, _verticalRotation, transform.localEulerAngles.z);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 1 * Time.deltaTime * _smoothness);

        if (rotationInput != 0)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z + (rotationInput * Time.deltaTime));
        }
        else if (rotationInput == 0 && !_rotateAngle)
        {
            float newRotation = Mathf.Round(transform.localEulerAngles.z / 90) * 90;
            float zRotation = Mathf.MoveTowards(transform.localEulerAngles.z, newRotation, _goToClosestAngleSpeed * Time.deltaTime);
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, zRotation);
        }

    }

    /// <summary>
    /// if <see cref="Input.GetAxis('Mouse X')"/> is > or < 0 and <see cref="_rotateAngle = false"/> do <see cref="AddAngle(float)"/> and <see cref="_rotateAngle = true"/> <br/>
    /// else <see cref="_rotateAngle = false"/> therefore it can rotate again
    /// </summary>
    /// <param name="value"></param>
    //private void CheckMouseXAndAddAngle(float value)
    //{
    //    float xmouse = Input.GetAxis("Mouse X");
    //    switch (xmouse)
    //    {
    //        case float horizontal when horizontal > 0 && !_rotateAngle:
    //            StartCoroutine(AddAngle(value));
    //            _rotateAngle = true;
    //            break;
    //        case float horizontal when horizontal < 0 && !_rotateAngle:
    //            StartCoroutine(AddAngle(-value));
    //            _rotateAngle = true;
    //            break;
    //        case float horizontal when horizontal == 0 && _rotateAngle:
    //            _rotateAngle = false;
    //            break;
    //    }
    //}

    /// <summary>
    /// if it can <see cref="_canMove"/> = true <see cref="_isMoving = true"/> <br/>
    /// Adds force in the desired direction by doing <see cref=" _rigidBody.AddForce(_rigidBody.mass * (desiredAxis * desiredDirection));"/>
    /// </summary>
    private void MovementHandler()
    {
        _canMove = Camera.CanMove;
        if (_canMove)
        {
            if (MoveForward + MoveSideWays + MoveForward != 0)
                _isMoving = true;
            
            if (MoveUpwards != 0)
                _rigidBody.AddForce(_rigidBody.mass * (MoveUpwards * transform.up));

            if (MoveSideWays != 0)
                _rigidBody.AddForce(_rigidBody.mass * (MoveSideWays * transform.right));
           
            if (MoveForward != 0)
                _rigidBody.AddForce(_rigidBody.mass * (MoveForward * transform.forward));
            
            else
                _isMoving = false;

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

    //private IEnumerator AddAngle(float value)
    //{
    //    yield return new WaitForEndOfFrame();
    //    transform.eulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, transform.localEulerAngles.z + value);
    //}
}

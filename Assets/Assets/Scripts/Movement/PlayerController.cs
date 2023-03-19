using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IDamageable 
{
    #region BackingFields
    [Header("")]
    public int InitialShield = 100;
    public int ActualShield = 100;

    [Header("Sensibility")]
    [SerializeField]
    private float m_sentibilityVertical = 1;

    [SerializeField]
    private float m_sensibilityHorizontal = 1;

    [Header("Speeds")]
    [SerializeField]
    private float m_forwardSpeed = 1;

    [SerializeField]
    private float m_slideSpeed = 1;

    [SerializeField]
    private float m_upAndDownSpeed = 1;

    [Header("zRotation Speeds")]
    [SerializeField]
    private int m_rotation = 50;

    [SerializeField]
    private float m_goToClosestAngleSpeed;

    [Header("Rotation When mouse X")]
    [SerializeField]
    private byte m_angleToSum;

    [Header("when To invert Sensibility")]
    [SerializeField]
    private float m_lowestAngle;

    [SerializeField]
    private float m_highestAngle;

    #endregion

    #region Fields

    private readonly float m_smoothness = 2000;
    private bool m_isMoving, m_canMove;
    private float _horizontalRotation, m_verticalRotation;
    private Rigidbody _rigidBody;
    private bool m_rotateAngle = false;
    private Quaternion targetRotation;

    private CameraManager Camera;
    
    public float MoveUpwards { get => Input.GetAxisRaw("Fly") * m_upAndDownSpeed; private set => MoveUpwards = value; }
    public float MoveSideWays { get => Input.GetAxisRaw("Horizontal") * m_slideSpeed; private set => MoveSideWays = value; }
    public float MoveForward { get => Input.GetAxisRaw("Vertical") * m_forwardSpeed; private set => MoveSideWays = value; }
    public bool LockedCursor { get; private set; } = true;
    public bool IsMoving { get => m_isMoving; private set => m_isMoving = value; }

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
        Damage(2);
        LifeCheck();
        LockCursor();
        RotationHandler();
    }
    #endregion

    #region Methods

    /// <summary>
    /// player direction follows view and sensibility option <br/>
    /// <see cref="m_sensibilityHorizontal"/> <seealso cref="m_sentibilityVertical"/> multiplies normal sensibility <br/>
    /// new rotation works kinda like this if the angle is 46 it rounds and divide by 90 and result is 1 than multiplies by 90 and thats the new rotaion it will have
    /// if current angle is > <see cref="m_lowestAngle"/> and < <see cref="m_highestAngle"/> inverted sens
    /// </summary>
    private void RotationHandler()
    {
        float mouseHorizontal = Input.GetAxis("Mouse X") * m_sensibilityHorizontal;
        float mouseVertical = Input.GetAxis("Mouse Y") * m_sentibilityVertical;
        float rotationInput = Input.GetAxisRaw("Rotate") * m_rotation;
        
        if (transform.rotation.eulerAngles.z > m_lowestAngle && transform.rotation.eulerAngles.z < m_highestAngle)
        {
            mouseHorizontal *= -1f;
            mouseVertical *= -1f;
        }

        m_verticalRotation += mouseHorizontal;
        _horizontalRotation -= mouseVertical;

        float _newHorizontalRotation = Mathf.Clamp(_horizontalRotation, -89, 89);

        targetRotation = Quaternion.Euler(_newHorizontalRotation, m_verticalRotation, transform.localEulerAngles.z);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 1 * Time.deltaTime * m_smoothness);

        if (rotationInput != 0)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z + (rotationInput * Time.deltaTime));
        }
        else if (rotationInput == 0 && !m_rotateAngle)
        {
            float newRotation = Mathf.Round(transform.localEulerAngles.z / 90) * 90;
            float zRotation = Mathf.MoveTowards(transform.localEulerAngles.z, newRotation, m_goToClosestAngleSpeed * Time.deltaTime);
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, zRotation);
        }
    }

    /// <summary>
    /// if it can <see cref="m_canMove"/> = true <see cref="m_isMoving = true"/> <br/>
    /// Adds force in the desired direction by doing <see cref=" _rigidBody.AddForce(_rigidBody.mass * (desiredAxis * desiredDirection));"/>
    /// </summary>
    private void MovementHandler()
    {
        m_canMove = true /*Camera.CanMove*/;
        if (m_canMove)
        {
            if (MoveForward + MoveSideWays + MoveForward != 0)
                m_isMoving = true;
            
            if (MoveUpwards != 0)
                _rigidBody.AddForce(_rigidBody.mass * (MoveUpwards * transform.up));

            if (MoveSideWays != 0)
                _rigidBody.AddForce(_rigidBody.mass * (MoveSideWays * transform.right));
           
            if (MoveForward != 0)
                _rigidBody.AddForce(_rigidBody.mass * (MoveForward * transform.forward));
            
            else
                m_isMoving = false;

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

    public void Damage(int damage)
    {
        if(Input.GetKeyDown(KeyCode.Space))
            ActualShield -= 50;
    }

    public void LifeCheck()
    {
        if (ActualShield == 0 && StageManager.instance.PlayerState == StageManager.PlayerStates.LIVE)
            StageManager.instance.Death();
        else if (Input.GetKeyDown(KeyCode.Tab) && StageManager.instance.PlayerState == StageManager.PlayerStates.DEAD)
            ActualShield = InitialShield;
            StageManager.instance.Respawn(gameObject);
    }

    #endregion
}

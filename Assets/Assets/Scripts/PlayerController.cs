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
    private float _hoverSpeed = 1;

    [SerializeField]
    private float _slideSpeed = 1;
    
    [SerializeField]
    private float _upAndDownSpeed = 1;

    [SerializeField]
    private float _maxSpeed;

    [SerializeField]
    private int _rotation = 50;

    [Header("Cameras")]
    [SerializeField]
    private Camera _firstPersonCamera;

    [SerializeField]
    private Camera _rearCamera;
    #endregion

    #region Fields

    private float _horizontalRotation, _verticalRotation;

    private bool _camera1 = true;
    private bool _camera2 = false;


    public bool LockedCursor
    {
        get;
        private set;
    } = true;


    #endregion

    #region Body

    private void Update()
    {
        ChangeCamera();
        LockCursor();
        RotationHandler();
        Move();

    }
    #endregion
    /// <summary>
    /// player direction follows view and sensibility option <br/>
    /// <see cref="_sensibilityHorizontal"/> <seealso cref="_sentibilityVertical"/> multiplies normal sensibility
    /// </summary>
    private void RotationHandler()
    {
        float mouseHorizontal = Input.GetAxis("Mouse X") * _sensibilityHorizontal;
        float mouseVertical = Input.GetAxis("Mouse Y") * _sentibilityVertical;

        _verticalRotation += mouseHorizontal;
        _horizontalRotation -= mouseVertical;

        float rotationInput = Input.GetAxisRaw("Rotate");


        Vector3 rotation = new Vector3(_horizontalRotation, _verticalRotation, transform.rotation.z);
        transform.eulerAngles = rotation;
        transform.Rotate(Vector3.forward, rotationInput * _rotation * Time.deltaTime);
    }

    private void Move()
    {
        float moveY = Input.GetAxisRaw("Vertical") * _hoverSpeed * Time.deltaTime;
        float moveX = Input.GetAxisRaw("Horizontal") * _slideSpeed * Time.deltaTime;
        float moveZ = Input.GetAxisRaw("Fly") * _upAndDownSpeed * Time.deltaTime;

        transform.position += transform.forward * moveY + transform.right * moveX + transform.up * moveZ;

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

    private void BobbingHandler()
    {

    }

    IEnumerator Bobbing()
    {
        yield return new WaitForSeconds(0.5f);
        transform.position += new Vector3(0, 0.5f, 0);

    }
    private void ChangeCamera()
    {

        if (_camera1)
        {
            _firstPersonCamera.gameObject.SetActive(true);
        }
        else
        {
            _firstPersonCamera.gameObject.SetActive(false);
        }
        if (_camera2)
        {
            _rearCamera.gameObject.SetActive(true);
        }
        else
        {
            _rearCamera.gameObject.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.R) && _camera1)
        {
            _camera1 = false;
            _camera2 = true;
        }
        else if (Input.GetKeyDown(KeyCode.R) && _camera2)
        {
            _camera1 = true;
            _camera2 = false;
        }
    }
}

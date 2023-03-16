using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region BackingFields

    [SerializeField]
    private float _sentibilityVertical = 1;

    [SerializeField]
    private float _sensibilityHorizontal = 1;

    [SerializeField]
    private float _hoverSpeed = 1;

    [SerializeField]
    private float _maxSpeed;

    [SerializeField]
    private float _rotationSmoothness;

    [SerializeField]
    private int _rotation;

    [SerializeField]
    private Camera _firstPersonCamera;

    [SerializeField]
    private Camera _rearCamera;
    #endregion

    #region Fields

    private float _horizontalRotation;
    private float _verticalRotation;

    public bool LockedCursor
    {
        get;
        private set;
    } = true;

    #endregion

    #region Body

    private void Update()
    {
        LockCursor();
        DirectionHandler();
        Acceleration();
        Rotation(_rotation);
        //StartCoroutine(Bobbing());
    }
    #endregion
    /// <summary>
    /// player direction follows view and sensibility option <br/>
    /// <see cref="_sensibilityHorizontal"/> <seealso cref="_sentibilityVertical"/> multiplies normal sensibility
    /// </summary>
    private void DirectionHandler()
    {
        float mouseHorizontal = Input.GetAxis("Mouse X") * _sensibilityHorizontal;
        float mouseVertical = Input.GetAxis("Mouse Y") * _sentibilityVertical;


        _verticalRotation += mouseHorizontal;
        _horizontalRotation -= mouseVertical;

        transform.eulerAngles = new Vector3(_horizontalRotation, _verticalRotation, transform.rotation.z);
    }

    /// <summary>
    /// while holding <seealso cref="Horizontal"/> (w or a ) <see cref="_hoverSpeed"/> increases till <seealso cref="_maxSpeed"/>
    /// </summary>
    private void Acceleration()
    {
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 move = transform.forward * moveVertical;
        float currentSpeed = Mathf.Clamp(move.magnitude * _hoverSpeed, 0f, _maxSpeed);
        transform.position += move.normalized * currentSpeed * Time.deltaTime;

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
    /// <summary>
    /// e and q to 
    /// </summary>
    private void Rotation(int value)
    {
        bool rotateE;
        bool rotateQ;
        if (Input.GetKeyDown(KeyCode.E))
        {
            rotateE = true;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            rotateQ = true;
        }
        rotateE = false;
        rotateQ = false;
        print(rotateQ);
        print(rotateE);
    }
    private void ChangeCamera()
    {
        bool _camera1;
        bool _camera2;
        
        if (Input.GetKeyDown(KeyCode.R))
        {

        }
    }
}

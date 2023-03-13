using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

    #region BackingFields

    [Header("Cameras")]
    [SerializeField]
    private Camera _firstPersonCamera;

    [SerializeField]
    private Camera _rearCamera;

    [SerializeField]
    private float _angleWhenMoving;

    [SerializeField]
    private float _timeToReach;

    #endregion

    #region fields

    public bool CanMove { get; private set; }

    private float _ref;
    private bool _rotateAngle;
    private ECameraMode _cameraMode;
    private readonly Dictionary<Camera, ECameraMode> _cameraValue = new Dictionary<Camera, ECameraMode>();
    public ECameraMode CameraMode
    {
        get => _cameraMode;
        private set
        {
            ECameraMode oldCamera = _cameraMode;
            _cameraMode = value;
            OnChangingCameraMode(oldCamera);
        }
    }

    #endregion

    #region body
    /// <summary>
    /// If adding Camera do <see cref="_cameraValue.add(Camera camere, ECameraMode.newCameraMode);"/>
    /// </summary>
    private void Awake()
    {
        _cameraValue.Add(_firstPersonCamera, ECameraMode.FirstPerson);
        _cameraValue.Add(_rearCamera, ECameraMode.RearView);
        CameraMode = ECameraMode.FirstPerson;
    }

    private void FixedUpdate()
    {

    }
    /// <summary>
    /// If adding Camera do <see cref="_cameraValue.add(Camera camere, ECameraMode.newCameraMode);"/>
    /// </summary>
    private void Update()
    {
        float xmouse = Input.GetAxis("Mouse X");
        Camera.current.transform.rotation = Quaternion.Euler(new Vector3(transform.eulerAngles.x, transform.eulerAngles.y,
            Mathf.SmoothDampAngle(Camera.current.transform.eulerAngles.z, transform.eulerAngles.z + xmouse * 20, ref _ref, _timeToReach)));
        if (Input.GetKeyDown(KeyCode.R))
        {
            CameraMode = System.Enum.IsDefined(typeof(ECameraMode), CameraMode + 1) ? ++CameraMode : 0;
        }
        //CheckMouseXAndAddAngle(_angleWhenMoving);
        switch (CameraMode)
        {
            case ECameraMode.RearView:
                CanMove = false;
                break;
            case ECameraMode.FirstPerson:
                CanMove = true;
                break;
            default:
                CanMove = true;
                break;
        }
    }


    /// <summary>
    /// if 
    /// </summary>
    /// <param name="value"></param>
    private void CheckMouseXAndAddAngle(float value) //using in update
    {
        float xmouse = Input.GetAxis("Mouse X");
        switch (xmouse)
        {
            case float horizontal when horizontal > 0 && !_rotateAngle:
                StartCoroutine(AddAngle(-value));
                _rotateAngle = true;
                break;
            case float horizontal when horizontal < 0 && !_rotateAngle:
                StartCoroutine(AddAngle(value));
                _rotateAngle = true;
                break;
            case float horizontal when horizontal == 0 && _rotateAngle:
                //Camera.current.transform.eulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, transform.localEulerAngles.z);
                //float newRotationZ = Mathf.SmoothDamp(transform.localEulerAngles.z, transform.localEulerAngles.z + value, ref _ref, 3f);
                //Camera.current.transform.eulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y ,newRotationZ);

                //float current = transform.eulerAngles.z;
                //float smoothangle = Mathf.LerpAngle(current, transform.eulerAngles.z, Time.deltaTime * _smoothness);
                //Camera.current.transform.eulerAngles = new Vector3(transform.eulerAngles.z, transform.eulerAngles.y, smoothangle);

                Camera.current.transform.rotation = Quaternion.Euler(new Vector3(transform.eulerAngles.x, transform.eulerAngles.y,
                    Mathf.SmoothDampAngle(Camera.current.transform.eulerAngles.z, transform.eulerAngles.z + xmouse * 20, ref _ref, _timeToReach)));

                _rotateAngle = false;
                break;
        }
    }

    #endregion 

    /// <summary>
    /// For each <see cref="_cameraValue"/> check if <see cref="CameraMode"/> is the current value <br/>
    /// if its not <see cref="GameObject.SetActive(false)"/>
    /// </summary>
    /// <param name="oldCamera"></param>
    private void OnChangingCameraMode(ECameraMode oldCamera) //using in CameraMode
    {
        foreach (KeyValuePair<Camera, ECameraMode> kvp in _cameraValue)
        {
            if (CameraMode != kvp.Value)
            {
                kvp.Key.gameObject.SetActive(false);
                continue;
            }

            kvp.Key.gameObject.SetActive(true);
        }
    }
    private IEnumerator AddAngle(float value)
    {
        yield return new WaitForEndOfFrame();
        //float smoothedValue = Mathf.Lerp(0, value, 1f);
        //float targetZ = Mathf.Lerp(transform.localEulerAngles.z, transform.localEulerAngles.z + smoothedValue, 3f);

        float xmouse = Input.GetAxis("Mouse X");
        //Camera.current.transform.eulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, targetZ);
        Camera.current.transform.rotation = Quaternion.Euler(new Vector3(transform.eulerAngles.x, transform.eulerAngles.y,
        Mathf.SmoothDampAngle(Camera.current.transform.eulerAngles.z, transform.eulerAngles.z + xmouse * 20, ref _ref, _timeToReach)));

    }
}

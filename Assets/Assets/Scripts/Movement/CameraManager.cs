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

        BlockMovement();
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
    /// <summary>
    /// when <see cref="ECameraMode.RearView"/> bool false <br/>
    /// default bool = true;
    /// </summary>
    private void BlockMovement()
    {
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
}

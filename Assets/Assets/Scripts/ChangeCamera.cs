using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{

    #region BackingFields

    [Header("Cameras")]
    [SerializeField]
    private Camera _firstPersonCamera;

    [SerializeField]
    private Camera _rearCamera;

    #endregion

    #region fields

    public bool CanMove { get; private set; }
    private CameraMode _cameraMode;
    private readonly Dictionary<Camera, CameraMode> _cameraValue = new Dictionary<Camera, CameraMode>();
    public CameraMode CameraMode
    {
        get => _cameraMode;
        private set
        {
            CameraMode oldCamera = _cameraMode;
            _cameraMode = value;
            OnChangingCameraMode(oldCamera);
        }
    }

    #endregion

    /// <summary>
    /// If adding Camera do <see cref="_cameraValue.add(Camera camere, CameraMode.newCameraMode);"/>
    /// </summary>
    private void Awake()
    {
        _cameraValue.Add(_firstPersonCamera, CameraMode.FirstPerson);
        _cameraValue.Add(_rearCamera, CameraMode.RearView);
        CameraMode = CameraMode.FirstPerson;
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.R))
        {
            CameraMode = System.Enum.IsDefined(typeof(CameraMode), CameraMode + 1) ? ++CameraMode : 0;
        }
        switch (CameraMode)
        {
            case CameraMode.RearView:
                CanMove = false;
                break;
            case CameraMode.FirstPerson:
                CanMove = true;
                break;
            default:
                CanMove = true;
                break;
        }
    }

    /// <summary>
    /// for each <see cref="_cameraValue"/> check if <see cref="CameraMode"/> is the current value <br/>
    /// if its not <see cref="GameObject.SetActive(false)"/>
    /// </summary>
    /// <param name="oldCamera"></param>
    private void OnChangingCameraMode(CameraMode oldCamera)
    {
        foreach (KeyValuePair<Camera, CameraMode> kvp in _cameraValue)
        {
            if (CameraMode != kvp.Value)
            {
                kvp.Key.gameObject.SetActive(false);
                continue;
            }

            kvp.Key.gameObject.SetActive(true);
        }
    }
}

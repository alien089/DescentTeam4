using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

    #region BackingFields

    [Header("Cameras")]
    [SerializeField]
    private Camera m_firstPersonCamera;

    [SerializeField]
    private Camera m_rearCamera;

    [SerializeField]
    private float m_angleWhenMoving;

    [SerializeField]
    private float m_timeToReach;

    #endregion

    #region fields

    public bool CanMove { get; private set; }

    private Camera m_currentCamerea;
    private float m_ref;
    private ECameraMode m_cameraMode;
    private readonly Dictionary<Camera, ECameraMode> m_cameraValue = new Dictionary<Camera, ECameraMode>();
    public ECameraMode CameraMode
    {
        get => m_cameraMode;
        private set
        {
            ECameraMode oldCamera = m_cameraMode;
            m_cameraMode = value;
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
        m_cameraValue.Add(m_firstPersonCamera, ECameraMode.FirstPerson);
        m_cameraValue.Add(m_rearCamera, ECameraMode.RearView);
        CameraMode = ECameraMode.FirstPerson;
    }

    /// <summary>
    /// If adding Camera do <see cref="_cameraValue.add(Camera camere, ECameraMode.newCameraMode);"/>
    /// </summary>
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            CameraMode = System.Enum.IsDefined(typeof(ECameraMode), CameraMode + 1) ? ++CameraMode : 0;
        }

        //BlockMovement();

        if (m_currentCamerea != m_rearCamera && StageManager.instance.PlayerState == StageManager.PlayerStates.LIVE)
        {
            float xmouse = Input.GetAxis("Mouse X");
            m_currentCamerea.transform.rotation = Quaternion.Euler(new Vector3(transform.eulerAngles.x, transform.eulerAngles.y,
               Mathf.SmoothDampAngle(m_currentCamerea.transform.eulerAngles.z, transform.eulerAngles.z + xmouse * 20, ref m_ref, m_timeToReach)));
        }
    }

    #endregion

    #region Methods
    /// <summary>
    /// For each <see cref="m_cameraValue"/> check if <see cref="CameraMode"/> is the current value <br/>
    /// if its not <see cref="GameObject.SetActive(false)"/>
    /// </summary>
    /// <param name="oldCamera"></param>
    private void OnChangingCameraMode(ECameraMode oldCamera) //using in CameraMode
    {
        foreach (KeyValuePair<Camera, ECameraMode> kvp in m_cameraValue)
        {
            if (CameraMode != kvp.Value)
            {
                kvp.Key.gameObject.SetActive(false);
                continue;
            }

            kvp.Key.gameObject.SetActive(true);
            m_currentCamerea = kvp.Key;
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

    #endregion

}

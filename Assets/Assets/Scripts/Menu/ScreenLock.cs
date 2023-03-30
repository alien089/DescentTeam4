using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenLock : MonoBehaviour
{
    [SerializeField]
    private KeyCode m_keyForCursor = KeyCode.T;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    private void Update()
    {
        HoldKeyForCursor();
    }

    /// <summary>
    /// while pressing Desired Key show cursor
    /// </summary>
    public void HoldKeyForCursor()
    {
        if (Input.GetKey(m_keyForCursor))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}

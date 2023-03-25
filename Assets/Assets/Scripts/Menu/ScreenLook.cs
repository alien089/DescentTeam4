using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenLook : MonoBehaviour
{
    [SerializeField]
    private KeyCode m_keyForCursor = KeyCode.T;

    private void Update()
    {
        HoldKeyForCursor();
    }

    private void OnDestroy()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
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

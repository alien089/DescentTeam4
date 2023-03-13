using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasMan : MonoBehaviour
{
    [SerializeField]
    private Text _angleText;

    private void Update()
    {
        float lockedAngle = (float)Math.Round(transform.localEulerAngles.z);
        _angleText.text = "Angle z: " + lockedAngle.ToString();

    }
}

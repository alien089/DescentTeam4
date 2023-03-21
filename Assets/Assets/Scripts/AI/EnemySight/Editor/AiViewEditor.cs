using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(FOV))]
public class AiViewEditor : Editor
{
    private void OnSceneGUI()
    {
        FOV fov = (FOV)target;
        Handles.color = Color.cyan;
        Handles.DrawWireArc(fov.transform.position, Vector3.up, Vector3.forward, 360, fov.Range);

        Vector3 angle1 = DirectionFromAngle(fov.transform.eulerAngles.y, -fov.Angle / 2);
        Vector3 angle2 = DirectionFromAngle(fov.transform.eulerAngles.y, fov.Angle / 2);

        Handles.color = Color.green;
        Handles.DrawLine(fov.transform.position, fov.transform.position + angle1 * fov.Range);
        Handles.DrawLine(fov.transform.position, fov.transform.position + angle2 * fov.Range);

        if (fov.AiCanSee)
        {
            Handles.color = Color.red;
            Handles.DrawLine(fov.transform.position, fov.Player.transform.position);
        }
    }
    private Vector3 DirectionFromAngle(float euler, float angle)
    {
        angle += euler;

        return new Vector3(Mathf.Sin(angle * Mathf.Rad2Deg), 0, Mathf.Cos(angle * Mathf.Deg2Rad));
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMesh : MonoBehaviour
{
    [SerializeField]
    private GameObject _newMesh;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == 6)
        {
            MeshFilter mesh = GetComponent<MeshFilter>();
            mesh.sharedMesh = _newMesh.GetComponent<MeshFilter>().sharedMesh;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMesh : MonoBehaviour
{
    [SerializeField]
    private GameObject m_newMesh;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == 6)
        {
            MeshFilter mesh = GetComponent<MeshFilter>();
            mesh.sharedMesh = m_newMesh.GetComponent<MeshFilter>().sharedMesh;
        }
    }
}

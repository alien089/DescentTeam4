using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactorDoor : MonoBehaviour
{
    [SerializeField]
    private Animator m_openDoor;

    [SerializeField]
    private string _nameOfBool;

    private bool open;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        open = StageManager.instance.BossDead;
        if (open == true)
        {
            m_openDoor.SetBool(_nameOfBool, true);
        }
    }
}

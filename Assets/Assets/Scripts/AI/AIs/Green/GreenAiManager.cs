using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenAiManager : MonoBehaviour
{
    [Serializable]
    private struct HeaderSpace
    {
        [field: SerializeField]
        public string Description { get; set; }
    }

    #region Editor

    [Space(15)]
    [SerializeField]
    HeaderSpace m_playerStats = new HeaderSpace() { Description = "A set of values for basic functions" };



    public Rigidbody Body;
    public GameObject Player { get; set; }
    public FOV FOV { get; set; }


    #endregion

}

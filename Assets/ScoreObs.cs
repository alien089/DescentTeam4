using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreObs : MonoBehaviour
{
    public static ScoreObs Instance;

    [System.Serializable]
    public struct Obs
    {
        public int ShieldBonus;
        public int EnergyBonus;
        public int HostageBonus;
        public int SkillBonus;
        public int FullRescueBonus;
        public int TotalScore;
    }

    public Obs MyObs;

    public void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}

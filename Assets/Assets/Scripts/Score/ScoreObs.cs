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

        public int KilledBlueEnemy;
        public int KilledYellowEnemy;
        public int KilledGreenEnemey;
        public int KilledReactor;

        public int BluePoint;
        public int YellowPoint;
        public int GreenPoint;
        public int ReactorPoint;

        public int EnemyPoint;


    }
    private void Start()
    {
        MyObs.KilledBlueEnemy = 0;
        MyObs.KilledGreenEnemey = 0;
        MyObs.KilledYellowEnemy = 0;
        MyObs.KilledReactor = 0;
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

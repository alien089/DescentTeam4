using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSaver : MonoBehaviour
{
    public static ScoreSaver Instance;

    [System.Serializable]
    public struct Sr
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

    public Sr MyObs;

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

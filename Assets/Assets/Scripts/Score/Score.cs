using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{

    [Space(10)]
    [SerializeField]
    private GameObject _player;

    #region BackingFields
    [Space(10)]
    [Header("OnDestroyOrCollecting")]
    [SerializeField]
    private int _scoreOnDestroyEnemyYellow = 200;

    [SerializeField]
    private int _scoreOnDestroyEnemyBlue = 300;

    [SerializeField]
    private int _scoreOnDestroyEnemyGreen = 500;

    [SerializeField]
    private int _scoreOnDestroyEnemyReactor = 5000;

    [Header("HostageScores")]
    [SerializeField]
    private int _scoreOnCOllectingHostage = 1000;
    [SerializeField]
    private int maxHostageNumber;
    [SerializeField]
    private int currentHostageNumber;    //=> StageManager.instance.HostagesCount;
    [SerializeField]
    private int _bonusScoreIfAllHostages;
    [SerializeField]
    private int _noBonusHostages = 0;

    [Header("Skill bonus")]

    [SerializeField]
    private int _skillBonus = 0;

    [Space(10)]
    [Header("BonusScore")]
    [SerializeField]
    private int _pointOnShiledAccoumolated = 19;

    [SerializeField]
    private int _pointOnStaminaAccomoulated = 10;

    #endregion


    /// <summary>
    /// PlayerMovement class got in the start
    /// </summary>
    public PlayerStats PlayerStats { get; private set; }

    /// <summary>
    /// PlayerShooting Class got in the start
    /// </summary>
    public PlayerShooting PlayerShooting { get; private set; }
    
    /// <summary>
    /// it will stay as it only works for further levels
    /// </summary>
    public int SkillBonus => _skillBonus;

    /// <summary>
    /// Adds bonus if reached max or stays at noBonus
    /// </summary>
    public int BonusFullHostageScore => currentHostageNumber >= maxHostageNumber ? _bonusScoreIfAllHostages : _noBonusHostages;

    /// <summary>
    /// Toatal bonus shield score
    /// </summary>
    public int ShieldScore => (int)(_pointOnShiledAccoumolated * Mathf.Round(PlayerStats.Shield));

    /// <summary>
    /// Total bonus Stamina score 
    /// </summary>
    public int EnergyScore => (_pointOnStaminaAccomoulated * Convert.ToInt32(((Laser)PlayerShooting.m_PrimaryList[0]).AmmoCount));
    /// <summary>
    /// Total destroy enemies bonus
    /// </summary>
    public int EnemyDestroyBonus => (_scoreOnDestroyEnemyGreen  * ScoreSaver.Instance.MyObs.KilledGreenEnemey) + (_scoreOnDestroyEnemyYellow * ScoreSaver.Instance.MyObs.KilledYellowEnemy) + (_scoreOnDestroyEnemyBlue * ScoreSaver.Instance.MyObs.KilledBlueEnemy) + (_scoreOnDestroyEnemyReactor * ScoreSaver.Instance.MyObs.KilledReactor);

    /// <summary>
    /// Total hostage Bonus
    /// </summary>
    public int TotalHostageBonus => _scoreOnCOllectingHostage + BonusFullHostageScore;

    /// <summary>
    /// Score to show in during the game
    /// </summary>
    public int ScoreToShow => EnemyDestroyBonus + TotalHostageBonus + SkillBonus;

    /// <summary>
    /// Score after adding everything
    /// </summary>
    public int TotalScore => ShieldScore + EnergyScore + TotalHostageBonus + EnemyDestroyBonus;

    /// <summary>
    /// Initializes the <see cref="PlayerStats"/> and <see cref="PlayerShooting"/> fields by getting the corresponding components from the player object <br/> doing <see cref="GetComponent{T}"/>
    /// </summary>
    private void Start() => (PlayerStats, PlayerShooting) = (_player.GetComponent<PlayerStats>(), _player.GetComponent<PlayerShooting>());



    private void Update() => SaveData();


    void SaveData()
    {
        ScoreSaver.Instance.MyObs.EnergyBonus = EnergyScore;
        ScoreSaver.Instance.MyObs.ShieldBonus = ShieldScore;
        ScoreSaver.Instance.MyObs.HostageBonus = BonusFullHostageScore;
        ScoreSaver.Instance.MyObs.FullRescueBonus = TotalHostageBonus;
        ScoreSaver.Instance.MyObs.TotalScore = TotalScore;
        ScoreSaver.Instance.MyObs.EnemyPoint = EnemyDestroyBonus;
        ScoreSaver.Instance.MyObs.BluePoint = (_scoreOnDestroyEnemyBlue * ScoreSaver.Instance.MyObs.KilledBlueEnemy);
        ScoreSaver.Instance.MyObs.GreenPoint = (_scoreOnDestroyEnemyGreen * ScoreSaver.Instance.MyObs.KilledGreenEnemey);
        ScoreSaver.Instance.MyObs.YellowPoint = (_scoreOnDestroyEnemyYellow * ScoreSaver.Instance.MyObs.KilledYellowEnemy);
        ScoreSaver.Instance.MyObs.ReactorPoint = (_scoreOnDestroyEnemyReactor * ScoreSaver.Instance.MyObs.KilledReactor);
    }
}

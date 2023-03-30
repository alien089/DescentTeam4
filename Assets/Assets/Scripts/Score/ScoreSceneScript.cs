using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSceneScript : MonoBehaviour
{
    [SerializeField]
    private Text _shieldText;

    [SerializeField]
    private Text _staminaText;

    [SerializeField]
    private Text _hostageText;

    [SerializeField]
    private Text _skillText;

    [SerializeField]
    private Text _rescueText;

    [SerializeField]
    private Text _scoreText;

    private void Start()
    {
        _shieldText.text = ScoreSaver.Instance.MyObs.ShieldBonus.ToString();
        _staminaText.text = ScoreSaver.Instance.MyObs.EnergyBonus.ToString();
        _hostageText.text = ScoreSaver.Instance.MyObs.HostageBonus.ToString();
        _skillText.text = ScoreSaver.Instance.MyObs.SkillBonus.ToString();
        _rescueText.text = ScoreSaver.Instance.MyObs.FullRescueBonus.ToString();
        _scoreText.text = ScoreSaver.Instance.MyObs.TotalScore.ToString();
    }
}
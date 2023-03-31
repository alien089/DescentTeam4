using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        _shieldText.text = "Shield Bonus: " + ScoreSaver.Instance.MyObs.ShieldBonus.ToString();
        _staminaText.text = "Energy Bonus: " + ScoreSaver.Instance.MyObs.EnergyBonus.ToString();
        _hostageText.text = "Hostage Bonus: " + ScoreSaver.Instance.MyObs.HostageBonus.ToString();
        _skillText.text = "Skill Bonus: " + ScoreSaver.Instance.MyObs.SkillBonus.ToString();
        _rescueText.text = "Full Rescue Bonus: " + ScoreSaver.Instance.MyObs.FullRescueBonus.ToString();
        _scoreText.text = "Total Score: " + ScoreSaver.Instance.MyObs.TotalScore.ToString();
    }

    private void Update()
    {
        if (Input.anyKey)
        {
            SceneManager.LoadScene(0);
        }
    }
}
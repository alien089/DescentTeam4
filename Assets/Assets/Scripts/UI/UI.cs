using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ConcussionMissile))]
public class UI : MonoBehaviour
{
    public Text Death;
    public Text GameOver;
    public Text Notification;

    [Header("")]
    private Score _score;

    [SerializeField]
    private Image _keyCardRed;

    [SerializeField]
    private Texture _rightCircle;
    [SerializeField]
    private Texture _leftCircle;
    [Header("Weapon")]

    [SerializeField]
    private Slider _staminaSliderLeft;

    [SerializeField]
    private Slider _staminaSliderRight;

    [SerializeField]
    private RawImage CrosshairConcussion;

    [SerializeField]
    private RawImage CrosshairHoming;

    [SerializeField]
    private Text _lives;

    [SerializeField]
    private Text _stamina;
    [SerializeField]
    private Text _shield;
    [SerializeField]
    private Text _showScore;
    [SerializeField]
    private PickUpCard _pickUp;
    [SerializeField]
    private RawImage _showShieldInterface;

    [SerializeField]
    private Texture[] _Textures;

    [SerializeField]
    private int[] _healths;

    private void Start() => _score = transform.parent.parent.GetComponent<Score>();



    private void Update()
    {

        PreUpdate();

        int x = (int)Mathf.Round(_score.PlayerStats.Shield);
        int y = (int)Mathf.Round(((Laser)_score.PlayerShooting.m_PrimaryList[0]).AmmoCount);

        _stamina.text = y.ToString();
        _shield.text = x.ToString();

        _staminaSliderLeft.value = _staminaSliderRight.value = y;

        if (_pickUp.KeyCard1)
            _keyCardRed.color = new Color(_keyCardRed.color.r, _keyCardRed.color.g, _keyCardRed.color.b, 1);

        _showScore.text = "Score: " + _score.ScoreToShow.ToString();


        bool shootThis = false;
        CrosshairConcussion.texture = shootThis == true ? _leftCircle : _rightCircle;

        _lives.text = "Life: " + StageManager.instance.m_PlayerLives.ToString();

        for (int i = 0; i < _healths.Length; i++)
        {
            if (_score.PlayerStats.Shield <= _healths[i])
            {
                _showShieldInterface.texture = _Textures[i];
            }
        }

        if(_score.PlayerShooting.ActualSecondary == 0)
        {
            CrosshairHoming.gameObject.SetActive(false);
            CrosshairConcussion.gameObject.SetActive(true);
        }
        else
        {
            CrosshairHoming.gameObject.SetActive(true);
            CrosshairConcussion.gameObject.SetActive(false);
        }

        CrosshairHoming.texture = ((HomingMissile)_score.PlayerShooting.m_SecondaryList[1]).m_NextShot == 0 ? _rightCircle : _leftCircle;
        CrosshairConcussion.texture = ((ConcussionMissile)_score.PlayerShooting.m_SecondaryList[0]).m_NextShot == 0 ? _rightCircle : _leftCircle;
    }




    void PreUpdate()
    {
        CheckDeath();

        CheckDeath();
    }

    private void CheckGameOver()
    {
        if (StageManager.instance.PlayerState == StageManager.PlayerStates.GAMEOVER)
            GameOver.gameObject.SetActive(true);
        else
            GameOver.gameObject.SetActive(false);
    }

    private void CheckDeath()
    {
        if (StageManager.instance.PlayerState == StageManager.PlayerStates.DEAD)
            Death.gameObject.SetActive(true);
        else
            Death.gameObject.SetActive(false);
    }
}

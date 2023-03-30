using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ConcussionMissile))]
public class UI : MonoBehaviour
{
    [SerializeField]
    private Slider _staminaSliderLeft;

    [SerializeField]
    private Slider _staminaSliderRight;
    private Score _score; // player shooting && player move + score

    [SerializeField]
    private GameObject _player;

    [SerializeField]
    private Image _keyCardRed;

    [SerializeField]
    private Texture _rightCircle;
    [SerializeField]
    private Texture _leftCircle;

    [SerializeField]
    private Text _lives;
    [SerializeField]
    private RawImage Crosshair;
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

    private void Start() => _score = _player.GetComponent<Score>();



    private void Update()
    {
        int x = (int)Mathf.Round(_score.PlayerStats.Shield);
        int y = (int)Mathf.Round(((Laser)_score.PlayerShooting.m_PrimaryList[0]).AmmoCount);

        _stamina.text = y.ToString();
        _shield.text = x.ToString();

        _staminaSliderLeft.value = _staminaSliderRight.value = y;

        if (_pickUp.KeyCard1)
            _keyCardRed.color = new Color(_keyCardRed.color.r, _keyCardRed.color.g, _keyCardRed.color.b, 1);

        _showScore.text = "Score: " + _score.TotalScore.ToString();


        bool shootThis = false;
        Crosshair.texture = shootThis == true ? _leftCircle : _rightCircle;

        _lives.text = "Life: " + StageManager.instance.m_PlayerLives.ToString();

        for (int i = 0; i < _healths.Length; i++)
        {
            if (_score.PlayerStats.Shield <= _healths[i])
            {
                _showShieldInterface.texture = _Textures[i];
            }
        }


        //bool missile = _missile.Shoot();

        //Crosshair.texture = missile == false ? _rightCircle : _leftCircle;
        // cambia cerchio in base al arma momentanea

        // change texture in base of current
    }

    /*Energy. It shows how much Energy the player has. It only shows the whole number of the value. It does not do the rounding. For example, both 11.2 and 11.7 would be written as 11.
Energy sliders. These are two sliders related to the amount of Energy the player has. They are identical and symmetric. The slider is empty when Energy is zero, and is full if the Energy is equal or above 100. 
Shield. It shows the amount of Shield the player has. It works the same way as the Energy value.
The shield indicator. This gives a visual representation of the Shield value. They are multiple sprites that change depending on the amount of Shield left. Specifically, there are 10 sprites:
0-9
10-19
20-29
30-39
40-49
50-59
60-69
70-79
80-89
90+
Primary weapon: Shows the sprite for the current primary weapon and the name of the weapon
For the Laser, it shows the level (for us it would be LVL: 1)
For the Vulcan, it shows the amount of ammunition left
Secondary weapon: Shows the sprite of the current secondary weapon, its name and the amount of missiles left
Shows three colors. They are all dark colors, as if they were turned off. When the player collects a keycard, the relative color would brighten up. In our case for the first level, only the red one would light up.
Crossair is made of three parts (different sprites were produced for different events):
The X in the center of the screen
The two arrows beneath. They are lighted up when the player is not shooting with the primary weapon and are darker when the player shoots
The two circles represent from which part the next missile would be shot. If the next missile would be shot from the left, then the left circle would be bright and the right one dark, and vice versa.
Notification: All other notifications written in the document, like the fact that a door is closed or that a door is closed or the fact that the player has no ammo, are written on the top of the screen with a bright green font.
In the top left corner the number of lives remaining is displayed
In the top right corner the score is displayed. */

}

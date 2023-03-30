using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[RequireComponent(typeof(PlayerShooting))]
public class ChangeRender : MonoBehaviour
{
    [Header("wapon name")]
    [SerializeField]
    private Text _text;

    [Header("Select mode")]
    [SerializeField]
    private bool _primary;

    [Header("values for primary weapon")]
    [SerializeField]
    private string _laserText = "laser";

    [SerializeField]
    private string _vulcanText = "vulcan";

    [SerializeField]
    private Texture _laser;

    [SerializeField]
    private Texture _vulcan;

    [SerializeField]
    private Text _vulcanAmmoCount;

    [Header("values for secondary weapon")]
    [SerializeField]
    private string _missileText = "missile";

    [SerializeField]
    private string _homingMissileText = "homing missile";

    [SerializeField]
    private Text _secondaryAmmoCount;

    [SerializeField]
    private Texture _missile;

    [SerializeField]
    private Texture _homingMissile;


    private PlayerShooting _weapons;
    private RawImage _image;
    private Texture _currentTexture;

    private void Start() => (_weapons, _image) = (transform.parent.parent.parent.GetComponent<PlayerShooting>(), GetComponent<RawImage>());

    void Update()
    {
        PreUpdate();

        PostUpdate();
    }

    private void PreUpdate()
    {
        TextChanger();

        TextureChanger();
    }

    private void PostUpdate()
    {
        if (!_primary)
        {
            ChangeAmmoText();
            return;
        }
        _vulcanAmmoCount.text = _weapons.ActualPrimary == 1 ? ((Vulcan)_weapons.PrimaryList[1]).AmmoCount.ToString() : string.Empty;
    } 

    /// <summary>
    /// if primary change string to the name of the current primary weapon else do the same for secondary weapon
    /// </summary>
    private void TextChanger() => _text.text = _primary ? (_weapons.ActualPrimary == 0 ? _laserText : _vulcanText) : (_weapons.ActualSecondary == 0 ? _missileText : _homingMissileText);

    /// <summary>
    /// if primary change image to the current primary weapon else do the same for secondary weapon
    /// </summary>
    private void TextureChanger() => (_image.texture, _currentTexture) = (_currentTexture, _primary ? (_weapons.ActualPrimary == 0 ? _laser : _vulcan) : (_weapons.ActualSecondary == 0 ? _missile : _homingMissile));

    /// <summary>
    /// Write ammocount of current secondaryWeapon;
    /// </summary>
    private void ChangeAmmoText() => _secondaryAmmoCount.text = _weapons.ActualSecondary == 0 ? _weapons.SecondaryList[0].AmmoCount.ToString() : _weapons.SecondaryList[1].AmmoCount.ToString();


}
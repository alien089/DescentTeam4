using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStuff : MonoBehaviour
{
    public PlayerShooting weaponScript;
    public Text weapon1;
    public Text Ammo1;
    public Text weapon2;
    public Text Ammo2;

    public Text Death;
    public Text GameOver;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        if(weaponScript.ActualPrimary == 0)
        {
            weapon1.text = "Laser";
            Ammo1.text = ((Laser)weaponScript.m_PrimaryList[0]).AmmoCount.ToString();
        }
        else
        {
            weapon1.text = "Vulcan";
            Ammo1.text = weaponScript.m_PrimaryList[1].AmmoCount.ToString();
        }

        if(weaponScript.ActualSecondary == 0)
        {
            weapon2.text = "Concussion missile";
            Ammo2.text = weaponScript.m_SecondaryList[0].AmmoCount.ToString();
        }
        else
        {
            weapon2.text = "Homing missile";
            Ammo2.text = weaponScript.m_SecondaryList[1].AmmoCount.ToString();
        }

        CheckDeath();
        CheckGameOver();
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

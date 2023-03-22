using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : Singleton<StageManager>
{
    public int m_PlayerLives = 3;
    public PlayerStates PlayerState = PlayerStates.LIVE;
    private int m_Score = 0;

    public Transform SpawnPointPlayer;

    public void Death()
    {
        m_PlayerLives--;

        if (m_PlayerLives > 0)
            PlayerState = PlayerStates.DEAD;
        else
            PlayerState = PlayerStates.GAMEOVER;

        Time.timeScale = 0;
    }

    public void Respawn(GameObject player)
    {
        if (m_PlayerLives > 0)
        {
            player.transform.position = SpawnPointPlayer.transform.position;
            PlayerState = PlayerStates.LIVE;
            Time.timeScale = 1;
        }
        else
        {
            SceneManager.LoadScene("MenuScene");
        }
    }

    public enum PlayerStates
    {
        LIVE,
        DEAD,
        GAMEOVER
    }
}

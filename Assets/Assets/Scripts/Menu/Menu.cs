using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;
using Slider = UnityEngine.UI.Slider;

public class Menu : MonoBehaviour
{
    public AudioMixer AudioMixer;
    public KeyCode PauseKey = KeyCode.Space;
    public GameObject MenuGO;
    public void Start()
    {
        MenuGO.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(PauseKey))
        {
            if (Time.timeScale == 0f)
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                Time.timeScale = 1f;
            }
            else
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;
                Time.timeScale = 0f;
            }

            MenuGO.SetActive(!MenuGO.activeSelf);
        }
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        MenuGO.SetActive(!MenuGO.activeSelf);
    }

    public void GotoMainMenu(string scene)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(scene);
    }

    public void EnterOvering(Text testo)
    {
        testo.color = Color.yellow;
    }
    
    public void ExitOvering(Text testo)
    {
        testo.color = Color.gray;
    }

    public void SetMusicVolume(Slider volume)
    {
        AudioMixer.SetFloat("Master", volume.value);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public AudioMixer AudioMixer;

    public void Play()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class ScrAudioManger : MonoBehaviour
{
    private static bool created = false;

    public AudioMixer audioMixer;

    private void Awake()
    {
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
        }
    }

    public void BGMVolume(float volume)
    {
        audioMixer.SetFloat("BGMVolume", volume);
    }

    public void SFXVolume(float volume)
    {
        audioMixer.SetFloat("SFXVolume", volume);
    }
}

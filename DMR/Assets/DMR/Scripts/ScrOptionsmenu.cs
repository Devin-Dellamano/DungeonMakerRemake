using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class ScrOptionsmenu : MonoBehaviour
{
    private ScrAudioManger AudioManger;
    public Slider[] VolumeSliders;

    private void Start()
    {
        AudioManger = GameObject.Find("Audio Manger").GetComponent<ScrAudioManger>();
    } 

    public void BGMToggle(bool volumeChanged)
    {
        float currVolume = 0;
        AudioManger.audioMixer.GetFloat("BGMVolume", out currVolume);
        if (currVolume > -80.0f)
        {
            AudioManger.audioMixer.SetFloat("BGMVolume", -80.0f);
            VolumeSliders[0].value = -80.0f;
        }
        else
        {
            AudioManger.audioMixer.SetFloat("BGMVolume", 0.0f);
            VolumeSliders[0].value = 0.0f;
        }
    }

    public void SFXToggle(bool volumeChanged)
    {
        float currVolume = 0;
        AudioManger.audioMixer.GetFloat("SFXVolume", out currVolume);
        if (currVolume > -80.0f)
        {
            AudioManger.audioMixer.SetFloat("SFXVolume", -80.0f);
            VolumeSliders[1].value = -80.0f;
        }
        else
        {
            AudioManger.audioMixer.SetFloat("SFXVolume", 0.0f);
            VolumeSliders[1].value = 0.0f;
        }
    }
}

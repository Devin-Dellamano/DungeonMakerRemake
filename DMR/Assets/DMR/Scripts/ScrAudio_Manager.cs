using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScrAudio_Manager : MonoBehaviour
{
    private static bool created = false;

    public AudioClip [] BGM;
    public AudioClip [] SFX;

    private void Awake()
    {
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
        }
    }

    public AudioClip GetBGMClip(string nameAudioClip)
    {
        AudioClip clipReturn = null;

        foreach(AudioClip go in BGM)
        {
            if (go.name == "Text")
            {
                clipReturn = go;
            }
        }

        return clipReturn;
    }

    public AudioClip GetSFXClip(string nameAudioClip)
    {
        AudioClip clipReturn = null;

        foreach (AudioClip go in SFX)
        {
            if (go.name == "Text")
            {
                clipReturn = go;
            }
        }

        return clipReturn;
    }
}

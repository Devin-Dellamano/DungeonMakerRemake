using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrButtonChangePage : MonoBehaviour
{

    public GameObject scene;
    public GameObject[] character;

    public AudioSource sourceSound;
    public AudioClip clipSound;

    public void ChangePanelWithSound(string nameOfPanel)
    {
        scene.SetActive(true);
        this.gameObject.SetActive(false);
        sourceSound.Play();
    }

    public void ChangePanel(string nameOfPanel)
    {
        scene.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void ChangeCharacterTeddy()
    {
        if (character[2].active)
        {
            return;
        }
        character[0].SetActive(false);
        character[1].SetActive(false);
        character[2].SetActive(true);
    }

    public void ChangeCharacterSanta()
    {
        if (character[1].active)
        {
            return;
        }
        character[0].SetActive(false);
        character[1].SetActive(true);
        character[2].SetActive(false);
    }

    public void ChangeCharacterEvie()
    {
        if (character[0].active)
        {
            return;
        }
        character[0].SetActive(true);
        character[1].SetActive(false);
        character[2].SetActive(false);
    }

    public void CloseDMR()
    {
        Application.Quit();
    }
    
}

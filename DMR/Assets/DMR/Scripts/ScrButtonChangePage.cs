using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrButtonChangePage : MonoBehaviour
{

    public GameObject characterSelect;
    public List<GameObject> buttons;

    public AudioSource sourceSound;
    public AudioClip clipSound;

    public void ChangePanelWithSound(string nameOfPanel)
    {
        characterSelect.SetActive(true);
        this.gameObject.SetActive(false);
        sourceSound.Play();
    }

    public void ChangePanel(string nameOfPanel)
    {
        characterSelect.SetActive(true);
        this.gameObject.SetActive(false);
    }
}

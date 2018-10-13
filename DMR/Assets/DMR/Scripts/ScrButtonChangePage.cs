using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrButtonChangePage : MonoBehaviour {

    public GameObject characterSelect;
    public List<GameObject> buttons;

    public void ChangePanel(string nameOfPanel)
    {
        characterSelect.SetActive(true);
        this.gameObject.SetActive(false);
    }
}

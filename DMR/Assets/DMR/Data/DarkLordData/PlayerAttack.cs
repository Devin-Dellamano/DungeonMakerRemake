using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //do stuff
		if (Input.GetMouseButtonUp(0))
        {
            gameObject.GetComponent<Animator>().Play("NormalATK");
        }
	}
}

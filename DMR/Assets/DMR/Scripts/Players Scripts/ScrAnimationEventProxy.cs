using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScrAnimationEventProxy : MonoBehaviour {

    public UnityEvent OnHit = new UnityEvent();

    public void Hit()
    {
        OnHit.Invoke();
    }

    public void FootR()
    {

    }

    public void FootL()
    {

    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

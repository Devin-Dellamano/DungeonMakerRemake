using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrPlayerSkillActivation : MonoBehaviour {
    private Animator anim;

	// Use this for initialization
	void Start () {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButtonUp(0))
        {
            anim.SetBool("Attacking", true);
            anim.SetBool("Idle", false);
            Debug.Log("Clicked");
        }
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Attack 2"))
        {
            anim.SetBool("Attacking", false);
            anim.SetBool("Idle", true);
            anim.Play("Idle");
        }
    }
}

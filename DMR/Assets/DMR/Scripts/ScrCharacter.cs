using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrCharacter : MonoBehaviour {

    public ScoCharacterData data;

    private Animator _CharacterAnimator;

	// Use this for initialization
	void Start () {
		if (data)
        {
            Animator prefab = data.characterList[Random.Range(0, data.characterList.Length - 1)];
            _CharacterAnimator = Instantiate<Animator>(prefab, this.transform);
            _CharacterAnimator.runtimeAnimatorController = data.weapon.animControl;
        }
        else
        {
            Debug.LogError("Character Data is NULL:  ", data);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

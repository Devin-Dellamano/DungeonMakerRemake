using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrCharacter : MonoBehaviour {

    public ScoCharacterData data;

    private Animator _CharacterAnimator;
    private AudioSource _AudioSource;
    private ScrAnimationEventProxy _AnimProxy;
    private ScoWeaponData _WeaponData;
    private Transform[] _Weapons;

    private void Awake()
    {
        Random.InitState(System.DateTime.Now.Second);
    }

    // Use this for initialization
    void Start () {
		if (data)
        {
            _WeaponData = data.weaponDataList[Random.Range(0, data.weaponDataList.Length)];

            _AudioSource = GetComponent<AudioSource>();
            _AudioSource.clip = _WeaponData.hitSound;

            Animator prefab = data.characterList[Random.Range(0, data.characterList.Length - 1)];
            _CharacterAnimator = Instantiate<Animator>(prefab, this.transform);
            _CharacterAnimator.runtimeAnimatorController = _WeaponData.animControl;

            _AnimProxy = _CharacterAnimator.gameObject.AddComponent<ScrAnimationEventProxy>();
            _AnimProxy.OnHit.AddListener(OnHit);
            _CharacterAnimator.applyRootMotion = false;

            _Weapons = new Transform[_WeaponData.weapons.Length];

            if (!data.objectName.Contains("Dark Lord"))
            {
                int i = 0;
                foreach (WeaponBone wb in _WeaponData.weapons)
                {
                    _Weapons[i++] = Instantiate(wb.model, _CharacterAnimator.GetBoneTransform(wb.bone)).transform;
                } 
            }
        }
        else
        {
            Debug.LogError("Character Data is NULL:  ", data);
        }
	}

    void OnHit()
    {
        _AudioSource.Play();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

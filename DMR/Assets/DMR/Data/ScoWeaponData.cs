using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "Data/WeaponData", order = 1)]
public class ScoWeaponData : ScriptableObject {

    public string objectName = "New WeaponData";
    public RuntimeAnimatorController animControl;
    public WeaponBone[] weapons;
    public AudioClip hitSound;

}

[System.Serializable]
public struct WeaponBone
{
    public GameObject model;
    public HumanBodyBones bone;
}


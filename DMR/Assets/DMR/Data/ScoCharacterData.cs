using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterData", menuName = "Data/CharacterData", order = 1)]
public class ScoCharacterData : ScriptableObject {

    public string objectName = "New CharacterData";
    public int health = 100;
    public Animator[] characterList;
    public ScoWeaponData[] weaponDataList; 

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterData
{
    public string monsterName = ""; public int monsterId = -1; public int imageNumber = -1;
    public int attack = 0; public int health = 1;
}

[System.Serializable]
public class ScrMonsterList
{
    public List<MonsterData> list = new List<MonsterData>();
}
public class ScrMonsterDatabase : MonoBehaviour
{
    protected List<MonsterData> monsterList = new List<MonsterData>();
    public int numberOfMonsterInDataBase = 0;
    ScrXMLSaveAndLoad xmlSaver = new ScrXMLSaveAndLoad();
    void Start()
    {
        monsterList = xmlSaver.LoadMonsterList().list;
        numberOfMonsterInDataBase = monsterList.Count;
        Debug.Log("Number of monster in database: " + numberOfMonsterInDataBase);
    }

    public MonsterData GetMonsterData(int _monsterId)
    {
        monsterList = xmlSaver.LoadMonsterList().list;
        foreach (MonsterData monster in monsterList)
        {
            if (monster.monsterId == _monsterId)
                return monster;
        }

        return null;
    }
}

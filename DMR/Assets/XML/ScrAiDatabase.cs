using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiData
{
    public string aiName = ""; public int aiId = -1; public int imageNumber = -1;
    public int attack = 0; public int health = 1;
}

[System.Serializable]
public class ScrAiList
{
    public List<AiData> list = new List<AiData>();
}

public class ScrAiDatabase : MonoBehaviour
{
    protected List<AiData> aiList = new List<AiData>();
    public int numberOfAiInDataBase = 0;
    ScrXMLSaveAndLoad xmlSaver = new ScrXMLSaveAndLoad();
    void Start()
    {
        aiList = xmlSaver.LoadAiList().list;
        numberOfAiInDataBase = aiList.Count;
        Debug.Log("Number of ai in database: " + numberOfAiInDataBase);
    }

    public AiData GetAiData(int _aiId)
    {
        aiList = xmlSaver.LoadAiList().list;
        foreach (AiData ai in aiList)
        {
            if (ai.aiId == _aiId)
                return ai;
        }

        return null;
    }
}

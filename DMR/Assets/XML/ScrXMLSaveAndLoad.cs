using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

public class ScrXMLSaveAndLoad : MonoBehaviour
{
    //public static ScrXMLAiListSaver ins; 
    //WARNINGFIX
    public ScrAiList aiList = new ScrAiList();
    public ScrMonsterList monsterList = new ScrMonsterList();

    public void UpdateAiList(List<AiData> _aiList)
    {
        Debug.Log("Number of ais to be saved before clear" + _aiList.Count);
        aiList.list.Clear();
        Debug.Log("Ai list cleaded");
        Debug.Log("Number of ais to be saved after clear" + _aiList.Count);

        //Debug.Log("Save Check Update begin");
        foreach (AiData ai in _aiList)
        {
            aiList.list.Add(ai);
            Debug.Log("Ai Added to be saved");
        }
        Debug.Log("Ais in list count " + aiList.list.Count);

        SaveAiList();
        // Debug.Log("Save Check Update end");
    }

    //Save List
    public void SaveAiList()
    {
        //Debug.Log("Save Check XML begin");
        XmlSerializer serializer = new XmlSerializer(typeof(ScrAiList));
        FileStream stream = new FileStream(Application.dataPath + "/StreamingAssets/AiPoolList.xml", FileMode.Create);
        serializer.Serialize(stream, aiList);
        stream.Close();
        //Debug.Log("Save Check XML End");
    }
    //Load List
    public ScrAiList LoadAiList()
    {
        aiList.list.Clear();
        XmlSerializer _serializer = new XmlSerializer(typeof(ScrAiList));
        FileStream _stream = new FileStream(Application.dataPath + "/StreamingAssets/AiPoolList.xml", FileMode.Open);
        aiList = (ScrAiList)_serializer.Deserialize(_stream);
        _stream.Close();
        return aiList;
    }

    public ScrAiList GetAiData()
    {
        return aiList;
    }


    public void UpdateMonsterList(List<MonsterData> _monsterList)
    {
        Debug.Log("Number of monsters to be saved before clear" + _monsterList.Count);
        monsterList.list.Clear();
        Debug.Log("Monster list cleaded");
        Debug.Log("Number of monsters to be saved after clear" + _monsterList.Count);

        //Debug.Log("Save Check Update begin");
        foreach (MonsterData monster in _monsterList)
        {
            monsterList.list.Add(monster);
            Debug.Log("Monster Added to be saved");
        }
        Debug.Log("Monsters in list count " + monsterList.list.Count);

        SaveMonsterList();
        // Debug.Log("Save Check Update end");
    }

    //Save List
    public void SaveMonsterList()
    {
        //Debug.Log("Save Check XML begin");
        XmlSerializer serializer = new XmlSerializer(typeof(ScrMonsterList));
        FileStream stream = new FileStream(Application.dataPath + "/StreamingAssets/MonsterPoolList.xml", FileMode.Create);
        serializer.Serialize(stream, monsterList);
        stream.Close();
        //Debug.Log("Save Check XML End");
    }
    //Load List
    public ScrMonsterList LoadMonsterList()
    {
        monsterList.list.Clear();
        XmlSerializer _serializer = new XmlSerializer(typeof(ScrMonsterList));
        FileStream _stream = new FileStream(Application.dataPath + "/StreamingAssets/MonsterPoolList.xml", FileMode.Open);
        monsterList = (ScrMonsterList)_serializer.Deserialize(_stream);
        _stream.Close();
        return monsterList;
    }

    public ScrMonsterList GetMonsterData()
    {
        return monsterList;
    }
}

[System.Serializable]
public class ItemEntry
{
    public string aiName, aiType;
    public int aiCost;
}
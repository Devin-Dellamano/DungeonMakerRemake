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

        SaveList();
        // Debug.Log("Save Check Update end");
    }

    //Save List
    public void SaveList()
    {
        //Debug.Log("Save Check XML begin");
        XmlSerializer serializer = new XmlSerializer(typeof(ScrAiList));
        FileStream stream = new FileStream(Application.dataPath + "/StreamingAssets/AiPoolList.xml", FileMode.Create);
        serializer.Serialize(stream, aiList);
        stream.Close();
        //Debug.Log("Save Check XML End");
    }
    //Load List
    public ScrAiList LoadList()
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

    //#region Deck List
    //public void UpdateDeckList(GameDeck _deckList)
    //{
    //    deckList.name = _deckList.name;
    //    for (int i = 0; i < 10; i++)
    //        deckList.aiId[i] = _deckList.aiId[i];
    //}

    //public void SaveDeckList()
    //{
    //    //Debug.Log("Save Check XML begin");
    //    XmlSerializer serializer = new XmlSerializer(typeof(GameDeck));

    //    FileStream stream = new FileStream(Application.dataPath + "/StreamingAssets/PlayerDeckList.xml", FileMode.Create);
    //    //FileStream stream = new FileStream(Application.dataPath + "/StreamingAssets/PlayerDeckList.xml", FileMode.Create);
    //    serializer.Serialize(stream, deckList);
    //    stream.Close();
    //    //Debug.Log("Save Check XML End");
    //}

    ////Load List
    //public GameDeck LoadDeckList()
    //{
    //    //if(!File.Exists("/StreamingAssets/PlayerDeckList.xml"))
    //    //{
    //    //    XmlSerializer serializer = new XmlSerializer(typeof(GameDeck));
    //    //    FileStream stream = new FileStream(Application.dataPath + "/StreamingAssets/PlayerDeckList.xml", FileMode.Create);
    //    //    serializer.Serialize(stream, deckList);
    //    //    stream.Close();
    //    //}

    //    XmlSerializer _serializer = new XmlSerializer(typeof(GameDeck));
    //    FileStream _stream = new FileStream(Application.dataPath + "/StreamingAssets/PlayerDeckList.xml", FileMode.Open);
    //    deckList = (GameDeck)_serializer.Deserialize(_stream);
    //    _stream.Close();
    //    return deckList;
    //}

    //public GameDeck GetDeckList()
    //{
    //    return deckList;
    //}
    //#endregion
}

[System.Serializable]
public class ItemEntry
{
    public string aiName, aiType;
    public int aiCost;
}
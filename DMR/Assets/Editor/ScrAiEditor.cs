using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public class ScrAiEditor : EditorWindow
{
    int idCount = -1;
    bool aiDataDrawStop = false;
    List<AiData> aiList = new List<AiData>();
    ScrXMLSaveAndLoad xmlSaver = new ScrXMLSaveAndLoad();
    string currentText = "";
    int currentTextId = -1;
    List<string> effectNames = new List<string>();
    ScrXMLSaveAndLoad xmlSaverEffect = new ScrXMLSaveAndLoad();
    List<int> effectIntNames = new List<int>();
    int effectInt = 0;

    [MenuItem("Window/AI Editor")]

    //Show the window
    public static void ShowWindow()
    {
        GetWindow<ScrAiEditor>("AI Editor");
    }

    //Window Code
    void OnGUI()
    {
        GUILayout.Label("AI", EditorStyles.boldLabel);
        AiEditorOptions();
        GUILayout.Space(25);
        Header();
        AiListData();
    }
    private void Header()
    {
        GUILayout.BeginHorizontal();

        GUILayout.Space(75);
        GUILayout.Button("Ai Name", GUILayout.Width(75f), GUILayout.Height(25f));

        GUILayout.Space(25);
        GUILayout.Button("Ai Id", GUILayout.Width(75f), GUILayout.Height(25f));

        GUILayout.Space(10);
        GUILayout.Button("Image Number", GUILayout.Width(100f), GUILayout.Height(25f));

        GUILayout.Space(20);
        GUILayout.Button("Attack", GUILayout.Width(85f), GUILayout.Height(25f));

        GUILayout.Space(20);
        GUILayout.Button("Health", GUILayout.Width(85f), GUILayout.Height(25f));
       

        GUILayout.EndHorizontal();
    }

    private void AiEditorOptions()
    {
        GUILayout.BeginHorizontal();

        if (GUILayout.Button("Add Ai", GUILayout.Width(100f), GUILayout.Height(32f)))
        {
            //UpdateEffectNames();
            OpenAddAiWindow();
        }
        GUILayout.Space(25);
        if (GUILayout.Button("Save", GUILayout.Width(100f), GUILayout.Height(32f)))
            SaveAiList();

        GUILayout.Space(25);
        if (GUILayout.Button("Load", GUILayout.Width(100f), GUILayout.Height(32f)))
        {
            LoadList();
            //UpdateEffectNames();
        }
        GUILayout.Space(25);
        if (GUILayout.Button("Clear", GUILayout.Width(100f), GUILayout.Height(32f)))
            ClearList();
        GUILayout.Space(25);
        //if (GUILayout.Button("Refresh", GUILayout.Width(100f), GUILayout.Height(32f)))
        //{
        //   // UpdateEffectNames();
        //}
        GUILayout.EndHorizontal();
    }


    private void OpenAddAiWindow()
    {
        EditorWindow temp;
        temp = GetWindow<ScrAddAi>("Add New Ai");
        temp.Show(true);
    }

    //private void OpenEditTextWindow()
    //{
    //    EditorWindow tempText;
    //    tempText = GetWindow<ScrCardTextEditor>("Text Editor");
    //    tempText.Show(true);
    //}

    public void AddAi(AiData _ai)
    {
        idCount = aiList.Count;
        _ai.aiId = idCount;
        aiList.Add(_ai);
        //EffectNameHelper(_ai.effectName);

        Debug.Log("Ai added");
    }

    private void ClearList()
    {
        aiList.Clear();
        //effectIntNames.Clear();
    }

    private void SaveAiList()
    {
        //Debug.Log("Save Check begin");
        xmlSaver.UpdateAiList(aiList);
        // Debug.Log("Save Check end");
    }

    private void LoadList()
    {
        int i = 0;
        aiList.Clear();
        xmlSaver.LoadList();
        //effectIntNames.Clear();
        foreach (AiData ai in xmlSaver.GetAiData().list)
        {
            ai.aiId = i;
            aiList.Add(ai);
            i++;
           // EffectNameHelper(card.effectName);
        }
        idCount = aiList.Count;
    }

    private void DrawAiData(int pos, AiData _ai)
    {
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("X", GUILayout.Width(25f), GUILayout.Height(32f)))
        {
            RemoveAi(_ai);
            aiDataDrawStop = true;
            return;
        }
        GUILayout.Space(30);
        _ai.aiName = GUILayout.TextField(_ai.aiName, GUILayout.Width(100f), GUILayout.Height(25f));
        GUILayout.Space(40);
        EditorGUILayout.LabelField(_ai.aiId.ToString(), GUILayout.Width(50f), GUILayout.Height(25f));
        GUILayout.Space(30);
        _ai.imageNumber = EditorGUILayout.IntField(_ai.imageNumber, GUILayout.Width(50f), GUILayout.Height(25f));

        GUILayout.Space(60);
        _ai.attack = EditorGUILayout.IntField(_ai.attack, GUILayout.Width(45), GUILayout.Height(25f));
        GUILayout.Space(55);
        _ai.health = EditorGUILayout.IntField(_ai.health, GUILayout.Width(45), GUILayout.Height(25f));
        GUILayout.Space(5);

        GUILayout.EndHorizontal();

    }
    private void RemoveAi(AiData _aiData)
    {
        for (int i = _aiData.aiId; i + 1 < aiList.Count; i++)
            aiList[i + 1].aiId -= 1;
        aiList.Remove(_aiData);
        AiListData();
    }
    private void AiListData()
    {
        int i = 0;
        foreach (AiData ai in aiList)
        {
            if (i == 0)
                GUILayout.Space(25);
            DrawAiData(i, ai);
            i++;
            if (aiDataDrawStop)
                break;
        }
        if (aiDataDrawStop)
        {
            aiDataDrawStop = false;
            AiListData();
        }
    }
    public string GetEditString()
    {
        return currentText;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
public class ScrMonsterEditor : EditorWindow
{
    int idCount = -1;
    bool monsterDataDrawStop = false;
    List<MonsterData> monsterList = new List<MonsterData>();
    ScrXMLSaveAndLoad xmlSaver = new ScrXMLSaveAndLoad();
    string currentText = "";
    int currentTextId = -1;
    List<string> effectNames = new List<string>();
    ScrXMLSaveAndLoad xmlSaverEffect = new ScrXMLSaveAndLoad();
    List<int> effectIntNames = new List<int>();
    int effectInt = 0;

    [MenuItem("Window/Monster Editor")]

    //Show the window
    public static void ShowWindow()
    {
        GetWindow<ScrMonsterEditor>("Monster Editor");
    }

    //Window Code
    void OnGUI()
    {
        GUILayout.Label("Monster", EditorStyles.boldLabel);
        MonsterEditorOptions();
        GUILayout.Space(25);
        Header();
        MonsterListData();
    }
    private void Header()
    {
        GUILayout.BeginHorizontal();

        GUILayout.Space(75);
        GUILayout.Button("Monster Name", GUILayout.Width(75f), GUILayout.Height(25f));

        GUILayout.Space(25);
        GUILayout.Button("Monster Id", GUILayout.Width(75f), GUILayout.Height(25f));

        GUILayout.Space(10);
        GUILayout.Button("Image Number", GUILayout.Width(100f), GUILayout.Height(25f));

        GUILayout.Space(20);
        GUILayout.Button("Attack", GUILayout.Width(85f), GUILayout.Height(25f));

        GUILayout.Space(20);
        GUILayout.Button("Health", GUILayout.Width(85f), GUILayout.Height(25f));


        GUILayout.EndHorizontal();
    }

    private void MonsterEditorOptions()
    {
        GUILayout.BeginHorizontal();

        if (GUILayout.Button("Add Monster", GUILayout.Width(100f), GUILayout.Height(32f)))
        {
            //UpdateEffectNames();
            OpenAddMonsterWindow();
        }
        GUILayout.Space(25);
        if (GUILayout.Button("Save", GUILayout.Width(100f), GUILayout.Height(32f)))
            SaveMonsterList();

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


    private void OpenAddMonsterWindow()
    {
        EditorWindow temp;
        temp = GetWindow<ScrAddMonster>("Add New Monster");
        temp.Show(true);
    }

    //private void OpenEditTextWindow()
    //{
    //    EditorWindow tempText;
    //    tempText = GetWindow<ScrCardTextEditor>("Text Editor");
    //    tempText.Show(true);
    //}

    public void AddMonster(MonsterData _monster)
    {
        idCount = monsterList.Count;
        _monster.monsterId = idCount;
        monsterList.Add(_monster);
        //EffectNameHelper(_monster.effectName);

        Debug.Log("Monster added");
    }

    private void ClearList()
    {
        monsterList.Clear();
        //effectIntNames.Clear();
    }

    private void SaveMonsterList()
    {
        //Debug.Log("Save Check begin");
        xmlSaver.UpdateMonsterList(monsterList);
        // Debug.Log("Save Check end");
    }

    private void LoadList()
    {
        int i = 0;
        monsterList.Clear();
        xmlSaver.LoadMonsterList();
        //effectIntNames.Clear();
        foreach (MonsterData monster in xmlSaver.GetMonsterData().list)
        {
            monster.monsterId = i;
            monsterList.Add(monster);
            i++;
            // EffectNameHelper(card.effectName);
        }
        idCount = monsterList.Count;
    }

    private void DrawMonsterData(int pos, MonsterData _monster)
    {
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("X", GUILayout.Width(25f), GUILayout.Height(32f)))
        {
            RemoveMonster(_monster);
            monsterDataDrawStop = true;
            return;
        }
        GUILayout.Space(30);
        _monster.monsterName = GUILayout.TextField(_monster.monsterName, GUILayout.Width(100f), GUILayout.Height(25f));
        GUILayout.Space(40);
        EditorGUILayout.LabelField(_monster.monsterId.ToString(), GUILayout.Width(50f), GUILayout.Height(25f));
        GUILayout.Space(30);
        _monster.imageNumber = EditorGUILayout.IntField(_monster.imageNumber, GUILayout.Width(50f), GUILayout.Height(25f));

        GUILayout.Space(60);
        _monster.attack = EditorGUILayout.IntField(_monster.attack, GUILayout.Width(45), GUILayout.Height(25f));
        GUILayout.Space(55);
        _monster.health = EditorGUILayout.IntField(_monster.health, GUILayout.Width(45), GUILayout.Height(25f));
        GUILayout.Space(5);

        GUILayout.EndHorizontal();

    }
    private void RemoveMonster(MonsterData _monsterData)
    {
        for (int i = _monsterData.monsterId; i + 1 < monsterList.Count; i++)
            monsterList[i + 1].monsterId -= 1;
        monsterList.Remove(_monsterData);
        MonsterListData();
    }
    private void MonsterListData()
    {
        int i = 0;
        foreach (MonsterData monster in monsterList)
        {
            if (i == 0)
                GUILayout.Space(25);
            DrawMonsterData(i, monster);
            i++;
            if (monsterDataDrawStop)
                break;
        }
        if (monsterDataDrawStop)
        {
            monsterDataDrawStop = false;
            MonsterListData();
        }
    }
    public string GetEditString()
    {
        return currentText;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ScrAddMonster : EditorWindow
{
    MonsterData newMonster = new MonsterData();
    ScrXMLSaveAndLoad xmlSaverEffect = new ScrXMLSaveAndLoad();

    public static void ShowWindow()
    {
        GetWindow<ScrAddMonster>("Add New Monster");
    }
    void OnGUI()
    {
        BasicMonsterData();
        if (CanAdd())
        {
            GUILayout.Space(25);
            if (GUILayout.Button("Add Monster", GUILayout.Width(100f), GUILayout.Height(32f)))
                Add();
        }
        else
            GUILayout.Label("Current Monster cant be add please fix.", GUILayout.Width(300f), GUILayout.Height(32f));
    }

    private void BasicMonsterData()
    {
        GUILayout.Label("Monster", EditorStyles.boldLabel);

        GUILayout.BeginHorizontal();
        GUILayout.Label("Monster Name", GUILayout.Width(75f), GUILayout.Height(25f));
        newMonster.monsterName = GUILayout.TextField(newMonster.monsterName, GUILayout.Width(125f), GUILayout.Height(25f));
        GUILayout.EndHorizontal();

        MonsterImageData();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Monster Attack", GUILayout.Width(75f), GUILayout.Height(25f));
        newMonster.attack = EditorGUILayout.IntField(newMonster.attack, GUILayout.Width(125f), GUILayout.Height(25f));
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Monster Health", GUILayout.Width(75f), GUILayout.Height(25f));
        newMonster.health = EditorGUILayout.IntField(newMonster.health, GUILayout.Width(125f), GUILayout.Height(25f));
        GUILayout.EndHorizontal();
    }

    private void MonsterImageData()
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label("Image Number", GUILayout.Width(75f), GUILayout.Height(25f));
        newMonster.imageNumber = EditorGUILayout.IntField(newMonster.imageNumber, GUILayout.Width(125f), GUILayout.Height(25f));
        GUILayout.EndHorizontal();
    }
    public void Add()
    {
        Debug.Log("Adding Monster");
        GetWindow<ScrMonsterEditor>().AddMonster(newMonster);
        this.Close();
    }



    private bool CanAdd()
    {
        if (newMonster.monsterName == "")
            return false;
        return true;
    }
}

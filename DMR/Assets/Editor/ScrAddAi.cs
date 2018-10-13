using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ScrAddAi : EditorWindow
{
    AiData newAi = new AiData();
    ScrXMLSaveAndLoad xmlSaverEffect = new ScrXMLSaveAndLoad();

    public static void ShowWindow()
    {
        GetWindow<ScrAddAi>("Add New Ai");
    }
    void OnGUI()
    {
        BasicAiData();
        if (CanAdd())
        {
            GUILayout.Space(25);
            if (GUILayout.Button("Add Ai", GUILayout.Width(100f), GUILayout.Height(32f)))
                Add();
        }
        else
            GUILayout.Label("Current Ai cant be add please fix.", GUILayout.Width(300f), GUILayout.Height(32f));
    }

    private void BasicAiData()
    {
        GUILayout.Label("Ai", EditorStyles.boldLabel);

        GUILayout.BeginHorizontal();
        GUILayout.Label("Ai Name", GUILayout.Width(75f), GUILayout.Height(25f));
        newAi.aiName = GUILayout.TextField(newAi.aiName, GUILayout.Width(125f), GUILayout.Height(25f));
        GUILayout.EndHorizontal();

        AiImageData();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Ai Attack", GUILayout.Width(75f), GUILayout.Height(25f));
        newAi.attack = EditorGUILayout.IntField(newAi.attack, GUILayout.Width(125f), GUILayout.Height(25f));
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Ai Health", GUILayout.Width(75f), GUILayout.Height(25f));
        newAi.health = EditorGUILayout.IntField(newAi.health, GUILayout.Width(125f), GUILayout.Height(25f));
        GUILayout.EndHorizontal();
    }

    private void AiImageData()
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label("Image Number", GUILayout.Width(75f), GUILayout.Height(25f));
        newAi.imageNumber = EditorGUILayout.IntField(newAi.imageNumber, GUILayout.Width(125f), GUILayout.Height(25f));
        GUILayout.EndHorizontal();
    }
    public void Add()
    {
        Debug.Log("Adding Ai");
        GetWindow<ScrAiEditor>().AddAi(newAi);
        this.Close();
    }

  

    private bool CanAdd()
    {
        if (newAi.aiName == "")
            return false;
        return true;
    }
}

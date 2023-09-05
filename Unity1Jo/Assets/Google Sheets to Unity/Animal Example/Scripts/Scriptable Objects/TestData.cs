using UnityEngine;
using System.Collections;
using GoogleSheetsToUnity;
using System.Collections.Generic;
using System;
using UnityEngine.Events;
using GoogleSheetsToUnity.ThirdPary;

#if UNITY_EDITOR
using UnityEditor;
#endif
public class TestData : ScriptableObject
{
    public string associatedSheet = "";
    public string associatedWorksheet = "";

    public List<int> listJellyType = new List<int>();
    public List<int> listJellyYpos = new List<int>();
    public List<int> listJellyAmount = new List<int>();
    public List<int> listObstacleType = new List<int>();
    public List<int> listObstacle = new List<int>();

    public List<string> items = new List<string>();

    public List<string> Names = new List<string>();


    internal void UpdateStats(List<GSTU_Cell> list, string name)
    {
        int index = 0, JellyType = 0, JellyYpos = 0, JellyAmount = 0, ObstacleType = 0, Obstacle = 0;
        for (int i = 0; i < list.Count; i++)
        {
            switch (list[i].columnId)
            {
                case "index":
                    index = int.Parse(list[i].value);
                    break;
                case "JellyType":
                    JellyType = int.Parse(list[i].value);
                    break;
                case "JellyYpos":
                    JellyYpos = int.Parse(list[i].value);
                    break;
                case "JellyAmount":
                    JellyAmount = int.Parse(list[i].value);
                    break;
                case "ObstacleType":
                    ObstacleType = int.Parse(list[i].value);
                    break;
                case "Obstacle":
                    Obstacle = int.Parse(list[i].value);
                    break;
            }
        }
        // Debug.Log($"{name}: index {index}, JellyType {JellyType}, JellyYpos {JellyYpos}, JellyAmount {JellyAmount}, ObstacleType {ObstacleType}, Obstacle {Obstacle}");



        listJellyType.Add(JellyType);
        listJellyYpos.Add(JellyYpos);
        listJellyAmount.Add(JellyAmount);
        listObstacleType.Add(ObstacleType);
        listObstacle.Add(Obstacle);


    }
    void ClearList()
    {
        listJellyType.Clear();
        listJellyYpos.Clear();
        listJellyAmount.Clear();
        listObstacleType.Clear();
        listObstacle.Clear();
    }
    void NewList()
    {
        listJellyType = new List<int>();
        listJellyYpos = new List<int>();
        listJellyAmount = new List<int>();
        listObstacleType = new List<int>();
        listObstacle = new List<int>();
    }
}
[CustomEditor(typeof(TestData))]
public class DataEditor : Editor
{
    TestData data;

    void OnEnable()
    {
        data = (TestData)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        GUILayout.Label("Read Data Examples");

        if (GUILayout.Button("Pull Data Method One"))
        {
            
            UpdateStats(UpdateMethodOne);
        }
    }

    void UpdateStats(UnityAction<GstuSpreadSheet> callback, bool mergedCells = false)
    {
        SpreadsheetManager.Read(new GSTU_Search(data.associatedSheet, data.associatedWorksheet), callback, mergedCells);
    }

    void UpdateMethodOne(GstuSpreadSheet ss)
    {
        //data.UpdateStats(ss.rows["Jim"]);
        foreach (string dataName in data.Names)
            data.UpdateStats(ss.rows[dataName], dataName);
        EditorUtility.SetDirty(target);
    }

}
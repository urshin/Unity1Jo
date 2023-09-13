using UnityEngine;
using System.Collections;
using GoogleSheetsToUnity;
using System.Collections.Generic;
using System;
using UnityEngine.Events;
using GoogleSheetsToUnity.ThirdPary;
using UnityEngine.AI;

#if UNITY_EDITOR
using UnityEditor;
#endif
public class TestData : ScriptableObject
{
    public int IndexCount;
    public string associatedSheet = "";
    public string associatedWorksheet = "";

    public List<string> items = new List<string>();

    public List<string> Names = new List<string>();

    public List<int> Listindex = new List<int>();
    public List<int> ListJellyType = new List<int>();
    public List<int> ListJellyYpos = new List<int>();
    public List<int> ListJellyAmount = new List<int>();
    public List<int> ListObstacleType = new List<int>();
    public List<int> ListObstacle = new List<int>();
    public List<int> ListGround = new List<int>();


    internal void UpdateStats(List<GSTU_Cell> list, string name)
    {
        items.Clear();


        int index = 0, JellyType = 0, JellyYpos = 0, JellyAmount = 0, ObstacleType = 0, Obstacle = 0, Ground = 0;

        for (int i = 0; i < list.Count; i++)
        {
            switch (list[i].columnId)
            {
                case "index":
                    {
                        index = int.TryParse(list[i].value, out int parsedIndex) ? parsedIndex : 0;
                        Listindex.Add(index);
                        break;
                    }
                case "JellyType":
                    {
                        JellyType = int.TryParse(list[i].value, out int parsedJellyType) ? parsedJellyType : 0;
                        ListJellyType.Add(JellyType);
                        break;
                    }
                case "JellyYpos":
                    {
                        JellyYpos = int.TryParse(list[i].value, out int parsedJellyYpos) ? parsedJellyYpos : 0;
                        ListJellyYpos.Add(JellyYpos);
                        break;
                    }
                case "JellyAmount":
                    {
                        JellyAmount = int.TryParse(list[i].value, out int parsedJellyAmount) ? parsedJellyAmount : 0;
                        ListJellyAmount.Add(JellyAmount);
                        break;
                    }
                case "ObstacleType":
                    {
                        ObstacleType = int.TryParse(list[i].value, out int parsedObstacleType) ? parsedObstacleType : 0;
                        ListObstacleType.Add(ObstacleType);
                        break;
                    }
                case "Obstacle":
                    {
                        Obstacle = int.TryParse(list[i].value, out int parsedObstacle) ? parsedObstacle : 0;
                        ListObstacle.Add(Obstacle);
                        break;
                    }
                case "Ground":
                    {
                        Obstacle = int.TryParse(list[i].value, out int parsedObstacle) ? parsedObstacle : 0;
                        ListObstacle.Add(Obstacle);
                        break;
                    }
            }


        }
        //Debug.Log($"{name}의 인덱스:{index} 젤리 타입:{JellyType} 젤리 위치:{JellyYpos} 젤리 수:{JellyAmount} 장애물 타입:{ObstacleType} 장애물 위치:{Obstacle}");
    }

    internal void ClearList()
    {
        Listindex.Clear();
        ListJellyType.Clear();
        ListJellyYpos.Clear();
        ListJellyAmount.Clear();
        ListObstacleType.Clear();
        ListObstacle.Clear();
        ListGround.Clear();
    }
    internal void NewList()
    {
        Listindex = new List<int>();
        ListJellyType = new List<int>();
        ListJellyYpos = new List<int>();
        ListJellyAmount = new List<int>();
        ListObstacleType = new List<int>();
        ListObstacle = new List<int>();
        ListGround = new List<int>();
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
        //SpreadsheetManager.Read(new GSTU_Search(data.associatedSheet, data.associatedWorksheet), callback, mergedCells);
        SpreadsheetManager.Read(new GSTU_Search(data.associatedSheet, data.associatedWorksheet), (ss) =>
        {
            callback(ss);
            // 스프레드시트 데이터가 로드되면 콜백 함수를 호출
        }, mergedCells);
    }

    void UpdateMethodOne(GstuSpreadSheet ss)
    {

        data.IndexCount = ss.rows.secondaryKeyLink.Count;
        Debug.Log(ss.rows.secondaryKeyLink.Count);
        
        data.ClearList();
        data.NewList();
        data.Names.Clear();
        for (int i = 1; i < data.IndexCount; i++)
        {
            data.Names.Add(i.ToString());
        }

        foreach (string dataName in data.Names)
        {
            data.UpdateStats(ss.rows[dataName], dataName);
            //  data.UpdateStats(ss.rows[dataName], dataName);
        }



        EditorUtility.SetDirty(target);
    }

}
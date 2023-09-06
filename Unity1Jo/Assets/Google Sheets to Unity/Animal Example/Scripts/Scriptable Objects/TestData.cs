using UnityEngine;
using GoogleSheetsToUnity;
using System.Collections.Generic;
using UnityEngine.Events;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class TestData : ScriptableObject
{
    public string associatedSheet = "";
    public string associatedWorksheet = "";

    public List<int> listIndex = new List<int>();
    public List<int> listJellyType = new List<int>();
    public List<int> listJellyYpos = new List<int>();
    public List<int> listJellyAmount = new List<int>();
    public List<int> listObstacleType = new List<int>();
    public List<int> listObstacle = new List<int>();

    public List<string> items = new List<string>();

    public List<string> Names = new List<string>();

    public bool isnewList;
    public int indexColumnLength;
    public TestData()
    {
        NewList();
    }

    internal void UpdateStats(List<GSTU_Cell> list, string name)
    {

        int index = 0, JellyType = 0, JellyYpos = 0, JellyAmount = 0, ObstacleType = 0, Obstacle = 0;
        for (int i = 0; i < list.Count; i++)
        {
            switch (list[i].columnId)
            {
                case "index":
                    index = int.TryParse(list[i].value, out int parsedIndex) ? parsedIndex : 0;
                    break;
                case "JellyType":
                    JellyType = int.TryParse(list[i].value, out int parsedJellyType) ? parsedJellyType : 0;
                    break;
                case "JellyYpos":
                    JellyYpos = int.TryParse(list[i].value, out int parsedJellyYpos) ? parsedJellyYpos : 0;
                    break;
                case "JellyAmount":
                    JellyAmount = int.TryParse(list[i].value, out int parsedJellyAmount) ? parsedJellyAmount : 0;
                    break;
                case "ObstacleType":
                    ObstacleType = int.TryParse(list[i].value, out int parsedObstacleType) ? parsedObstacleType : 0;
                    break;
                case "Obstacle":
                    Obstacle = int.TryParse(list[i].value, out int parsedObstacle) ? parsedObstacle : 0;
                    break;
            }
        }
        listIndex.Add(index);
        listJellyType.Add(JellyType);
        listJellyYpos.Add(JellyYpos);
        listJellyAmount.Add(JellyAmount);
        listObstacleType.Add(ObstacleType);
        listObstacle.Add(Obstacle);
    }

    public void ClearList()
    {
        listIndex.Clear();
        listJellyType.Clear();
        listJellyYpos.Clear();
        listJellyAmount.Clear();
        listObstacleType.Clear();
        listObstacle.Clear();
    }

    public void NewList()
    {
        listIndex = new List<int>();
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

        if (GUILayout.Button("Reset Data"))
        {
            ResetData(); // 데이터를 초기화하는 함수 호출
        }
    }


    void UpdateStats(UnityAction<GstuSpreadSheet> callback, bool mergedCells = false)
    {

        data.ClearList();
        data.NewList();
        data.Names.Clear(); // 기존 데이터를 제거하고 다시 초기화
        data.Names = new List<string>();
        
        SpreadsheetManager.Read(new GSTU_Search(data.associatedSheet, data.associatedWorksheet), callback, mergedCells);
    }
   
    void UpdateMethodOne(GstuSpreadSheet ss)
    {
        data.Names.Clear(); // 기존 데이터를 제거하고 다시 초기화

        // "index" 열의 길이를 구함
        data.indexColumnLength = ss.rows["index"].Count;

        Debug.Log("Index 열의 길이: " + data.indexColumnLength);

        // Names 리스트를 스프레드시트에서 가져온 데이터 길이에 따라 초기화
        data.Names.Clear(); // Names 리스트 초기화
        for (int i = 1; i <= data.indexColumnLength; i++)
        {
            data.Names.Add(i.ToString());
        }

        // 나머지 코드는 변경하지 않고 유지합니다.
        foreach (string dataName in data.Names)
        {
            data.UpdateStats(ss.rows[dataName], dataName);
            Debug.Log(dataName);
        }
        

        EditorUtility.SetDirty(target);

    }
    void ResetData()
    {
        // 변수를 초기화하는 코드를 여기에 추가
        data.ClearList();
        data.NewList();
        data.Names.Clear();
        data.Names = new List<string>();
        data.indexColumnLength = 0;

        // 변수를 초기화한 후, Inspector를 갱신하여 변경사항을 반영
        EditorUtility.SetDirty(target);
    }
}

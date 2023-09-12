
using GoogleSheetsToUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.Events;
using UnityEngine.Networking;

public class GoogleSheetManager : MonoBehaviour
{
    const string URL = "https://docs.google.com/spreadsheets/d/1cd4s_Ctc3_bfb48O4b0rgP9w0N2JHqRKPjTWFJfiAg4/export?format=tsv";
    const string URL1 = "&gid=2110210694";

    public List<int> Listindex = new List<int>();
    public List<int> ListJellyType = new List<int>();
    public List<int> ListJellyYpos = new List<int>();
    public List<int> ListJellyAmount = new List<int>();
    public List<int> ListObstacleType = new List<int>();
    public List<int> ListObstacle = new List<int>();
    public List<int> ListGround = new List<int>();

    public void Start()
    {
        Listindex = new List<int>();    
        ListJellyType = new List<int>();
        ListJellyYpos = new List<int>();
        ListJellyAmount = new List<int>();
        ListObstacleType = new List<int>();
        ListObstacle = new List<int>();
        ListGround = new List<int>();
        StartCoroutine("start");
    }


    IEnumerator start()
    {
        UnityWebRequest www = UnityWebRequest.Get(URL);
        yield return www.SendWebRequest();

        string data = www.downloadHandler.text;

        string[] lines = data.Split('\n'); // 줄별로 


        for (int i = 1; i < lines.Length; i++)
        {
            string[] values = lines[i].Split('\t'); // 탭으로 구분된 값.

            for (int j = 0; j < values.Length; j++)
            {
                // 공백을 0으로 대체합니다.
                if (string.IsNullOrEmpty(values[j]))
                {
                    values[j] = "0";
                }
            }

            string modifiedLine = string.Join("\t", values); // 수정된 값을 다시 합침
            lines[i] = modifiedLine;
        }

        data = string.Join("\n", lines); // 수정된 줄을 다시 합침
        Debug.Log(data);


        string[] lineline = data.Split('\n'); // 줄별로 

        for (int i = 1; i < lineline.Length; i++)
        {
            string[] values = lineline[i].Split('\t'); // 탭으로 구분된 값.

            Debug.Log(values[0]);

            if (values[0] != null)
                Listindex.Add(int.Parse(values[0]));
            if (values[1] != null)
                ListJellyType.Add(int.Parse(values[1]));
            if (values[2] != null)
                ListJellyYpos.Add(int.Parse(values[2]));
            if (values[3] != null)
                ListJellyAmount.Add(int.Parse(values[3]));
            if (values[4] != null)
                ListObstacleType.Add(int.Parse(values[4]));
            if (values[5] != null)
                ListObstacle.Add(int.Parse(values[5]));
            if (values[6] != null)
                ListGround.Add(int.Parse(values[6]));
            //SpawnTestManager.Instance.Listindex.Add(int.Parse(values[0]));

            string modifiedLine = string.Join("\t", values); // 수정된 값을 다시 합침
            lineline[i] = modifiedLine;
        }
    }


}


//Listindex.Add(int.Parse(values[0]));
//ListJellyType.Add(int.Parse(values[1]));
//ListJellyYpos.Add(int.Parse(values[2]));
//ListJellyAmount.Add(int.Parse(values[3]));
//ListObstacleType.Add(int.Parse(values[4]));
//ListObstacle.Add(int.Parse(values[5]));
//아이템 및 장애물 생성 매니저
//아이템 및 장애물 생성 매니저
//아이템 및 장애물 생성 매니저
//아이템 및 장애물 생성 매니저

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine.Experimental.GlobalIllumination;
using Random = UnityEngine.Random;//랜덤함수 처리
using UnityEngine.UIElements;
using JetBrains.Annotations;

public class Spawnanager : MonoBehaviour
{

    public static Spawnanager Instance;
    private void Awake()
    {
        Instance = this;
    }

    public Transform[] SpawnPos; //스폰 포지션 //yPos
    public GameObject SpawnObject;
    public GameObject Spawn10Pos;

    public GameObject[] whatjelly; //젤리 타입
    public GameObject[] whatobstacle; //장애물 타입

    Player p;

    [SerializeField] int patternNum; //패턴 번호
    [SerializeField] float SpawnSpeed;
    float LastSpawnTime;

    int jellytype;
    int jellyYpos;
    int jellyAmount;
    int obstacleType;
    int obstacle;
    int mapindex;

    public string map1 = "Assets/Resources/data.json";
    public string map2 = "Assets/Resources/data.json"; // 맵 데이터 추가 예정
    public string map3 = "Assets/Resources/data.json"; // 맵 데이터 추가 예정
    public string map4 = "Assets/Resources/data.json"; // 맵 데이터 추가 예정
    public string map5 = "Assets/Resources/data.json"; // 맵 데이터 추가 예정
    public string Bonusmap = "Assets/Resources/BonusMap.json"; // 맵 데이터 추가 예정
    public string CurrentMap;

    public string lastMap;
    public int lastPatternum;


    //public Material[] mat_map; // 맵 이미지로 사용할 머테리얼                          

    private void Start()
    {
        p = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        patternNum = 0; //indexnumber
        Spawn10Pos = Instantiate(SpawnObject, gameObject.transform.position - new Vector3(0, 0.75f, 0), Quaternion.identity);
        Spawn10Pos.transform.parent = gameObject.transform;
        p.isMapChange = false;
        for (int i = 0; i < transform.GetChild(0).transform.childCount; i++)
        {
            SpawnPos[i] = transform.GetChild(0).transform.GetChild(i);
        }
        CurrentMap = map1;


    }


    void FixedUpdate()
    {

        //if (p.isMapChange && !p.isBonusTime && p.mapcount == 0)
        //{
        //    CurrentMap = map1;
        //    patternNum = 0;
        //    p.isMapChange = false;
        //}
        //else if (p.isMapChange && !p.isBonusTime && p.mapcount == 1)
        //{
        //    CurrentMap = map2;
        //    patternNum = 0;
        //    p.isMapChange = false;
        //}
        //else if (p.isMapChange && !p.isBonusTime && p.mapcount == 2)
        //{
        //    CurrentMap = map3;
        //    patternNum = 0;
        //    p.isMapChange = false;
        //}
        //else if (p.isMapChange && !p.isBonusTime && p.mapcount == 3)
        //{
        //    CurrentMap = map4;
        //    patternNum = 0;
        //    p.isMapChange = false;
        //}


        if (p.isMapChange && !p.isBonusTime)
        {

            switch (p.mapcount)
            {
                case 0:
                    CurrentMap = map1;
                    patternNum = 0;
                    p.isMapChange = false;
                    break;
                case 1:
                    CurrentMap = map2;
                    patternNum = 0;
                    p.isMapChange = false;
                    break;
                case 2:
                    CurrentMap = map3;
                    patternNum = 0;
                    p.isMapChange = false;
                    break;
                case 3:
                    CurrentMap = map4;
                    patternNum = 0;
                    p.isMapChange = false;
                    break;
                case 4:
                    CurrentMap = map5;
                    patternNum = 0;
                    p.isMapChange = false;
                    break;

            }
        }


        else if (CurrentMap != Bonusmap && p.isBonusTime)
        {
            lastPatternum = patternNum;
            lastMap = CurrentMap;

            CurrentMap = Bonusmap;
            patternNum = 0;

        }
        else if (CurrentMap == Bonusmap && !p.isBonusTime)
        {
            patternNum = lastPatternum;
            CurrentMap = lastMap;
            p.isMapChange = false;
        }


        string jsonFilePath = CurrentMap; //리소스 파일 안에 있는 data읽기

        if (File.Exists(jsonFilePath)) //파일이 존재할 시
        {
            // JSON 파일 읽기
            string jsonContent = File.ReadAllText(jsonFilePath);
            JsonData jsonData = JsonUtility.FromJson<JsonData>(jsonContent); //Json으로 읽은 데이터 Class에 대입


            // 출력

            if (Time.time > LastSpawnTime + SpawnSpeed / p.GroundScrollSpeed && patternNum < jsonData.index.Count)//몬스터 생성 주기
            {
                LastSpawnTime = Time.time;

                StartCoroutine(spawn());
                jellytype = jsonData.JellyType[patternNum];     //데이터 가져오기 코루틴으로 쓰기 위해 대입해줌
                jellyYpos = jsonData.JellyYpos[patternNum];     //데이터 가져오기 코루틴으로 쓰기 위해 대입해줌
                obstacleType = jsonData.ObstacleType[patternNum];   //데이터 가져오기 코루틴으로 쓰기 위해 대입해줌
                jellyAmount = jsonData.JellyAmount[patternNum];     //데이터 가져오기 코루틴으로 쓰기 위해 대입해줌
                obstacle = jsonData.Obstacle[patternNum];           //데이터 가져오기 코루틴으로 쓰기 위해 대입해줌
                patternNum++; //index값과 같음.

            }

        }

        else //오류 출력
        {
            Debug.LogError("JSON file not found at path: " + jsonFilePath);
        }

    }



    IEnumerator spawn() //생성 코루틴
    {


        //젤리 생성
        for (int i = 0; i < jellyAmount; i++)
        {
            Instantiate(whatjelly[jellytype], SpawnPos[jellyYpos + i]);

            // yield return new WaitForSeconds(1 / p.GroundScrollSpeed); //맵 스크롤 스피드에 맞춰서 생성.
        }



        //몬스터 생성. json파일 내의 값이 0일경우 생성 x
        if (obstacleType >= 1)
        {

            Instantiate(whatobstacle[obstacleType - 1], SpawnPos[obstacle]);

        }
        yield return null;
    }


    [System.Serializable]
    public class JsonData //data파일 읽은 정보 넣기
    {
        public List<int> index; // 번호
        public List<int> JellyType; //젤리 타입 
        public List<int> JellyYpos; //젤리 생성 위치
        public List<int> JellyAmount; //젤리 수
        public List<int> ObstacleType; //장애물 타입
        public List<int> Obstacle; //장애물
    }

    public void ResetPatternNum()
    {
        patternNum = 0;
    }

}
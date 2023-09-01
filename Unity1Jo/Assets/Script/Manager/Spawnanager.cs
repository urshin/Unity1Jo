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

public class Spawnanager : SingletonBehaviour<Spawnanager>
{

    void Awake()
    {
        base.Awake();
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
    public string CurrentMap;
    private void Start()
    {
        p = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        patternNum = 0; //indexnumber
        Spawn10Pos = Instantiate(SpawnObject, gameObject.transform.position, Quaternion.identity);
        Spawn10Pos.transform.parent = gameObject.transform;
        for(int i = 0; i < transform.GetChild(0).transform.childCount; i++)
        {
            SpawnPos[i] = transform.GetChild(0).transform.GetChild(i);
        }

    }


    void FixedUpdate()
    {
        //나중에 특정 값으로 map구분 하게 만듦
        if (p.mapcount == 0)
        {
            CurrentMap = map1; //게임 시작 시 현재 맵 == map1
            
        }
        else if (p.mapcount == 1 && p.isMapChange)
        {
            CurrentMap = map2;
            patternNum = 0;
            p.isMapChange = false;
        }
        else if (p.mapcount == 2 && p.isMapChange)
        {
            CurrentMap = map3;
            patternNum = 0;
            p.isMapChange = false;
        }
        else if (p.mapcount == 3 && p.isMapChange)
        {
            CurrentMap = map4;
            patternNum = 0;
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
            Instantiate(whatjelly[jellytype], SpawnPos[jellyYpos]);
            // yield return new WaitForSeconds(1 / p.GroundScrollSpeed); //맵 스크롤 스피드에 맞춰서 생성.
        }



        //몬스터 생성. json파일 내의 값이 0일경우 생성 x
        if (obstacleType >= 1)
        {
            for (int i = 0; i < obstacle; i++)
            {
                Instantiate(whatobstacle[obstacleType - 1], SpawnPos[0]);
                // yield return new WaitForSeconds(1 / p.GroundScrollSpeed); //맵 스크롤 스피드에 맞춰서 생성.

            }
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
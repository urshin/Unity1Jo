using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine.Experimental.GlobalIllumination;

public class SpawnSystemTest : MonoBehaviour
{
    public Transform[] SpawnPos;


    public GameObject[] whatjelly;
    public GameObject[] whatobstacle;


    [SerializeField] int patternNum; //패턴 번호
    float LastSpawnTime;

    int jellytype;
    int jellyYpos;
    int jellyAmount;
    int obstacleType;
    int obstacle;

    public string map1 = "Assets/Resources/data.json";
    public string map2 = "Assets/Resources/data.json"; // 맵 데이터 추가 예정
    public string map3 = "Assets/Resources/data.json"; // 맵 데이터 추가 예정
    public string map4 = "Assets/Resources/data.json"; // 맵 데이터 추가 예정

    public void Start()
    {
        patternNum = 0;



    }
    void FixedUpdate()
    {
        //나중에 특정 값으로 map구분 하게 만듦
        string jsonFilePath = map1; //리소스 파일 안에 있는 data읽기



        if (File.Exists(jsonFilePath)) //파일이 존재할 시
        {
            // JSON 파일 읽기
            string jsonContent = File.ReadAllText(jsonFilePath);
            JsonData jsonData = JsonUtility.FromJson<JsonData>(jsonContent); //Json으로 읽은 데이터 Class에 대입


            // 출력

            if (Time.time > LastSpawnTime + 3 / GameManager.Instance.GroundScrollSpeed && patternNum < jsonData.index.Count)//몬스터 생성 주기
            {
                LastSpawnTime = Time.time;
                //Debug.Log(jsonData.index.Count); //count체크용

                StartCoroutine(spawn());
                jellytype = jsonData.JellyType[patternNum] - 1;     //데이터 가져오기 코루틴으로 쓰기 위해 대입해줌
                jellyYpos = jsonData.JellyYpos[patternNum] - 1;     //데이터 가져오기 코루틴으로 쓰기 위해 대입해줌
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
            yield return new WaitForSeconds(0.7f / GameManager.Instance.GroundScrollSpeed); //맵 스크롤 스피드에 맞춰서 생성.
        }
        //몬스터 생성. json파일 내의 값이 0일경우 생성 x
        if (obstacleType >= 1)
        {
            for (int i = 0; i < obstacle; i++)
            {
                Instantiate(whatobstacle[obstacleType], SpawnPos[0]);
                yield return new WaitForSeconds(0.7f / GameManager.Instance.GroundScrollSpeed); //맵 스크롤 스피드에 맞춰서 생성.

            }
        }
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

}

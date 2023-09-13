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

public class SpawnManager : MonoBehaviour
{
   
    public static SpawnManager Instance;
    private void Awake()
    {
        Instance = this;
    }

    public Transform[] SpawnPos; //스폰 포지션 //yPos
    public GameObject SpawnObject;
    public GameObject Spawn10Pos;

    #region ChangeImage
    [SerializeField] public Sprite image0;
    [SerializeField] Sprite image1; // 바뀌는 젤리 이미지
    [SerializeField] Sprite image2;
    [SerializeField] Sprite image3;
    [SerializeField] Sprite image4;
    [SerializeField] public RuntimeAnimatorController Short0;
    [SerializeField] RuntimeAnimatorController Short1;
    [SerializeField] RuntimeAnimatorController Short2;
    [SerializeField] RuntimeAnimatorController Short3;
    [SerializeField] RuntimeAnimatorController Short4;
    [SerializeField] public RuntimeAnimatorController Long0;
    [SerializeField] RuntimeAnimatorController Long1;
    [SerializeField] RuntimeAnimatorController Long2;
    [SerializeField] RuntimeAnimatorController Long3;
    [SerializeField] RuntimeAnimatorController Long4;
    [SerializeField] public RuntimeAnimatorController Slide0;
    [SerializeField] RuntimeAnimatorController Slide1;
    [SerializeField] RuntimeAnimatorController Slide2;
    [SerializeField] RuntimeAnimatorController Slide3;
    [SerializeField] RuntimeAnimatorController Slide4;
    [SerializeField] public RuntimeAnimatorController LongSlide0;
    [SerializeField] RuntimeAnimatorController LongSlide1;
    [SerializeField] RuntimeAnimatorController LongSlide2;
    [SerializeField] RuntimeAnimatorController LongSlide3;
    [SerializeField] RuntimeAnimatorController LongSlide4;
    #endregion

    public GameObject[] whatjelly; //젤리 타입
    public GameObject[] whatobstacle; //장애물 타입
    public GameObject Ground;

    Player p;

    [SerializeField] int patternNum; //패턴 번호
    [SerializeField] float SpawnSpeed;
    float LastSpawnTime;

    int jellytype;
    int jellyYpos;
    int jellyAmount;
    int obstacleType;
    int obstacle;
    int ground;
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

    public void Start()
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


        

        mainCamera = Camera.main;

    }
    private Camera mainCamera;


    

    private void DestroyObjectInCamera(string TagName) //카메라 안에 있는거 Destroy
    {
        Vector3 cameraPosition = mainCamera.transform.position;
        float maxDistance = mainCamera.orthographicSize * 2; // 시야 범위를 화면 크기에 맞게 조절
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(cameraPosition, maxDistance);

        foreach (Collider2D collider in hitColliders)
        {
            GameObject obj = collider.gameObject;
            if (obj.CompareTag(TagName))
            {
                Destroy(obj);

            }
        }
    }


    void FixedUpdate()
    {
        




        // CheckEnemy(GameObject.FindGameObjectWithTag("Enemy")); //카메라 안에 적이 있는지 확인하는거
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
                    // GetSpriteOrigin();
                    ChangeJellyPrefab(whatjelly[0], image0);
                    ChangeEnemy(whatobstacle[0], Short0);
                    ChangeEnemy(whatobstacle[1], Long0);
                    ChangeEnemy(whatobstacle[2], Slide0);
                    ChangeEnemy(whatobstacle[3], LongSlide0);
                    MapController.Instance.ChangeMaterial(MapController.Instance.mat_ovenIn);

                    patternNum = 0;
                    p.isMapChange = false;
                    break;
                case 1:
                    CurrentMap = map2;
                    ChangeJellyPrefab(whatjelly[0], image1);
                    ChangeEnemy(whatobstacle[0], Short1);
                    ChangeEnemy(whatobstacle[1], Long1);
                    ChangeEnemy(whatobstacle[2], Slide1);
                    ChangeEnemy(whatobstacle[3], LongSlide1);
                    MapController.Instance.ChangeMaterial(MapController.Instance.mat_map);

                    patternNum = 0;
                    p.isMapChange = false;

                    break;
                case 2:
                    CurrentMap = map3;
                    ChangeJellyPrefab(whatjelly[0], image2);
                    ChangeEnemy(whatobstacle[0], Short2);
                    ChangeEnemy(whatobstacle[1], Long2);
                    ChangeEnemy(whatobstacle[2], Slide2);
                    ChangeEnemy(whatobstacle[3], LongSlide2);
                    MapController.Instance.ChangeMaterial(MapController.Instance.mat_map1);

                    patternNum = 0;
                    p.isMapChange = false;
                    break;
                case 3:
                    CurrentMap = map4;
                    ChangeJellyPrefab(whatjelly[0], image3);
                    ChangeEnemy(whatobstacle[0], Short3);
                    ChangeEnemy(whatobstacle[1], Long3);
                    ChangeEnemy(whatobstacle[2], Slide3);
                    ChangeEnemy(whatobstacle[3], LongSlide3);
                    MapController.Instance.ChangeMaterial(MapController.Instance.mat_map2);

                    patternNum = 0;
                    p.isMapChange = false;
                    break;
                case 4:
                    CurrentMap = map5;
                    ChangeJellyPrefab(whatjelly[0], image4);
                    ChangeEnemy(whatobstacle[0], Short4);
                    ChangeEnemy(whatobstacle[1], Long4);
                    ChangeEnemy(whatobstacle[2], Slide4);
                    ChangeEnemy(whatobstacle[3], LongSlide4);
                    MapController.Instance.ChangeMaterial(MapController.Instance.mat_map3);

                    patternNum = 0;
                    p.isMapChange = false;
                    break;

            }
        }

        
        if (CurrentMap != Bonusmap && p.isBonusTime)
        {
            lastPatternum = patternNum;
            lastMap = CurrentMap;

            //GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
            //GameObject[] Items = GameObject.FindGameObjectsWithTag("Item");
            //GameObject[] jellys = GameObject.FindGameObjectsWithTag("Jelly");
            //GameObject[] coins = GameObject.FindGameObjectsWithTag("Coin");

            //foreach (GameObject item in Items)
            //{
            //    Destroy(item);


            //}

            //foreach (GameObject jelly in jellys)
            //{
            //    Destroy(jelly);


            //}
            //foreach (GameObject coin in coins)
            //{
            //    Destroy(coin);


            //}
            //foreach (GameObject enemy in enemys)
            //{
            //    Destroy(enemy);


            //}

            CurrentMap = Bonusmap;
            patternNum = 0;

        }
        if (CurrentMap == Bonusmap && !p.isBonusTime)
        {
            StartCoroutine(WaitingTime(3));
        }


        IEnumerator WaitingTime(float time)
        {
            patternNum = lastPatternum;
            CurrentMap = lastMap;
            yield return new WaitForSeconds(time);
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
                ground = jsonData.Ground[patternNum]; 
                patternNum++; //index값과 같음.

            }

        }

        else //오류 출력
        {
            Debug.LogError("JSON file not found at path: " + jsonFilePath);
        }

    }

    

    public void ChangeJellyPrefab(GameObject prefab, Sprite newsprite) // code by. 대석
    {
        SpriteRenderer sp = prefab.GetComponent<SpriteRenderer>();

        if (sp.sprite != null)
        {
            sp.sprite = newsprite;
        }
    }

    public void ChangeEnemy(GameObject prefab, RuntimeAnimatorController Ct)
    {
        Animator anim = prefab.GetComponentInChildren<Animator>();

        if (Ct != null)
        {
            anim.runtimeAnimatorController = Ct;
        }
    }

    IEnumerator spawn() //생성 코루틴
    {


        //젤리 생성
        for (int i = 0; i < jellyAmount; i++)
        {
            int j = 0;

            if (obstacleType == 1) //1단 점프로 넘어지는 적이면 젤리 생성 위치를 3 올림
            {
                j = 3;

            }
            if (obstacleType == 2)//2단 점프로 넘어지는 적이면 젤리 생성 위치를 7 올림
            {
                j = 7;
            }
            if (jellyYpos >= j)
            { j = 0; }
            Instantiate(whatjelly[jellytype], SpawnPos[jellyYpos + i + j]);
            // yield return new WaitForSeconds(1 / p.GroundScrollSpeed); //맵 스크롤 스피드에 맞춰서 생성.
        }
        //몬스터 생성. json파일 내의 값이 0일경우 생성 x
        if (obstacleType >= 1)
        {

            Instantiate(whatobstacle[obstacleType - 1], SpawnPos[obstacle]);

        }
        if(ground >= 1)
        {
            Instantiate(Ground, SpawnPos[ground]);
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
        public List<int> Ground; //장애물
        
    }

    public void ResetPatternNum()
    {
        patternNum = 0;
    }

}
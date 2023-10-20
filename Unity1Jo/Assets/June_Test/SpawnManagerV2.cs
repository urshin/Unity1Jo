using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static SpawnManager;

public class SpawnManagerV2 : MonoBehaviour
{
    [SerializeField] ItemBox itembox;
    GoogleSheetManager googleSheet;
    Player p;


    [SerializeField] int jellyType;
    [SerializeField] int jellyYpos;
    [SerializeField] int jellyAmount;
    [SerializeField] int obstacleType;
    [SerializeField] int obstaclePos;
    [SerializeField] int ground;





    float LastSpawnTime;
    [SerializeField] float SpawnSpeed;
    [SerializeField] GameObject Spawnpos;

    [SerializeField] int PatternNum;

    private void Awake()
    {


    }
    private void Start()
    {
        p = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
       // itembox = GetComponent<ItemBox>();
        PatternNum = 0; //패턴 넘버 초기화
        p.isMapChange = false;
        p.mapcount = 0;

    }

    float lastPatternum;
    float patternNum;
    string lastMap;
    private void Update()
    {
        googleSheet = GetComponent<GoogleSheetManager>(); //온라인에서 값 가져오는게 조금 느려서 업데이트문에 넣음
        if (p.isMapChange && !p.isBonusTime)
        {
            if (p.mapcount == 0)
            {
                googleSheet.URL = googleSheet.Map1;
                googleSheet.CreateMap();
                p.isMapChange = false;
            }
            if (p.mapcount == 1)
            {
                googleSheet.URL = googleSheet.Map2;
                googleSheet.CreateMap();
                p.isMapChange = false;
            }
        }
        if (googleSheet.URL != googleSheet.BonusMap && p.isBonusTime)
        {
            lastPatternum = patternNum;
            lastMap = googleSheet.URL;
            googleSheet.URL = googleSheet.BonusMap;

            googleSheet.CreateMap();
            patternNum = 0;
            p.DestrtoyObject();
        }
        if (googleSheet.URL == googleSheet.BonusMap && !p.isBonusTime)
        {
            StartCoroutine(WaitingTime(3));  
        }


        // ----------------------------------------------------------
        if (googleSheet == null)
            return;

        if (Time.time > LastSpawnTime + SpawnSpeed / p.GroundScrollSpeed)//몬스터 생성 주기
        {
            LastSpawnTime = Time.time;

            if (googleSheet.Listindex == null || googleSheet.Listindex.Count < 1)
            {

                Debug.Log("값이 없다유");
                return;
            }
            if (googleSheet.Listindex != null || googleSheet.Listindex.Count > 0 || patternNum < googleSheet.Listindex.Count)
            {
                UpdateMapList();
                GetMapValue();
            }


        }
    }
    IEnumerator WaitingTime(float time)
    {
        patternNum = lastPatternum;
        googleSheet.URL = lastMap;
        yield return new WaitForSeconds(time);
        googleSheet.CreateMap();
        p.DestrtoyObject();
    }

    //private void FixedUpdate()
    //{
    //    if (googleSheet == null)
    //        return;  

    //    if (Time.time > LastSpawnTime + SpawnSpeed / p.GroundScrollSpeed)//몬스터 생성 주기
    //    {
    //        LastSpawnTime = Time.time;

    //        if (googleSheet.Listindex == null || googleSheet.Listindex.Count < 1)
    //        {
                
    //            Debug.Log("값이 없다유");
    //            return;
    //        }
    //        if (googleSheet.Listindex != null || googleSheet.Listindex.Count > 0 || patternNum < googleSheet.Listindex.Count)  
    //        {
    //            UpdateMapList();
    //            GetMapValue();  
    //        }


    //    }

    //}

    void GetMapValue()
    {
        int p = 0;
        if (jellyAmount + jellyYpos > 10)
        {

            p = Mathf.Abs(11 - jellyYpos);
        }
        else { p = jellyAmount; }


        for (int i = 0; i < p; i++)
        {

            int j = 0;
            if (obstacleType == 1)
            {
                j = 3;
            }
            if (obstacleType == 2)
            {
                j = 7;
            }
            if (ground > 1)
            { j++; }
            if (jellyYpos >= j)
            { j = 0; }
            Instantiate(itembox.Items[jellyType], transform.GetChild((jellyYpos) + j + i));

        }
        if (obstacleType >= 1)
        {
            Instantiate(itembox.Obstacles[(obstacleType) - 1], transform.GetChild(obstaclePos));

        }
        if (ground > 1)
        {
            Instantiate(itembox.Ground[0], transform.GetChild(ground));

        }
        PatternNum++;
    }
    void UpdateMapList()
    {

        //Debug.Log($"PatternNum : {PatternNum}");  
        //Debug.Log($"googleSheet.ListJellyType : {googleSheet.ListJellyType.Count}");
        if (googleSheet.ListJellyType.Count < 1)
            return;  
        if (googleSheet.ListJellyType.Contains((int)patternNum))
        {
            jellyType = googleSheet.ListJellyType[PatternNum];      
        }

        if (PatternNum < 0 || patternNum >= googleSheet.ListJellyYpos.Count)
            return;
        jellyYpos = googleSheet.ListJellyYpos[PatternNum];

        if (PatternNum < 0 || patternNum >= googleSheet.ListJellyAmount.Count)
            return;
        jellyAmount = googleSheet.ListJellyAmount[PatternNum];

        if (PatternNum < 0 || patternNum >= googleSheet.ListObstacleType.Count)
            return;
        obstacleType = googleSheet.ListObstacleType[PatternNum];

        if (PatternNum < 0 || patternNum >= googleSheet.ListObstacle.Count)   
            return;
        obstaclePos = googleSheet.ListObstacle[PatternNum];

        if (PatternNum < 0 || patternNum >= googleSheet.ListGround.Count)
            return;
        ground = googleSheet.ListGround[PatternNum];
    }
}

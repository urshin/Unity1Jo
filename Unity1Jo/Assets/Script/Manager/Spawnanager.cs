//아이템 및 장애물 생성 매니저
//아이템 및 장애물 생성 매니저
//아이템 및 장애물 생성 매니저
//아이템 및 장애물 생성 매니저

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;//랜덤함수 처리

public class Spawnanager : SingletonBehaviour<Spawnanager>
{

    void Awake()
    {
        base.Awake();
    }

    [Header("적 종류")]
    [SerializeField] GameObject ShortEnemy;//1단 점프로 피해지는 적
    [SerializeField] GameObject LongEnemy;//2단 점프로 피해지는 적
    [SerializeField] GameObject UpEnemy; //슬라이드로 피해지는 적
    [SerializeField] int patternNum; //패턴 번호
    float LastSpawnTime;

    [Header("SpawnPosition")]
    [SerializeField] Transform UpSpawnPos;//1단 점프로 피해지는 적
    [SerializeField] Transform GroundSpawnPos;//2단 점프로 피해지는 적
    [SerializeField] Transform SlideSpawnPos;//2단 점프로 피해지는 적




    //장애물 생성 패턴
    //장애물 생성 패턴
    //장애물 생성 패턴
    void FixedUpdate()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null) //플레이어가 있으면
        {

            SpawnPattern();
        }
    }

    void SpawnPattern()
    {

        if (Time.time > LastSpawnTime + 5.0f)//몬스터 생성 주기
        {
            LastSpawnTime = Time.time;
            patternNum = Random.Range(0, 3);  //패턴 랜덤
            StartCoroutine(attack(patternNum)); //해당 숫자에 맞는 코루틴 돌리기
        }
    }

    //몬스터 생성 패턴
    //고려해야 할 점은 나중에 대쉬가 되면 map과 적이 이속이 빨라지게 되는데 
    //이때 적 생성주기가 일정하면 적이 띄엄띄엄 생성됨 -> 근디 어차피 대쉬때는 무적이라 괜찮나
    IEnumerator attack(int p) //패턴 함수들
    {
        if (p == 0)
        {
            for (int i = 0; i < 3; i++)
            {
                Instantiate(ShortEnemy, GroundSpawnPos.position, Quaternion.identity);
                yield return new WaitForSeconds(0.5f);
            }
        }

        if (p == 1)
        {
            for (int i = 0; i < 2; i++)
            {
                Instantiate(LongEnemy, GroundSpawnPos.position, Quaternion.identity);
                yield return new WaitForSeconds(0.5f);
            }
        }
        if (p == 2)
        {
            for (int i = 0; i < 2; i++)
            {
                Instantiate(UpEnemy, SlideSpawnPos.position, Quaternion.identity);
                yield return new WaitForSeconds(0.5f);
            }
        }

        if (p == 3)
        {
            Instantiate(ShortEnemy, GroundSpawnPos.position, Quaternion.identity);

        }

        if (p == 4)
        {
            Instantiate(ShortEnemy, GroundSpawnPos.position, Quaternion.identity);

        }
        if (p == 5)
        {
            Instantiate(ShortEnemy, GroundSpawnPos.position, Quaternion.identity);

        }
        yield return new WaitForSeconds(1f);
    }








}

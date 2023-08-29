//점수 및 정보를 담고있는 게임 매니저
//점수 및 정보를 담고있는 게임 매니저
//점수 및 정보를 담고있는 게임 매니저
//점수 및 정보를 담고있는 게임 매니저

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonBehaviour<GameManager>
{
    void Awake()
    {
        base.Awake();
    }

    [Header("플레이어 아이템 변수")]
    [SerializeField] public float JellyPoint; //젤리 점수
    [SerializeField] public float Coin; //코인 점수

    //bonusTime젤리는 어찌 처리할지 고민이라 일단 게임 오브젝트로 만들어 두었습니다.
    [SerializeField] public GameObject[] BonusTimeJelly; //보너스타임젤리 가져오기

    //[Header("대쉬 관련")]
    //[SerializeField] public bool isDashing;
    //[SerializeField] public float DashDuration; //대쉬 남아있는 시간
    //[SerializeField] public float GroundScrollSpeed; //현재 진행중인 스피드
    //[SerializeField] public float OriginalGroundScrollSpeed; //원래 초기값 스피드
    //public float DashTime; //대쉬 지속 시간


    //[Header("거대화 관련")]
    //[SerializeField] public bool isGigantic;
    //[SerializeField] public float GiganticSize; //얼마나 커질지
    //[SerializeField] public Vector3 OriginalSize; //원래의 크기
    //[SerializeField] public float GiganticDuration; //거대화 남아있는 시간
    //public float GiganticTime; //거대화 지속 시간


    //private void Start()
    //{
    //    OriginalGroundScrollSpeed = GroundScrollSpeed; //원래 속도값 넣어주기
    //    DashDuration = DashTime; //삭제해도 무방

    //    OriginalSize = GameObject.FindGameObjectWithTag("Player").transform.localScale; //원래 플레이어의 사이즈 저장
    //    GiganticDuration = GiganticTime; //삭제해도 무방


    //}
    //private void FixedUpdate()
    //{
    //    DashDuration -= Time.deltaTime; //시간에 따라서 값 감소
    //    GiganticDuration -= Time.deltaTime;//시간에 따라서 값 감소
    //}


}

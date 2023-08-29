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

    
    


}

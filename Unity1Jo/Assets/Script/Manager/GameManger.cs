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
    [SerializeField] public float currentJellyPoint; //현재 게임에서 얻은 젤리 점수
    [SerializeField] public float bestJellyPoint; //최고 젤리 점수
    [SerializeField] public float currentCoin; //현재 게임에서 얻은 코인 점수
    [SerializeField] public float totalCoin; // 누적 코인 점수  

    //bonusTime젤리는 어찌 처리할지 고민이라 일단 게임 오브젝트로 만들어 두었습니다.
    [SerializeField] public GameObject[] BonusTimeJelly; //보너스타임젤리 가져오기

    private void Update()
    {
        if (currentJellyPoint >= bestJellyPoint)
            bestJellyPoint = currentJellyPoint;
    }

    public AudioClip LoadAudioClip(string path) //SoundManager에 리소스를 로딩하기 위한 메소드
    {
        if (!path.StartsWith("Sounds/"))
        {
            path = "Sounds/" + path;
        }

        AudioClip audioClip = Resources.Load<AudioClip>(path); // Resources 폴더에서 AudioClip을 로드합니다.

        if (audioClip == null) //오류 출력
        {
            Debug.LogError($"AudioClip not found at path: {path}");
        }

        return audioClip;
    }
}

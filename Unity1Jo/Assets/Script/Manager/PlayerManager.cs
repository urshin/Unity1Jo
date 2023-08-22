//플레이어 생성하게 해주는 매니저
//플레이어 생성하게 해주는 매니저
//플레이어 생성하게 해주는 매니저
//플레이어 생성하게 해주는 매니저

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;

    public void Awake()
    {
        if (Instance == null) //정적으로 자신을 체크함, null인진
        {
            Instance = this; //이후 자기 자신을 저장함.
        }
    }
}

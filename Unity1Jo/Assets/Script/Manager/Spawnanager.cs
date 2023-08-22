//아이템 및 장애물 생성 매니저
//아이템 및 장애물 생성 매니저
//아이템 및 장애물 생성 매니저
//아이템 및 장애물 생성 매니저

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnanager : MonoBehaviour
{
    public static Spawnanager Instance;

    public void Awake()
    {
        if (Instance == null) //정적으로 자신을 체크함, null인진
        {
            Instance = this; //이후 자기 자신을 저장함.
        }
    }
}

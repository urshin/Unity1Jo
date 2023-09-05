using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;
using Scene = UnityEngine.SceneManagement.Scene;

public class EnvironmentManager : MonoBehaviour
{
    public static EnvironmentManager Instance;

    [SerializeField] GameObject InGame_EnvironmentObjs;
    [SerializeField] GameObject BonusTime_EnvironmentObjs;  

    // code by 동호
    void Awake()
    {
        Instance = this;

        SetActiveInGameEnvironment(true);
        SetActiveBonusTimeEnvironment(false);
    }
    private void Start()
    {

    }
    // code by 동호
    public void SetActiveInGameEnvironment(bool flag)
    {
        InGame_EnvironmentObjs.SetActive(flag);
    }
    // code by 동호
    public void SetActiveBonusTimeEnvironment(bool flag)      
    {
        BonusTime_EnvironmentObjs.SetActive(flag);  
    }

    public GameObject GetInGameMap()
    {
        return InGame_EnvironmentObjs;
    }
    public GameObject GetBonusMap()
    {
        return BonusTime_EnvironmentObjs;
    }
    // code by 대석
    // 씬이 넘어갈때 BonusMap false 상태로 전환
    //public void BonusMapLoad(Scene scene, LoadSceneMode mode)
    //{
    //    if(BonusTime_EnvironmentObjs != null)
    //    {
    //        BonusTime_EnvironmentObjs.SetActive(false);
    //    }
    //}
}

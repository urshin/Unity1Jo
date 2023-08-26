using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentManager : SingletonBehaviour<EnvironmentManager>
{
    [SerializeField] GameObject InGame_EnvironmentObjs;
    [SerializeField] GameObject BonusTime_EnvironmentObjs;  

    // code by 동호
    void Awake()
    {
        base.Awake(); // 부모의 awake 호출 
    }
    private void Start()
    {
        SetActiveBonusTimeEnvironment(false);  
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
}

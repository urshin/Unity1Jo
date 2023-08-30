using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class UserDataManager : SingletonBehaviour<UserDataManager>
{
    private int selectCookieID =100;  // 선택한 쿠키의 ID 값 
    private Dictionary<int, int> HasCookieDic = new Dictionary<int, int>(); 
    private void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
  
    }

    private void SetHasCookie(int key, bool hasCookie)
    {
        if (HasCookieDic.ContainsKey(key))
        {
            HasCookieDic[key] = hasCookie ? 1 : 0;
        }
        return;
    }

    private int GetHasCookie(int key)
    {
        if (HasCookieDic.ContainsKey(key))
        {
            return HasCookieDic[key];
        }
        return 0; //기본 값은 0
    }

    public void SetSelectCookieID(int id)
    {
        selectCookieID = id;  
    }
    public int GetSelectCookieID()
    {
        return selectCookieID;
    }
}

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

    public void SetSelectCookieID(int id)
    {
        selectCookieID = id;  
    }
    public int GetSelectCookieID()
    {
        return selectCookieID;
    }
}

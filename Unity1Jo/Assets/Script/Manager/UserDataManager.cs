using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class UserDataManager : SingletonBehaviour<UserDataManager>
{
    [SerializeField] private int selectCookieID =100;  // 선택한 쿠키의 ID 값 
    private Dictionary<int, int> HasCookieDic = new Dictionary<int, int>(); 
    private void Awake()
    {
        base.Awake();
        CookieDicInit();
    }

    private void Start()
    {
  
    }
    public void CookieDicInit()
    {
        HE_DataManager.instance.LoadData();
        HasCookieDic.Clear();
        foreach (var data in HE_DataManager.instance.GetMycookiesDatas())
        {
            if(data.id == 100)
            {
                HasCookieDic.Add(data.id, 1);
            }
            else
            {
                HasCookieDic.Add(data.id, 0);

            }
        }
    }

    public void SetHasCookie(int key, bool hasCookie)
    {
        if (HasCookieDic.ContainsKey(key))
        {
            HasCookieDic[key] = hasCookie ? 1 : 0;
        }
        return;
    }

    public int GetHasCookie(int key)
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

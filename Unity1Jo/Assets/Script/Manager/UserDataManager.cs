using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class UserDataManager : SingletonBehaviour<UserDataManager>
{
    [SerializeField] private int selectCookieID =100;  // 선택한 쿠키의 ID 값 
    [SerializeField] private int selectPetID = 100;

    private Dictionary<int, int> HasCookieDic = new Dictionary<int, int>();
    private Dictionary<int, int> HasPetDic = new Dictionary<int, int>();
    private void Awake()
    {
        base.Awake();
        CookieDicInit();
        PetDicInit();    
    }

    private void Start()
    {
  
    }
    #region Cookie
    public void CookieDicInit()
    {
        UI_DataManager.instance.LoadCookiesData();
        HasCookieDic.Clear();
        foreach (var data in UI_DataManager.instance.GetMycookiesDatas())
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

    /* Cookie Dic */
    public void SetHasCookie(int key, bool hasCookie) // 해당 쿠키가 있는지 체크 
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

    /* Pet Dic */
    public void SetHasPet(int key, bool hasPet)
    {
        if (HasPetDic.ContainsKey(key))
        {
            HasPetDic[key] = hasPet ? 1 : 0;
        }
        return;
    }
    public int GetHasPet(int key)
    {
        if (HasPetDic.ContainsKey(key))
        {
            return HasPetDic[key];
        }
        return 0;
    }

    /* Setter & Getter cookie ID*/
    public void SetSelectCookieID(int id)
    {
        selectCookieID = id;  
    }
    public int GetSelectCookieID()
    {
        return selectCookieID;
    }
    #endregion

    #region Pet
    public void PetDicInit()
    {
        UI_DataManager.instance.LoadPetsData();
        HasPetDic.Clear();
        foreach (var data in UI_DataManager.instance.GetMypetsDatas())
        {
            if (data.id == 100)
            {
                HasPetDic.Add(data.id, 1);
            }
            else
            {
                HasPetDic.Add(data.id, 0);

            }
        }
    }

    public void SetHasPet(int key, bool hasPet)
    {
        if (HasPetDic.ContainsKey(key))
        {
            HasPetDic[key] = hasPet ? 1 : 0;
        }
        return;
    }

    public int GetHasPet(int key)
    {
        if (HasPetDic.ContainsKey(key))
        {
            return HasPetDic[key];
        }
        return 0; //기본 값은 0
    }

    public void SetSelectPetID(int id)
    {
        selectPetID = id;
    }
    public int GetSelectPetID()
    {
        return selectPetID;
    }
#endregion

    /* Setter & Getter Pet ID */
    public void SetSelectPetID(int id)
    {
        selectPetID = id;
    }
    public int GetSelectPetID()
    {
        return selectPetID;
    }
}

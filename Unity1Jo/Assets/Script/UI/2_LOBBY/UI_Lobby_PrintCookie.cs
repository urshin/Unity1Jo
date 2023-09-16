using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Lobby_PrintCookie : MonoBehaviour
{
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        //데이터 로드
        UI_DataManager.instance.LoadCookiesData();
    }

    void Update()
    {
        MycookiesData data = UI_DataManager.instance.GetMycookiesDatas().Find(cookie => cookie.id == UserDataManager.Instance.GetSelectCookieID());
        if (data != null)
        {
            int id = data.id;
            switch (id)
            {
                case 100:
                    anim.SetInteger("ID", 100);
                    break;
                case 101:
                    anim.SetInteger("ID", 101);
                    break;
                case 102:
                    anim.SetInteger("ID", 102);
                    gameObject.transform.position = new Vector2(1, 0.5f);
                    gameObject.transform.localScale = new Vector2(1.5f, 1.5f);
                    break;
                case 103:
                    anim.SetInteger("ID", 103);
                    break;
                case 104:
                    anim.SetInteger("ID", 104);
                    gameObject.transform.localScale = new Vector2(1.5f, 1.5f);
                    break;
            }
        }
    }
}

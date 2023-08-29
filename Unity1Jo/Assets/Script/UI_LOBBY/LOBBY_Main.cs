using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LOBBY_Main : MonoBehaviour
{
    [SerializeField] SpriteRenderer LobbyCookieImg;    
    void Start()
    {
        //데이터 로드
        HE_DataManager.instance.LoadData();  
        MycookiesData data = HE_DataManager.instance.GetMycookiesDatas().Find(cookie => cookie.id == UserDataManager.Instance.GetSelectCookieID());
        string cookieName = string.Empty;
        if(data != null)
        {
            var atlas = AtlasManager.Instance.GetAtlasByName("MyCookies"); //만약 장애물 sprite도 atlas로 해서 key가 많아지면 enum으로 정리  
            cookieName = data.sprite_name;
            if (!string.IsNullOrEmpty(cookieName))
            {
                LobbyCookieImg.sprite = atlas.GetSprite(cookieName);
                LobbyCookieImg.gameObject.transform.localScale = new Vector2(1.2f, 1.2f);  
            }

        }
    }

    void Update()
    {
        
    }
}

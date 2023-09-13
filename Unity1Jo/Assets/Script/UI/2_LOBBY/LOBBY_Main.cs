using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LOBBY_Main : MonoBehaviour //code by.하은
{
    [SerializeField] SpriteRenderer LobbyCookieImg;
    [SerializeField] SpriteRenderer LobbyPetImg;
    [SerializeField] Text bestPointTxt;
    [SerializeField] Text coinTxt;
    [SerializeField] string bgmAudioClipPath = "BGM_Lobby";
    void Start()
    {
        PrintCookie();
        PrintPet();

        //BGM재생
        AudioClip bgmAudioClip = GameManager.Instance.LoadAudioClip(bgmAudioClipPath);
        if(bgmAudioClip != null)
        {
            SoundManager.Instance.Play(bgmAudioClip, Define.Sound.Bgm);
        }
    }

    void PrintCookie()
    {
        //선택한 쿠키 출력
        UI_DataManager.instance.LoadCookiesData();
        MycookiesData data = UI_DataManager.instance.GetMycookiesDatas().Find(cookie => cookie.id == UserDataManager.Instance.GetSelectCookieID());
        string cookieName = string.Empty;
        if (data != null)
        {
            var atlas = AtlasManager.Instance.GetAtlasByName("Cookies");
            cookieName = data.sprite_name;
            if (!string.IsNullOrEmpty(cookieName))
            {
                //MYCOOKIES에서 선택한 쿠키의 spirte를 LOBBY에 출력
                LobbyCookieImg.sprite = atlas.GetSprite(cookieName);
                LobbyCookieImg.gameObject.transform.localScale = new Vector2(2f, 2f);
            }
        }
    }

    void PrintPet()
    {
        //선택한 펫 출력
        UI_DataManager.instance.LoadPetsData();
        MyPetsData petdata = UI_DataManager.instance.GetMypetsDatas().Find(pet => pet.id == UserDataManager.Instance.GetSelectPetID());
        string petName = string.Empty;
        if (petdata != null)
        {
            var atlas = AtlasManager.Instance.GetAtlasByName("Pets");
            petName = petdata.sprite_name;
            if (!string.IsNullOrEmpty(petName))
            {
                LobbyPetImg.sprite = atlas.GetSprite(petName);
                //LobbyPetImg.gameObject.transform.localScale = new Vector2(2f, 2f);
            }
        }
    }

    void Update()
    {
        if (coinTxt == null)
            return;
        coinTxt.text = string.Format("{0:#,0}", GameManager.Instance.totalCoin);
        bestPointTxt.text = string.Format("{0:#,0}", GameManager.Instance.bestJellyPoint);
    }
}

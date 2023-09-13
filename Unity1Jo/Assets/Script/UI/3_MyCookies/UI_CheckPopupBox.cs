using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_CheckPopupBox : MonoBehaviour
{
    int cookieID;
    int cookiePrice;
    [SerializeField] Text message;
    UIScrollView cookieScrollView;

    int petID;
    int petPrice;
    MYPETS_UIScrollView petScrollView;

    [SerializeField] Define.PopupType popupType;  

    [SerializeField] GameObject oKBtn;
    [SerializeField] GameObject closeBtn;

    [SerializeField] string effectAudioClipPath = "E_BuyCookie";
    [SerializeField] string effectAudioClipPath2 = "E_ClickBtn";

    private void Awake()
    {
        oKBtn.AddUIEvent(OnOkBtnClicked);
        closeBtn.AddUIEvent(OnCloseBtnClicked);  
    }

    private void Start()
    {
        switch (popupType)
        {
            case Define.PopupType.Cookie:
                message.text = "캐릭터를 구매하시겠습니까?";
                break;
            case Define.PopupType.Pet:
                message.text = "펫을 구매하시겠습니까?";
                break;
        }
    }

    #region Cookies Setter
    public void SetCookieID(int id)
    {
        cookieID = id;
    }

    public void SetCookiePrice(int price)
    {
        cookiePrice = price;
    }
    public void SetCookieScrollView(UIScrollView view)
    {
        cookieScrollView = view;
    }
    public void SetPopupType(Define.PopupType type)
    {
        popupType = type;
    }
    #endregion

    #region Pets Setter
    /* Pets Setter */
    public void SetPetID(int id)
    {
        petID = id;
    }

    public void SetPetPrice(int price)
    {
        petPrice = price;
    }
    public void SetPetScrollView(MYPETS_UIScrollView view)
    {
        petScrollView = view;
    }
    #endregion

    #region 구매버튼 기능구현
    void OnOkBtnClicked(PointerEventData data)
    {
        Debug.Log($"ID : {cookieID} 구매 완료 ~!! ");

        //Effect재생
        AudioClip effectAudioClip = GameManager.Instance.LoadAudioClip(effectAudioClipPath);
        if (effectAudioClip != null)
            SoundManager.Instance.Play(effectAudioClip, Define.Sound.Effect);


        switch (popupType)
        {
            case Define.PopupType.Cookie:
                BuyCookie();
                break;
            case Define.PopupType.Pet:
                BuyPet();
                break;
        }



        ClosePopup();  
    }
    #endregion


    void BuyCookie()
    {
        //코인사용
        GameManager.Instance.totalCoin -= cookiePrice;

        //유저 정보 업데이트
        UserDataManager.Instance.SetHasCookie(cookieID, true);
        if (cookieScrollView == null)
            return;

        UIScrollViewCookiesSelect cookie = cookieScrollView.GetCookieComponentList()?.Find(item => item.GetID() == cookieID); // 구매한 쿠키의 Component 가져옴 
        if (cookie != null)
        {
            cookie.SetActivePanel(); // 선택 패널로 바꿔줌 
            cookie.RefreshLock(); //  lock 풀어줌    
        }
    }
    void BuyPet()
    {
        //코인사용
        GameManager.Instance.totalCoin -= petPrice;

        //유저 정보 업데이트
        UserDataManager.Instance.SetHasPet(petID, true);  
        if (petScrollView == null)
            return;
        Debug.Log("buy pet 들어옴111");

        UIScrollViewPetsSelect pet = petScrollView.GetPetComponentList()?.Find(item => item.GetID() == petID); // 구매한 펫의 Component 가져옴 
        if (pet != null)
        {
            Debug.Log("buy pet 들어옴222");

            pet.SetActivePanel(); // 선택 패널로 바꿔줌 
            pet.RefreshLock(); //  lock 풀어줌       
        }
    }
    #region 팝업창닫기버튼 기능구현
    void OnCloseBtnClicked(PointerEventData data)
    {
        //Effect재생
        AudioClip effectAudioClip = GameManager.Instance.LoadAudioClip(effectAudioClipPath2);
        if (effectAudioClip != null)
            SoundManager.Instance.Play(effectAudioClip, Define.Sound.Effect);

        ClosePopup();
    }

    void ClosePopup()
    {
        gameObject.transform.parent.gameObject.SetActive(false);
        Destroy(gameObject);
    }
    #endregion
}

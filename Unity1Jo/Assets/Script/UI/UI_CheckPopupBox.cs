using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_CheckPopupBox : MonoBehaviour
{
    int cookieID;
    int cookiePrice;
    UIScrollView cookieScrollView;

    [SerializeField] GameObject oKBtn;
    [SerializeField] GameObject closeBtn;

    private void Awake()
    {
        oKBtn.AddUIEvent(OnOkBtnClicked);
        closeBtn.AddUIEvent(OnCloseBtnClicked);  
    }

    /* Setter */
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

    /* 구매 버튼 기능 구현 */
    void OnOkBtnClicked(PointerEventData data)
    {
        Debug.Log($"ID : {cookieID} 구매 완료 ~!! ");

        GameManager.Instance.totalCoin -= cookiePrice;
        UserDataManager.Instance.SetHasCookie(cookieID, true); // 유저 정보 업데이트 
        if (cookieScrollView == null)
            return;

        UIScrollViewCookiesSelect cookie = cookieScrollView.GetCookieComponentList()?.Find(item => item.GetID() == cookieID); // 구매한 쿠키의 Component 가져옴 
        if (cookie != null)
        {
            cookie.SetActivePanel(); // 선택 패널로 바꿔줌 
            cookie.RefreshLock(); //  lock 풀어줌    
        }

        ClosePopup();  
    }

    /* 닫기 버튼 기능 구현 */
    void OnCloseBtnClicked(PointerEventData data)
    {
        ClosePopup();
    }

    void ClosePopup()
    {
        gameObject.transform.parent.gameObject.SetActive(false);
        Destroy(gameObject);
    }

}

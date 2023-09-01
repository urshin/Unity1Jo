using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MYCOOKIES_Main : MonoBehaviour //code by. 하은
{
    public UIMyCookies uiMyCookies;
    public GameObject myCookiesContent;
    [SerializeField] UIScrollView cookieScrollView;

    void Start()
    {
        //데이터 로드
        HE_DataManager.instance.LoadData();

        //버튼클릭 정보(id)를 받아서 해당 Event 발생시킴
        EventManager.instance.onSelectBtnClick = (id) => {
            var data = HE_DataManager.instance.GetData(id);

            //뒤로가기 누르면 LOBBY씬으로 바뀌면서 해당 캐릭터가 출력
            if (UserDataManager.Instance.GetHasCookie(id) == 0) // 쿠키 안가지고 있으면 리턴 
                return;

            UserDataManager.Instance.SetSelectCookieID(id);
            UIScrollViewCookiesSelect beforeCheckcookieComponent = cookieScrollView.GetCookieComponentList()?.Find(item => item.GetCheck() == true); // 현재 체크되어있는 쿠키 컴포넌트 가져옴 
            UIScrollViewCookiesSelect afterCheckcookieComponent = cookieScrollView.GetCookieComponentList()?.Find(item => item.GetID() == data.id);  // 선택된 쿠기 컴포넌트 가져옴 
            beforeCheckcookieComponent?.RefreshCheck(); // 선택 refresh 
            afterCheckcookieComponent?.RefreshCheck();  // 선택 refresh 

            Debug.LogFormat("{0},{1} 캐릭터가 선택되었습니다", data.id, data.name);
        };

        EventManager.instance.onBuyBtnClick = (id) => {
            var data = HE_DataManager.instance.GetData(id);
            Debug.LogFormat("{0},{1},{2}", data.id, data.name, data.price);

            // TODO : 구매 버튼 구현 
            float totCoin = GameManager.Instance.totalCoin; // total coin 가져옴 
            Debug.Log($"totCoin : {totCoin}");
            if (totCoin >= data.price)
            {
                GameManager.Instance.totalCoin -= data.price; 
                UserDataManager.Instance.SetHasCookie(data.id, true); // 유저 정보 업데이트 
                UIScrollViewCookiesSelect cookie = cookieScrollView.GetCookieComponentList()?.Find(item => item.GetID() == data.id); // 구매한 쿠키의 Component 가져옴 
                if (cookie != null)
                {
                    cookie.SetActivePanel(); // 선택 패널로 바꿔줌 
                    cookie.RefreshLock();   //  lock 풀어줌   
                }
            }
            else
            {
                Debug.Log("코인이 부족합니다.");
            }



        };

        //UIMyCookies 초기화
        uiMyCookies.Initialize();
    }
}

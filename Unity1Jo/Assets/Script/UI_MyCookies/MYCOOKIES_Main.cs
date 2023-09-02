using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MYCOOKIES_Main : MonoBehaviour //code by. 하은
{
    [SerializeField] UIMyCookies uiMyCookies;
    [SerializeField] UIScrollView cookieScrollView;
    [SerializeField] UIPopupScale Popup; //code by. 하은
    [SerializeField] GameObject myCookiesContent;
    [Space]


    [Header("Popup Data")]
    [SerializeField] GameObject UI_BuyPopup;
    [SerializeField] GameObject ui_CheckPopupBox;
    [SerializeField] GameObject ui_CautionPopupBox;
    [SerializeField] private Vector3 targetScale = new Vector3(1.2f, 1.2f, 1.2f); // 확대할 스케일 값
    [SerializeField] private Vector3 originScale = new Vector3(1, 1, 1); // 확대할 스케일 값
    [SerializeField] private float animationDuration = 0.2f; // 애니메이션 지속 시간  

    private void Awake()
    {

        foreach (Transform child in UI_BuyPopup.transform)
            GameObject.Destroy(child.gameObject);

        UI_BuyPopup.gameObject.SetActive(false);  

    }

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
            UIScrollViewCookiesSelect afterCheckcookieComponent = cookieScrollView.GetCookieComponentList()?.Find(item => item.GetID() == data.id);  // 선택된 쿠키 컴포넌트 가져옴 
            beforeCheckcookieComponent?.RefreshCheck(); // 선택 refresh 
            afterCheckcookieComponent?.RefreshCheck();  // 선택 refresh 

            Debug.LogFormat("{0},{1} 캐릭터가 선택되었습니다", data.id, data.name);
        };

        EventManager.instance.onBuyBtnClick = (id) => {
            var data = HE_DataManager.instance.GetData(id);
            Debug.LogFormat("{0},{1},{2}", data.id, data.name, data.price);

            float totCoin = GameManager.Instance.totalCoin; // total coin 가져옴 
            Debug.Log($"totCoin : {totCoin}");

            //Debug.Log($"구매하기 버튼 누르기 전 Popup.isBuy: {Popup.isBuy}");

            if (totCoin >= data.price)
            {
                UI_BuyPopup.gameObject.SetActive(true);

                GameObject checkPopupBox = Instantiate(ui_CheckPopupBox);   // 동적으로 popup 생성 (해당 프리팹 위치 : Asset/Prefabs/UI/Popup)
                checkPopupBox.transform.SetParent(UI_BuyPopup.transform);   // 부모 설정 
                checkPopupBox.GetComponent<RectTransform>().localPosition = Vector2.zero;   // position 설정 
                checkPopupBox.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1); // scale 설정 

                // popup animation 
                checkPopupBox.GetComponent<RectTransform>().DOScale(targetScale, animationDuration).OnComplete(() => {
                    checkPopupBox.GetComponent<RectTransform>().DOScale(originScale, animationDuration);   
                });  

                // ID, price, view 설정해줌   
                UI_CheckPopupBox checkComponent = checkPopupBox.GetComponent<UI_CheckPopupBox>();
                checkComponent.SetCookieID(data.id);
                checkComponent.SetCookiePrice(data.price);
                checkComponent.SetCookieScrollView(cookieScrollView);

            }
            else 
            {
                UI_BuyPopup.gameObject.SetActive(true);

                GameObject cautionPopupBox = Instantiate(ui_CautionPopupBox);   // 동적으로 popup 생성  (해당 프리팹 위치 : Asset/Prefabs/UI/Popup)
                cautionPopupBox.transform.SetParent(UI_BuyPopup.transform);     // 부모 설정 
                cautionPopupBox.GetComponent<RectTransform>().localPosition = Vector2.zero; // position 설정 
                cautionPopupBox.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1); // scale 설정 

                // popup animation 
                cautionPopupBox.GetComponent<RectTransform>().DOScale(targetScale, animationDuration).OnComplete(() => {
                    cautionPopupBox.GetComponent<RectTransform>().DOScale(originScale, animationDuration);  
                });

                Debug.Log("코인이 부족합니다.");
            }

            /* 기존 코드 */
            //if (totCoin >= data.price && Popup != null)
            //{
            //    Popup.ShowCheckPopup(); //code by. 하은
            //    Debug.Log($"구매하기 버튼 누른 다음 Popup.isBuy: {Popup.isBuy}");
            //    if (Popup.isBuy == true)
            //    {
            //        //Popup.HideCheckPopup();
            //        GameManager.Instance.totalCoin -= data.price;
            //        UserDataManager.Instance.SetHasCookie(data.id, true); // 유저 정보 업데이트 
            //        UIScrollViewCookiesSelect cookie = cookieScrollView.GetCookieComponentList()?.Find(item => item.GetID() == data.id); // 구매한 쿠키의 Component 가져옴 
            //        if (cookie != null)
            //        {
            //            cookie.SetActivePanel(); // 선택 패널로 바꿔줌 
            //            cookie.RefreshLock(); //  lock 풀어줌
            //        }
            //    }
            //}
            //else if(totCoin < data.price && Popup != null)
            //{
            //    Popup.ShowCautionPopup(); //code by. 하은
            //    //Debug.Log("코인이 부족합니다.");
            //}
        };

        //UIMyCookies 초기화
        uiMyCookies.Initialize();
    }
}

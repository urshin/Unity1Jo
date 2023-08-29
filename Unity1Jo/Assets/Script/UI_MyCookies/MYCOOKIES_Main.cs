using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MYCOOKIES_Main : MonoBehaviour //code by. 하은
{
    public UIMyCookies uiMyCookies;
    public GameObject myCookiesContent;  

    void Start()
    {
        //데이터 로드
        HE_DataManager.instance.LoadData();

        //버튼클릭 정보(id)를 받아서 해당 Event 발생시킴
        EventManager.instance.onSelectBtnClick = (id) => {
            var data = HE_DataManager.instance.GetData(id);
            //선택되었다는 이미지(초록색 테두리)
            //뒤로가기 누르면 LOBBY씬으로 바뀌면서 해당 캐릭터가 출력
            UserDataManager.Instance.SetSelectCookieID(id);  
            for(int i = 0; i < myCookiesContent.transform.childCount; i++)
            {
                GameObject item = myCookiesContent.transform.GetChild(i).gameObject;
                if(item != null)
                {
                    UIScrollViewCookiesSelect itemComponent = item.GetComponent<UIScrollViewCookiesSelect>();
                    if(itemComponent.GetID() == id)
                    {
                        itemComponent.SetCheck(true);
                    }
                    else
                    {
                        itemComponent.SetCheck(false);    

                    }
                }
            }


            Debug.LogFormat("{0},{1} 캐릭터가 선택되었습니다", data.id, data.name);
        };

        EventManager.instance.onBuyBtnClick = (id) => {
            var data = HE_DataManager.instance.GetData(id);
            Debug.LogFormat("{0},{1},{2}", data.id, data.name, data.price);
        };

        //UIMyCookies 초기화
        uiMyCookies.Initialize();
    }
}

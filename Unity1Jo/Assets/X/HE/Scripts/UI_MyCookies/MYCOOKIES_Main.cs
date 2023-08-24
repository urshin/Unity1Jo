using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MYCOOKIES_Main : MonoBehaviour
{
    public UIMyCookies uiMyCookies;

    void Start()
    {
        //데이터 로드
        HE_DataManager.instance.LoadData();

        //버튼클릭 정보 받음
        EventManager.instance.onSelectBtnClick = () => {
            Debug.Log("이 캐릭터가 선택되었습니다");
        };

        EventManager.instance.onBuyBtnClick = (id) => {
            var data = HE_DataManager.instance.GetData(id);
            Debug.LogFormat("{0},{1},{2}", data.id, data.name, data.price);
        };

        //UIMyCookies 초기화
        uiMyCookies.Initialize();
    }
}

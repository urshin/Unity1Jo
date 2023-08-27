using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScrollView : MonoBehaviour
{
    [SerializeField] Transform contentTrans;
    [SerializeField] GameObject cookiePrefab;

    public void Initialize()
    {
        //MycookiesData가 들어가있는 List를 전달받아서 Cookie를 생성
        List<MycookiesData> list = HE_DataManager.instance.GetMycookiesDatas();

        foreach (MycookiesData data in list)
        {
            //create
            AddCookies(data);
        }
    }

    //Cookies 생성
    public void AddCookies(MycookiesData data)
    {
        //프리팹 인스턴스 생성, contentTrans 자식으로 부착
        var go = Instantiate(cookiePrefab, contentTrans);
        UIScrollViewCookiesSelect cookies = go.GetComponent<UIScrollViewCookiesSelect>();

        cookies.Initialize(data);

        //각 버튼을 누르면 해당 cookies의 id를 EventManager에게 전달
        cookies.selectBtn.onClick.AddListener(() => {
            EventManager.instance.onSelectBtnClick(cookies.id);
        });
        cookies.buyBtn.onClick.AddListener(() => {
            EventManager.instance.onBuyBtnClick(cookies.id);
        });
    }
}

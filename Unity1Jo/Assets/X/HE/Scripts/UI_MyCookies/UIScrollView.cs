using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScrollView : MonoBehaviour
{
    [SerializeField] Transform contentTrans;
    [SerializeField] GameObject itemPrefab;

    public void Initialize()
    {
        List<MycookiesData> list = HE_DataManager.instance.GetMycookiesDatas();

        foreach (MycookiesData data in list)
        {
            if (data.type == 0)
            {
                AddCookies(data);
                //lock
            }
            else if (data.type == 1)
            {
                AddCookies(data);
                //unlock
            }
        }
    }
    public void AddCookies(MycookiesData data)
    {
        //프리팹 인스턴스 생성, contentTrans 자식으로 부착
        var go = Instantiate(itemPrefab, contentTrans);
        UIScrollViewCookiesSelect cookies = go.GetComponent<UIScrollViewCookiesSelect>();

        cookies.Initialize(data);

        cookies.selectBtn.onClick.AddListener(() => {
            Debug.LogFormat("이 캐릭터(id:{0}) 선택", cookies.id);

            //Event발생
            EventManager.instance.onSelectBtnClick();
        });
        cookies.buyBtn.onClick.AddListener(() => {
            Debug.LogFormat("이 캐릭터(id:{0}) 구매", cookies.id);

            //Event발생
            EventManager.instance.onBuyBtnClick(cookies.id);
        });
    }
}

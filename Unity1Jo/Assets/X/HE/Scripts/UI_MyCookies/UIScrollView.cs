using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScrollView : MonoBehaviour
{
    [SerializeField] Transform contentTrans;
    [SerializeField] GameObject itemPrefab;

    public void Initialize()
    {
        //i값의 범위를 조절하면 스크롤뷰에 쿠키종류를 무한으로 늘릴 수 있음
        //Cookie 5개 생성(기본, 바다요정 ...)
        for (int i = 0; i <50; i++)
        {
            AddCookies();
        }
    }
    public void AddCookies()
    {
        //프리팹 인스턴스 생성, contentTrans 자식으로 부착
        var go = Instantiate(itemPrefab, contentTrans);
        UIScrollViewCookiesSelect cookies = go.GetComponent<UIScrollViewCookiesSelect>();
        cookies.selectBtn.onClick.AddListener(() => { Debug.Log("이 캐릭터 선택"); });
        cookies.buyBtn.onClick.AddListener(() => { Debug.Log("이 캐릭터 구매"); });
    }
}

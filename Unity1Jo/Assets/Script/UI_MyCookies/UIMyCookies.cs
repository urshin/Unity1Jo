using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIMyCookies : MonoBehaviour //code by. 하은
{
    public UIScrollView uiScrollView;
    public Text coinTxt;

    public void Initialize() //재화, 탭메뉴, 스크롤뷰 등등 초기화
    {
        //스크롤뷰 초기화
        uiScrollView.Initialize();
    }

    public void Update()
    {
        coinTxt.text = string.Format("{0:n0}", GameManager.Instance.totalCoin);
    }

}

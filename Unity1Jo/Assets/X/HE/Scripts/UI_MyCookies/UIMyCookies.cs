using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D; //SpriteAtlas 컴포넌트 사용에 필요

public class UIMyCookies : MonoBehaviour
{
    public UIScrollView uiScrollView;
    public SpriteAtlas atlas;

    public void Initialize() //재화, 탭메뉴, 스크롤뷰 등등 초기화
    {

        //스크롤뷰 초기화
        uiScrollView.Initialize();
    }

}

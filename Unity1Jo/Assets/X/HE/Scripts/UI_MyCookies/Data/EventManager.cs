using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//MYCOOKIES씬에서 선택/구매 버튼을 클리했을 때 UIScrollView에서 MYCOOKIES_Main으로 버튼에 대한 정보를 넘겨주기 위한 매니저 
public class EventManager
{
    public static readonly EventManager instance = new EventManager();

    public System.Action onSelectBtnClick;
    public System.Action<int> onBuyBtnClick;

    private EventManager() { }
}

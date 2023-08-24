using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_EventHandler : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    public Action<PointerEventData> OnClickHandler = null;
    public Action<PointerEventData> OnPointerDownHandler = null;
    public Action<PointerEventData> OnPointerUpHandler = null;


    //code by.동호
    public void OnPointerClick(PointerEventData eventData)
    {
        if (OnClickHandler != null) // 구독 신청 했으면 
        {
            OnClickHandler.Invoke(eventData); // 개들한테 Invoke로 event 뿌려주기  

        }
    }

    //code by.동호
    public void OnPointerDown(PointerEventData eventData)
    {
        if (OnPointerDownHandler != null) // 구독 신청 했으면 
        {
            //Debug.Log("OnPointerDown");
            OnPointerDownHandler.Invoke(eventData); // 개들한테 Invoke로 event 뿌려주기  

        }
    }

    //code by.동호
    public void OnPointerUp(PointerEventData eventData)
    {
        if (OnPointerUpHandler != null) // 구독 신청 했으면 
        {
            //Debug.Log("OnPointerUp");
            OnPointerUpHandler.Invoke(eventData); // 개들한테 Invoke로 event 뿌려주기    
        }
    }
}

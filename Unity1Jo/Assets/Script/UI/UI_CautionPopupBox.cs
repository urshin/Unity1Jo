using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_CautionPopupBox : MonoBehaviour
{
    [SerializeField] GameObject CloseBtn;


    private void Awake()
    {
        CloseBtn.AddUIEvent(OnCloseBtnClicked);
    }

    void OnCloseBtnClicked(PointerEventData data)
    {
        Debug.Log("OnCloseBtnClicked");  

        gameObject.transform.parent.gameObject.SetActive(false);  
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScrollViewCookiesSelect : MonoBehaviour //code by. 하은
{
    public Text cookieName;
    public Image cookieImg;
    public Button selectBtn;
    public Button buyBtn;
    public Text priceTxt;
    public int id;
    // lock panel 
    public GameObject lockPanel;
    [SerializeField] GameObject CheckIcon;

    public void Initialize(MycookiesData data)
    {
        id = data.id;
        cookieName.text = data.name;
        var atlas = AtlasManager.Instance.GetAtlasByName("MyCookies"); //만약 장애물 sprite도 atlas로 해서 key가 많아지면 enum으로 정리
        cookieImg.sprite = atlas.GetSprite(data.sprite_name);
        cookieImg.SetNativeSize();
        priceTxt.text = string.Format("{0}",data.price);  
        // user data manager 가지고 있는지 체크 -> 장금해제 

        if(UserDataManager.Instance.GetSelectCookieID() == id)
        {
            SetCheck(true);
        }
        else
        {
            SetCheck(false);  
        }

    }

    public void SetLock(bool flag)
    {
        lockPanel.SetActive(flag);
    }
    public void SetCheck(bool flag)
    {
        CheckIcon.SetActive(flag);
    }
    public int GetID()
    {
        return id;
    }
}

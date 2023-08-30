using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScrollViewCookiesSelect : MonoBehaviour //code by. 하은
{
    public Text cookieName;
    public Image cookieImg;
    public Button selectBtn;
    public Image selectBtncookieIcon;
    public Text selectTxt;
    public Button buyBtn;
    public Text priceTxt;
    public int id;
    public Image lockIcon;
    [SerializeField] GameObject checkIcon;

    public void Initialize(MycookiesData data)
    {
        id = data.id;
        cookieName.text = data.name;
        var atlas = AtlasManager.Instance.GetAtlasByName("MyCookies");
        cookieImg.sprite = atlas.GetSprite(data.sprite_name);
        cookieImg.SetNativeSize();
        priceTxt.text = string.Format("{0}",data.price);  
        // user data manager 가지고 있는지 체크 -> 잠금해제 

        if(UserDataManager.Instance.GetSelectCookieID() == id)
        {
            SetCheck(true);
        }
        else
        {
            SetCheck(false);  
        }

    }

    //public void SetLock(bool flag)
    //{
    //    lockIcon.SetActive(flag);
    //}
    public void SetCheck(bool flag)
    {
        checkIcon.SetActive(flag);
    }
    public int GetID()
    {
        return id;
    }
}

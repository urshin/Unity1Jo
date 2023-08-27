using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScrollViewCookiesSelect : MonoBehaviour
{
    public Text cookieName;
    public Image cookieImg;
    public Button selectBtn;
    public Button buyBtn;
    public Text priceTxt;
    public int id;

    public void Initialize(MycookiesData data)
    {
        id = data.id;
        cookieName.text = data.name;
        var atlas = AtlasManager.instance.GetAtlasByName("MyCookies"); //만약 장애물 sprite도 atlas로 해서 key가 많아지면 enum으로 정리
        cookieImg.sprite = atlas.GetSprite(data.sprite_name);
        cookieImg.SetNativeSize();
        priceTxt.text = string.Format("{0}",data.price);
    }
}

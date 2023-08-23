using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;

public class AtlasTestMain : MonoBehaviour
{
    public Button[] arrBtns;
    public Image cookieImg; //변경될 타겟이미지

    public Texture2D[] srcTextures; //소스 이미지(쿠키)
    public SpriteAtlas atlas; //아틀라스

    void Start()
    {
        for(int i = 0; i < arrBtns.Length; i++)
        {
            var btn = arrBtns[i];
            int index = i; //변수 캡쳐
            btn.onClick.AddListener(() => {
                //클로져(람다식)
                //Debug.LogFormat("i: {0}, idx: {1}", i, index); 
                Texture2D texture = srcTextures[index]; //0,1

                var spriteName = string.Format("img_tutorial_brave0{0}", index);
                Debug.Log(spriteName);

                var sprite = atlas.GetSprite(spriteName);
                //Sprite를 생성_Sprite.Create(texture, rect(x,y,width,height), pivot좌표)
                //Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
                cookieImg.sprite = sprite;
                cookieImg.SetNativeSize();
            });
        }
    }

    void Update()
    {
        
    }
}

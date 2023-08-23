using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AtlasTestMain : MonoBehaviour
{
    public Button[] arrBtns;
    public Image cookieImg; //변경될 할 타겟이미지

    public Texture2D[] srcTextures; //소스 이미지(쿠키)

    void Start()
    {
        for(int i = 0; i < arrBtns.Length; i++)
        {
            var btn = arrBtns[i];
            int index = i; //변수 캡쳐
            btn.onClick.AddListener(() => {
                //클로져(람다식)
                //Debug.LogFormat("i: {0}, idx: {1}", i, index); 
                Texture2D texture = srcTextures[index];
                //Sprite를 생성_Sprite.Create(texture, rect, pivot위치)
                Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            });
        }
    }

    void Update()
    {
        
    }
}

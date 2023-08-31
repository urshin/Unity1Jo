using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIResult : MonoBehaviour
{
    public Text scoreTxt;
    public Text coinTxt; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreTxt.text = string.Format("{0:#,0}", GameManager.Instance.currentJellyPoint);
        coinTxt.text = string.Format("{0:#,0}", GameManager.Instance.currentCoin); //세자릿수마다 ,출력
    }
}

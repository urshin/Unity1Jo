using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class InGameUIManager : MonoBehaviour
{
    Player player;

    public GameObject mainImage; // 전체 이미지
    public GameObject pausePanel;

    public Button pause;
    public Button keepGame;
    public Button exitGame;
    public Button restartGame;

    public RectTransform HpdownEffect; // HP 하얀 이펙트
    public Image HpGage; // HP 실린더
    float HpValue; // 변화하는 값
    float MaxHpValue; // 고정 값

    bool HpDown = true;

    public Text CoinText;
    public Text JellyText;
    
    public static int totalScore;

    [SerializeField] GameObject Bonus;  

    //public GameObject inputUI; // 추후 모바일 빌딩하기 전에 할 것
   
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();  
        pausePanel.SetActive(false);
    }
    private void Start()
    {

        if (HpDown)
        {
            //MaxHp와 Hp가 같음
            MaxHpValue = player.GetHP(); // 수정
            HpValue = player.GetHP();
        }
    }

    private void Update()
    {
        float hpGage = HpValue / MaxHpValue;
        HpGage.fillAmount = hpGage;

        float HpEffect = HpGage.fillAmount;
        HpdownEffect.anchorMin = new Vector2(HpEffect, HpdownEffect.anchorMin.y);
        HpdownEffect.anchorMax = new Vector2(HpEffect, HpdownEffect.anchorMax.y);
        HpdownEffect.anchoredPosition = Vector2.zero; // 없어도 이상없음

        if (HpDown)
        {
            HpValue -= Time.deltaTime;

            if(HpValue <= 0f)
            {
                HpValue = 0;
            }
        }

      
        JellyText.text = string.Format("{0:n0}", GameManager.Instance.JellyPoint);
        CoinText.text = string.Format("{0:n0}", GameManager.Instance.TotalCoin); // 정규표현식 참고
        
        
    }

    public float GetHpValue()
    {
        return HpValue;
    }
}

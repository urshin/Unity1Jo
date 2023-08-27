using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class InGameUIManager : MonoBehaviour
{
    GameObject cookie; // 쿠키에서 HP 변수 가져오기
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
    

    float CookieHP = 100; // 변화할 쿠키 HP(player 임시변수) delete 예정

    bool HpDown = true;

    public Text CoinText;
    public Text JellyText;

    float CoinValue; // 임시변수
    float JellyValue; // 임시변수
    
    public static int totalScore;

    //public GameObject inputUI; // 추후 모바일 빌딩하기 전에 할 것
   
    private void Awake()
    {
        cookie = GameObject.FindGameObjectWithTag("Player");
        player = GetComponent<Player>();
        //pausePanel.SetActive(false);
    }
    private void Start()
    {
        //cookie = GameObject.FindGameObjectWithTag("Player"); 
        //player = GetComponent<Player>();
        

        pausePanel.SetActive(false);

        if (HpDown)
        {
            //MaxHp와 Hp가 같음
            MaxHpValue = CookieHP; //player.hp; // 보호수준을 public으로 낮추거나 프로퍼티로 만들어야함
            HpValue = CookieHP; //player.hp; // 갑자기 player.hp를 불러올 수가 없어졌다.
        }
    }

    private void Update()
    {
        float hpGage = HpValue / MaxHpValue;
        HpGage.fillAmount = hpGage;

        if (HpDown)
        {
            Vector2 effect = HpdownEffect.position;
            effect = new Vector2 (effect.x - Time.deltaTime * 8.25f, effect.y); 
            HpdownEffect.position = effect;
           
            HpValue -= Time.deltaTime;

            if(HpValue <= 0f)
            {
                HpValue = 0;
            }
        }

       // CoinValue = player.coinScore;  왜 참조가 안되지?
        JellyText.text = string.Format("{0:n0}", JellyValue); // CoinValue, JellyValue 임시 변수들
        CoinText.text = string.Format("{0:n0}", CoinValue); // 정규표현식 참고
        

    }
}

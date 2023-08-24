using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayUIManager : MonoBehaviour
{
    [SerializeField] GameManager mainImage; // 전체 이미지
    public GameObject panel;

    public Image HpdownEffect;
    public Image HpGage;
    public float HpValue;
    public float MaxHP;

    public GameObject CoinText;
    public GameObject JellyText;
    
    public int totalScore;

    public GameObject inputUI; // 추후 모바일 빌딩하기 전에 할 것

    private void Start()
    {
        
    }

    private void Update()
    {
        HpValue -= Time.deltaTime;
    }
}

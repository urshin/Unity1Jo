using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIResult : MonoBehaviour
{
    [SerializeField] Text scoreTxt;
    [SerializeField] Text coinTxt;
    [SerializeField] Text dialogueTxt;

    float targetScore;
    float currentScore;
    float targetCoin;
    float currentCoin;
    float timer = 0.0f;
    [SerializeField] float duration = 3.0f;

    void Start()
    {
        //데이터 로드
        HE_DataManager.instance.LoadData();

        currentScore = 0;
        targetScore = GameManager.Instance.currentJellyPoint;
        currentCoin = 0;
        targetCoin = GameManager.Instance.currentCoin;
    }
    void Update()
    {
        timer += Time.deltaTime;

        // 스코어와 코인을 목표까지 점진적으로 증가시키기
        if (timer < duration)
        {
            float progress = timer / duration;
            currentScore = Mathf.Lerp(0, targetScore, progress);
            currentCoin = Mathf.Lerp(0, targetCoin, progress);
        }
        else
        {
            currentScore = targetScore;
            currentCoin = targetCoin;
        }

        // 텍스트 업데이트
        scoreTxt.text = string.Format("{0:#,0}", currentScore);
        coinTxt.text = string.Format("{0:#,0}", currentCoin); //세자릿수마다 ,출력

        MycookiesData data = HE_DataManager.instance.GetMycookiesDatas().Find(cookie => cookie.id == UserDataManager.Instance.GetSelectCookieID());
        if (data != null)
        {
            int id = data.id;
            switch (id)
            {
                case 100:
                    dialogueTxt.text = "달리기 하면 나지!";
                    break;
                case 101:
                    dialogueTxt.text = "놀아줘~ 같이 날자~";
                    break;
                case 102:
                    dialogueTxt.text = "자~ 자~ 축배를 들자구!";
                    break;
                case 103:
                    dialogueTxt.text = "우월얽.. 갈거다, 집에...";
                    break;
                case 104:
                    dialogueTxt.text = "꿈을 꾸는 기분이에요";
                    break;
            }
        }
    }
}

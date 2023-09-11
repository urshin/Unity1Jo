using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Item;

public class PlayerBonusTimeCount : MonoBehaviour
{
    int BonusJelly;
    Player p;

    string bgmAudioClipPath = "BGM_Bonustime";

    [SerializeField] bool[] BonusAlphaBetCount = new bool[9];
    private void Start()
    {
        p = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public void ClearBonusAlphaBetCount()
    {
        for(int i=0;i< BonusAlphaBetCount.Length; i++)
        {
            BonusAlphaBetCount[i] = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Item") && collision.gameObject.GetComponent<GetItem>() && !p.isBonusTime)
        {

            var WhatAlpa = collision.gameObject.GetComponent<GetItem>().item.ItemType;
            Sprite sprite = collision.gameObject.GetComponent<GetItem>().item.itemImage;


            switch (WhatAlpa)
            {
                case BonusTimeType.B:
                    {
                        BonusJelly = 0;
                        p.BonusJellyCount++;
                        break;
                    }
                case BonusTimeType.O:
                    {
                        BonusJelly = 1;
                        p.BonusJellyCount++;
                        break;
                    }
                case BonusTimeType.N:
                    {
                        BonusJelly = 2;
                        p.BonusJellyCount++;
                        break;
                    }
                case BonusTimeType.U:
                    {
                        BonusJelly = 3;
                        p.BonusJellyCount++;
                        break;
                    }
                case BonusTimeType.S:
                    {
                        BonusJelly = 4;
                        p.BonusJellyCount++;
                        break;
                    }
                case BonusTimeType.T:
                    {
                        BonusJelly = 5;
                        p.BonusJellyCount++;
                        break;
                    }
                case BonusTimeType.I:
                    {
                        BonusJelly = 6;
                        p.BonusJellyCount++;
                        break;
                    }
                case BonusTimeType.M:
                    {
                        BonusJelly = 7;
                        p.BonusJellyCount++;
                        break;
                    }
                case BonusTimeType.E:
                    {
                        BonusJelly = 8;
                        p.BonusJellyCount++;
                        break;
                    }

                default:
                    {
                        return;
                    }

            }

            BonusAlphaBetCount[BonusJelly] = true;    

            GameObject.Find("InGameUI").transform.GetChild(2).transform.GetChild(BonusJelly).GetComponent<Image>().color = new Color(1, 1, 1, 1);
            GameObject.Find("InGameUI").transform.GetChild(2).transform.GetChild(BonusJelly).GetComponent<Image>().sprite = sprite;

            int resultBonusCount = 0;
            for(int i=0;i< BonusAlphaBetCount.Length; i++)
            {
                if (BonusAlphaBetCount[i] == true)
                    resultBonusCount += 1;
            }

            if(resultBonusCount == 9)
            {
                p.DestrtoyObject();  

                StartCoroutine(COWaitForAlphaBet(p.topTime + p.downTime));
                StartCoroutine(COWaitForBonusTime(p.topTime + p.downTime));        
                p.isBonusTime = true; // 바로 플레이어 애니메이션 실행  

                //BGM재생
                AudioClip bgmAudioClip = GameManager.Instance.LoadAudioClip(bgmAudioClipPath);
                if (bgmAudioClip != null)
                    SoundManager.Instance.Play(bgmAudioClip, Define.Sound.Bgm);

            }

            //if (p.BonusJellyCount >= 9)
            //{
            //    if (WhatAlpa == BonusTimeType.B ||
            //    WhatAlpa == BonusTimeType.O ||
            //    WhatAlpa == BonusTimeType.N ||
            //    WhatAlpa == BonusTimeType.U ||
            //    WhatAlpa == BonusTimeType.S ||
            //    WhatAlpa == BonusTimeType.T ||
            //    WhatAlpa == BonusTimeType.I ||
            //    WhatAlpa == BonusTimeType.M ||
            //    WhatAlpa == BonusTimeType.E)
            //    {
            //        //// 몬스터 삭제 
            //        GameObject[] Enemys = GameObject.FindGameObjectsWithTag("Enemy");
            //        foreach (GameObject enemy in Enemys)
            //        {
            //            Destroy(enemy);
            //        }

            //        StartCoroutine(COWaitForAlphaBet(p.topTime + p.downTime));
            //        StartCoroutine(COWaitForBonusTime(p.topTime + p.downTime));
            //        p.isBonusTime = true; // 바로 플레이어 애니메이션 실행  
            //    }
            //}


            //BGM재생
            //AudioClip bgmAudioClip = GameManager.Instance.LoadAudioClip(bgmAudioClipPath);
            //if (bgmAudioClip != null)
            //    SoundManager.Instance.Play(bgmAudioClip, Define.Sound.Bgm);  

        }

    }

    IEnumerator COWaitForBonusTime(float time )
    {
        yield return new WaitForSeconds(time);
        p.gValue = 1;
        p.BonusJellyCount = 0;
        p.isBonusStart = true;

    }
    IEnumerator COWaitForAlphaBet(float time)
    {
        
        yield return new WaitForSeconds(time);       

        for (int i = 0; i < 9; i++)
        {
            GameObject.Find("InGameUI").transform.GetChild(2).transform.GetChild(i).GetComponent<Image>().color = new Color(0, 0, 0, 0.2f);       
        }
        p.isBonusTime = true; // 바로 플레이어 애니메이션 실행  
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;
using static Item;

public class PlayerBonusTimeCount : MonoBehaviour
{
    int BonusJelly;
    Player p;
    private void Start()
    {
        p = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Item") && collision.gameObject.GetComponent<GetItem>())
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


            }


            GameObject.Find("InGameUI").transform.GetChild(2).transform.GetChild(BonusJelly).GetComponent<Image>().color = new Color(1, 1, 1, 1);
            GameObject.Find("InGameUI").transform.GetChild(2).transform.GetChild(BonusJelly).GetComponent<Image>().sprite = sprite;


            if (p.BonusJellyCount >= 9)
            {
                if (WhatAlpa == BonusTimeType.B ||
                WhatAlpa == BonusTimeType.O ||
                WhatAlpa == BonusTimeType.N ||
                WhatAlpa == BonusTimeType.U ||
                WhatAlpa == BonusTimeType.S ||
                WhatAlpa == BonusTimeType.T ||
                WhatAlpa == BonusTimeType.I ||
                WhatAlpa == BonusTimeType.M ||
                WhatAlpa == BonusTimeType.E)
                {

                    for (int i = 0; i < 9; i++)
                    {
                        GameObject.Find("InGameUI").transform.GetChild(2).transform.GetChild(i).GetComponent<Image>().color = new Color(0, 0, 0, 0.2f);
                    }
                    p.gValue = 1;
                    p.isBonusTime = true;
                    p.BonusJellyCount = 0;
                }
            }


        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Item;

public class PlayerBonusTimeCount : MonoBehaviour
{
    int BonusJelly;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var WhatAlpa = collision.gameObject.GetComponent<GetItem>().item.BonusTimeAlp;
        Sprite sprite = collision.gameObject.GetComponent<GetItem>().item.itemImage;
        
        switch(WhatAlpa)
        {
            case BonusTimeType.B:
                BonusJelly = 0;
                break;
            case BonusTimeType.O:
                BonusJelly = 1;
                break;
            case BonusTimeType.N:
                BonusJelly = 2;
                break;
            case BonusTimeType.U:
                BonusJelly = 3;
                break;
            case BonusTimeType.S:
                BonusJelly = 4;
                break;
            case BonusTimeType.T:
                BonusJelly = 5;
                break;
            case BonusTimeType.I:
                BonusJelly = 6;
                break;
            case BonusTimeType.M:
                BonusJelly = 7;
                break;
            case BonusTimeType.E:
                BonusJelly = 8;
                break;

        }
       

        GameObject.Find("Canvas").transform.GetChild(BonusJelly).GetComponent<Image>().sprite = sprite;
        GameObject.Find("Canvas").transform.GetChild(BonusJelly).GetComponent<Image>().color = new Color(1,1,1,1) ;


    }
}

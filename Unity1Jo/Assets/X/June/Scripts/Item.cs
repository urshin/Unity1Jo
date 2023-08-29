using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "New Item/item")]
public class Item : ScriptableObject  // 게임 오브젝트에 붙일 필요 X 
{
    public Dictionary<int, string> BonusItemJelly = new Dictionary<int, string>()
  {
        {0,"B"},
        {1,"O"},
        {2,"N"},
        {3,"U"},
        {4,"S"},
        {5,"T"},
        {6,"I"},
        {7,"M"},
        {8,"E"},
       
    };



public enum BonusTimeType  // 아이템 유형
    {
        B,
        O,
        N,
        U,
        S,
        T,
        I,
        M,
        E,
        Jelly,
        Coin,
        Dash,
        Gigantic,
        Magnet,
        Heal,

      
    }

    public string itemName; // 아이템의 이름
    public BonusTimeType ItemType; // 아이템 유형
    public Sprite itemImage; // 아이템의 이미지(인벤 토리 안에서 띄울)
    public GameObject itemPrefab;  // 아이템의 프리팹 (아이템 생성시 프리팹으로 찍어냄)


}

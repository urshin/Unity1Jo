using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    Player p;
    private void Start()
    {
        p = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }



    [SerializeField] private float CoinPoint;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            GameManager.Instance.totalCoin += CoinPoint; //GameManager의 coin변수에 각 코인 값 만큼 증가
            GameManager.Instance.currentCoin += CoinPoint; //InGame에서 쌓이는 coin점수
            Destroy(gameObject); //삭제
        }
    }
    void Update()
    {
       
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}

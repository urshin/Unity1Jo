using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gigantic : MonoBehaviour
{
    GameObject player;
    private void OnTriggerEnter2D(Collider2D collision) //플레이어와 닿았을 때
    {
        if (collision.gameObject.CompareTag("Player")) //플레이어의 태그가 있을 때
        {
            player = collision.gameObject; //게임오브젝트에 닿은 상대 게임오브젝트 대입
            player.GetComponent<SpriteRenderer>().enabled = false; //플레이어의 이미지 끄기
            player.transform.localScale = new Vector3(3, 3, 0); //플레이어의 로컬스케일값 3 증가
        }
        Invoke("goingToOrigin", 3); //3초 뒤 원래대로 돌아가는 함수 실행
    }


    void goingToOrigin() //원래대로 돌아가는 함수
    {
        player.transform.localScale = new Vector3(-3, 3, 0);//플레이어의 로컬스케일 3 감소

        Destroy(gameObject);//게임 오브젝트 삭제
    }
}

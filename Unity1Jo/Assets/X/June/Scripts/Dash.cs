using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
   
    public GameObject[] Ground;//배경 및 Ground 배열로 가져오기

    private void OnTriggerEnter2D(Collider2D collision) //trigger로 닿았을 때
    {
        if (collision.gameObject.CompareTag("Player")) //플레이어라면
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false; //아이템 이미지 끄기
            //for(int i = 0; i < Ground.Length; i++) //배열 크기 만큼 반복
            //{
            //Ground[i].GetComponent<GroundScroll>().ScrollSpeed *= 3; //모든 배열의 속도 3 증가

            //}
            GameManager.Instance.GroundScrollSpeed *= 3;
            Invoke("goingToOrigin", 3); //3초뒤 원상복구 시키기
        }
    }
    void Update()
    {
        transform.position += new Vector3(-GameManager.Instance.GroundScrollSpeed * Time.deltaTime, 0, 0);
    }

    void goingToOrigin() //원상복구 시키는 함수
    {
        //for (int i = 0; i < Ground.Length; i++)
        //{
        //    Ground[i].GetComponent<GroundScroll>().ScrollSpeed /= 3; //모든 배열의 속도 3배 감소

        //}
        GameManager.Instance.GroundScrollSpeed /= 3;
        Destroy(gameObject); //삭제시키기
    }
}

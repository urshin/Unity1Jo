using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gigantic : MonoBehaviour
{
    GameObject player;
    public float Size;

    private void Start()
    {
        Size *= 10;
    }
    private void OnTriggerEnter2D(Collider2D collision) //플레이어와 닿았을 때
    {
        if (collision.gameObject.CompareTag("Player")) //플레이어의 태그가 있을 때
        {
            player = GameObject.FindGameObjectWithTag("Player"); //게임오브젝트에 닿은 상대 게임오브젝트 대입
            gameObject.GetComponent<SpriteRenderer>().enabled = false; //플레이어의 이미지 끄기
            player.transform.position += new Vector3(0, Size/10, 0);// 포지션 값 움직이기
            
            for(int i = 0; i < Size;i++) //정한 사이즈 만큼 커짐
            {
                StartCoroutine(SizeUp());
            }
        }
        Invoke("goingToOrigin", 3); //3초 뒤 원래대로 돌아가는 함수 실행
    }

    void Update()
    {
        transform.position += new Vector3(-GameManager.Instance.GroundScrollSpeed * Time.deltaTime, 0, 0);
    }

    void goingToOrigin() //원래대로 돌아가는 함수
    {
        player.transform.position -= new Vector3(0, Size / 9, 0);

        for (int i = 0; i < Size; i++)
        {
            StartCoroutine(SizeDown());
        }
        Destroy(gameObject);//게임 오브젝트 삭제
    }


    IEnumerator SizeUp()
    {
        player.transform.localScale += new Vector3(0.1f, 0.1f, 0); //플레이어의 로컬스케일값 3 증가

        yield return new WaitForSeconds(0.1f);
    }

    IEnumerator SizeDown()
    {
        player.transform.localScale -= new Vector3(0.1f, 0.1f, 0); //플레이어의 로컬스케일값 3 증가

        yield return new WaitForSeconds(0.1f);
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}

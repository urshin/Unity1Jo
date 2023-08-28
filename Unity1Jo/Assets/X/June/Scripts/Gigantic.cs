using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gigantic : MonoBehaviour
{
    GameObject player;
    public float Size;

    private bool isTriggerEneter;

    Player p;
    private void Start()
    {
        p = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        Size = p.GiganticSize; //게임메니저에서 설정 가능하게 함
    }

    //private void Start()
    //{
    //    Size = p.GiganticSize; //게임메니저에서 설정 가능하게 함
    //}
    private void OnTriggerEnter2D(Collider2D collision) //플레이어와 닿았을 때
    {
        if (collision.gameObject.CompareTag("Player")) //플레이어의 태그가 있을 때
        {
            player = GameObject.FindGameObjectWithTag("Player"); //게임오브젝트에 닿은 상대 게임오브젝트 대입
            gameObject.GetComponent<SpriteRenderer>().enabled = false; //플레이어의 이미지 끄기
            p.GiganticDuration = p.GiganticTime; //아이템 지속 시간 초기화

            if (!p.isGigantic) //거대화 상태가 아닐 때
            {
                player.transform.position += new Vector3(0, Size / 10, 0);// 포지션 값 움직이기
                for (int i = 0; i < Size; i++) //정한 사이즈 만큼 커짐
                {
                    StartCoroutine(SizeUp()); //사이즈 업 하기
                }

            }
            p.isGigantic = true;
            transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);//자식으로 있는 거대화 문구 값 설정

            isTriggerEneter = true; 
            Invoke("DestroySelf", 5); //5초 뒤 본인 삭제
        }
    }

    void FixedUpdate()
    {
        transform.position += new Vector3(-p.GroundScrollSpeed * Time.deltaTime, 0, 0);



        if (isTriggerEneter) //충돌 된다면 자식객체로 있는 거대화 문구 출력하게 하기
        {
            transform.GetChild(0).GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, 3f * Time.deltaTime);
            StartCoroutine(ShowText());

        }
        if (p.GiganticDuration <= 0) //거대화 지속시간이 끝난다면
        {
            p.isGigantic = false;
            if (GameObject.FindGameObjectWithTag("Player").transform.localScale != p.OriginalSize) //원래의 크기와 현재 크기가 일치 하지 않는다면
            {
                StartCoroutine(SizeDown());

            }


        }
    }

    IEnumerator SizeDown()
    {
        GameObject.FindGameObjectWithTag("Player").transform.localScale -= new Vector3(0.1f, 0.1f, 0); //플레이어의 로컬스케일값 감소

        yield return new WaitForSeconds(0.1f);
    }



    void DestroySelf() //원래대로 돌아가는 함수
    {
        Destroy(gameObject);//게임 오브젝트 삭제
    }


    IEnumerator SizeUp()
    {
        player.transform.localScale += new Vector3(0.1f, 0.1f, 0); //플레이어의 로컬스케일값 3 증가

        yield return new WaitForSeconds(0.1f);
    }


    IEnumerator ShowText() //자식 객체로 있는 문구 보여주기
    {
        transform.GetChild(0).transform.position += new Vector3(Time.deltaTime, 0, 0); 
        yield return new WaitForSeconds(0.2f);
    }
}

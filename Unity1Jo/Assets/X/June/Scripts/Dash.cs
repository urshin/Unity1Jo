using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;
using UnityEngine.UI;

public class Dash : MonoBehaviour
{

    public GameObject[] Ground;//배경 및 Ground 배열로 가져오기

    private bool isTriggerEneter;



    Player p;
    private void Start()
    {
        p = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision) //trigger로 닿았을 때
    {
        if (collision.gameObject.CompareTag("Player")) //플레이어라면
        {
            p.DashDuration = p.DashTime;//대쉬 지속시간 초기화

            gameObject.GetComponent<SpriteRenderer>().enabled = false; //아이템 이미지 끄기

            p.isDashing = true;
            if (p.DashDuration > 0) //대쉬 지속시간이 남아있다면.
            {
                p.GroundScrollSpeed = p.OriginalGroundScrollSpeed * 3; //원래 속도에서 3배 빠르게한 값을 넣어줌

            }
            transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0); //자식객체로 있는 문구 설정

            isTriggerEneter = true;


            Invoke("DestroySelf", 5); //5초뒤 본인 삭제
        }
    }
    void Update()
    {


        if (p.isMagnet)
        {
            transform.position = Vector3.MoveTowards(transform.position, p.gameObject.transform.position - new Vector3(0, 2, 0), p.MagnetSpeed);
        }
        else
            transform.position += new Vector3(-p.GroundScrollSpeed * Time.deltaTime, 0, 0);
        if (isTriggerEneter)  //문구 보여주기
        {
            transform.GetChild(0).GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, 3f * Time.deltaTime);
            StartCoroutine(ShowText());

        }
        if (p.DashDuration <= 0)
        {
            p.GroundScrollSpeed = p.OriginalGroundScrollSpeed;
            p.isDashing = false;
        }



    }

    void DestroySelf() 
    {
        Destroy(gameObject); //삭제시키기
    }

    IEnumerator ShowText()
    {
        transform.GetChild(0).transform.position += new Vector3(Time.deltaTime, 0, 0);
        yield return new WaitForSeconds(0.2f);
    }

}

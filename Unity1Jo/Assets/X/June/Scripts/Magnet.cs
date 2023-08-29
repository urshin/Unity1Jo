using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{

    Player p;

    private bool isTriggerEneter;

    private void Start()
    {
        p = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            p.isMagnet = true;
            p.MagnetDuration = p.MagnetTime;
            isTriggerEneter = true;
            gameObject.GetComponent<SpriteRenderer>().enabled = false; //아이템 이미지 끄기
            
            transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);//자식으로 있는 거대화 문구 값 설정


            Invoke("SelfDestroy", 10); //5초뒤 본인 삭제

        }
    }
    void Update()
    {
       
        if (p.MagnetDuration < 0)
        {
            p.isMagnet = false;
        }

        if (isTriggerEneter) //충돌 된다면 자식객체로 있는 자석 문구 출력하게 하기
        {
            transform.GetChild(0).GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, 3f * Time.deltaTime);
            StartCoroutine(ShowText());

        }
    }



    private void SelfDestroy()
    {
      
        Destroy(gameObject); //삭제시키기
    }
    IEnumerator ShowText() //자식 객체로 있는 문구 보여주기
    {
        transform.GetChild(0).transform.position -= new Vector3(Time.deltaTime, 0, 0);
        yield return new WaitForSeconds(0.2f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gigantic : MonoBehaviour
{
    GameObject player;
    public float Size;
    public GameObject txt;
    private bool isTriggerEneter;

    Player p;

    //사운드
    [SerializeField] string effectAudioClipPath = "SoundEff_GetItemJelly";
    [SerializeField] string effectAudioClipPath1 = "E_Gigantic";
    [SerializeField] string effectAudioClipPath2 = "E_BacktoOriginScale";
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
            AudioClip effectAudioClip = GameManager.Instance.LoadAudioClip(effectAudioClipPath);
            if (effectAudioClip != null)
                SoundManager.Instance.Play(effectAudioClip, Define.Sound.IngameEffect);

            player = GameObject.FindGameObjectWithTag("Player"); //게임오브젝트에 닿은 상대 게임오브젝트 대입
            gameObject.GetComponent<SpriteRenderer>().enabled = false; //플레이어의 이미지 끄기
            p.GiganticDuration = p.GiganticTime; //아이템 지속 시간 초기화

            if (!p.isGigantic) //거대화 상태가 아닐 때
            {
                player.transform.position += new Vector3(0, Size / 10, 0);// 포지션 값 움직이기
                for (int i = 0; i < Size; i++) //정한 사이즈 만큼 커짐
                {
                    StartCoroutine(SizeUp()); //사이즈 업 하기

                    AudioClip effectAudioClip1 = GameManager.Instance.LoadAudioClip(effectAudioClipPath1);
                    if (effectAudioClip1 != null)
                    {
                        Debug.Log("커지는 사운드");
                        SoundManager.Instance.Play(effectAudioClip1, Define.Sound.GiganticEffect);
                    }
                }

            }
            p.isGigantic = true;

            isTriggerEneter = true;
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            Invoke("DestroySelf", 6); //5초 뒤 본인 삭제
        }
    }

    void FixedUpdate()
    {

        if (!p.isGigantic) //거대화 지속시간이 끝난다면
        {
           
            if (GameObject.FindGameObjectWithTag("Player").transform.localScale.y > p.OriginalSize.y) //원래의 크기와 현재 크기가 일치 하지 않는다면
            {
                StartCoroutine(SizeDown());

                AudioClip effectAudioClip1 = GameManager.Instance.LoadAudioClip(effectAudioClipPath2);
                if (effectAudioClip1 != null)
                {
                    Debug.Log("작아지는 사운드");
                    SoundManager.Instance.Play(effectAudioClip1, Define.Sound.GiganticEffect);
                }
            }
        }
        if (isTriggerEneter)
        {
            Instantiate(txt, p.transform.position + new Vector3(0, 1, 0), Quaternion.identity);
            isTriggerEneter = false;
        }
    }
    void DestroyChild()
    {
        Destroy(transform.GetChild(0));
    }
    IEnumerator SizeDown()
    {
        GameObject.FindGameObjectWithTag("Player").transform.localScale -= new Vector3(0.1f, 0.1f, 0); //플레이어의 로컬스케일값 감소

        yield return new WaitForSeconds(0.1f);
    }


    private void OnBecameInvisible()
    {
        isTriggerEneter = false;
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
}

using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class Dash : MonoBehaviour
{

    public GameObject[] Ground;//배경 및 Ground 배열로 가져오기

    private bool isTriggerEneter;

    public GameObject txt;

    Player p;

    [SerializeField] string effectAudioClipPath = "SoundEff_GetItemJelly";
    private void Start()
    {
        p = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision) //trigger로 닿았을 때
    {
        if (collision.gameObject.CompareTag("Player")) //플레이어라면
        {
            AudioClip effectAudioClip = GameManager.Instance.LoadAudioClip(effectAudioClipPath);
            if (effectAudioClip != null)
                SoundManager.Instance.Play(effectAudioClip, Define.Sound.IngameEffect);

            p.DashDuration = p.DashTime;//대쉬 지속시간 초기화

            gameObject.GetComponent<SpriteRenderer>().enabled = false; //아이템 이미지 끄기


            p.isDashing = true;
            if (p.DashDuration > 0) //대쉬 지속시간이 남아있다면.
            {
                p.GroundScrollSpeed = p.OriginalGroundScrollSpeed * 3; //원래 속도에서 3배 빠르게한 값을 넣어줌

            }

            isTriggerEneter = true;

            gameObject.GetComponent<CircleCollider2D>().enabled = false;

            Invoke("DestroySelf", 5); //5초뒤 본인 삭제
        }
    }
    void Update()
    {

        if (p.DashDuration <= 0)
        {
            p.GroundScrollSpeed = p.OriginalGroundScrollSpeed;
            p.isDashing = false;
        }

        if (isTriggerEneter)
        {
            Instantiate(txt, p.transform.position + new Vector3(0, 1, 0), Quaternion.identity);
            isTriggerEneter = false;
        }

    }
    private void OnBecameInvisible()
    {
        isTriggerEneter = false;
    }

    void DestroyChild()
    {
        Destroy(transform.GetChild(0));
    }
    void DestroySelf()
    {
        Destroy(gameObject); //삭제시키기
    }

  

}

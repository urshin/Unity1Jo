using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{

    Player p;

    private bool isTriggerEneter;
    public GameObject txt;
    [SerializeField] string effectAudioClipPath = "SoundEff_GetItemJelly";

    private void Start()
    {
        p = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AudioClip effectAudioClip = GameManager.Instance.LoadAudioClip(effectAudioClipPath);
            if (effectAudioClip != null)
                SoundManager.Instance.Play(effectAudioClip, Define.Sound.IngameEffect);

            p.MagnetDuration = p.MagnetTime;
            p.isMagnet = true;
            isTriggerEneter = true;
            gameObject.GetComponent<SpriteRenderer>().enabled = false; //아이템 이미지 끄기

            gameObject.GetComponent<CircleCollider2D>().enabled = false;

            Invoke("SelfDestroy", 10); //5초뒤 본인 삭제

        }
    }

    void Update()
    {
        if(isTriggerEneter)
        {
            Instantiate(txt, p.transform.position + new Vector3(0,1,0), Quaternion.identity);
            isTriggerEneter = false;
        }
        
    }
    void DestroyChild()
    {
        Destroy(transform.GetChild(0));
    }


    private void SelfDestroy()
    {

        Destroy(gameObject); //삭제시키기
    }
    
}

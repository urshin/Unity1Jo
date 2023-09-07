using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jelly : MonoBehaviour
{
    [SerializeField] private float JellyPoint;
    [SerializeField] string effectAudioClipPath = "SoundEff_GetJelly";

    private void Start()
    {
        p = GameObject.FindGameObjectWithTag("Player")?.GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.currentJellyPoint += JellyPoint; //GameManager에 있는 젤리 점수 증가
                                                                  //SoundManager.Instance.PlaySound("jelly");

            //Effect재생
            AudioClip effectAudioClip = GameManager.Instance.LoadAudioClip(effectAudioClipPath);
            if (effectAudioClip != null)
                SoundManager.Instance.Play(effectAudioClip, Define.Sound.IngameEffect);

            Destroy(gameObject); //삭제시키기  

        }

        if (collision.gameObject.CompareTag("Jelly") || collision.gameObject.CompareTag("Item") 
            || collision.gameObject.CompareTag("SpawnGround") || collision.gameObject.CompareTag("Enemy")
            || collision.gameObject.CompareTag("Coin"))
        {
            Destroy(gameObject); //삭제시키기      


        }
    }
    Player p;

    void Update()
    {

    }
    
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}

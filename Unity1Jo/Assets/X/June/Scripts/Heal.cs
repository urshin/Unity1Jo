using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{

    [SerializeField] float HowMuchHeal;
    [SerializeField] string effectAudioClipPath = "SoundEff_Small_Energy";

    Player p;
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
                SoundManager.Instance.Play(effectAudioClip, Define.Sound.Effect);

            p.AddHP(HowMuchHeal);
            Destroy(gameObject); //삭제시키기

        }
    }
    void Update()
    {
       
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}

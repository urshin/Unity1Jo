using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jelly : MonoBehaviour
{
    [SerializeField] private float JellyPoint;

    private AudioSource audioSource;
    private void Start()
    {
        p = GameObject.FindGameObjectWithTag("Player")?.GetComponent<Player>();
        //if (gameObject.GetComponent<AudioSource>() != null)
        //{

        //    audioSource = GetComponent<AudioSource>();
        //}


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.currentJellyPoint += JellyPoint; //GameManager에 있는 젤리 점수 증가
                                                                  //SoundManager.Instance.PlaySound("jelly");

            //if (gameObject.GetComponent<AudioSource>() != null)
            //{
            //    audioSource.Play();
            //}
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jelly : MonoBehaviour
{
    [SerializeField] private float JellyPoint;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.JellyPoint += JellyPoint; //GameManager에 있는 젤리 점수 증가
            Destroy(gameObject); //삭제시키기

        }
    }
    Player p;
    private void Start()
    {
        p = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void Update()
    {
        if (p.isMagnet)
        {
            transform.position = Vector3.MoveTowards(transform.position, p.gameObject.transform.position - new Vector3(0, 2, 0), p.MagnetSpeed);
        }
        else
            transform.position += new Vector3(-p.GroundScrollSpeed * Time.deltaTime, 0, 0);
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}

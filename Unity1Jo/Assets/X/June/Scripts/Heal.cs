using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{

    [SerializeField] float HowMuchHeal;

    Player p;
    private void Start()
    {
        p = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            p.HealHP(HowMuchHeal);
            Destroy(gameObject); //삭제시키기

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
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}

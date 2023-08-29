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
       
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}

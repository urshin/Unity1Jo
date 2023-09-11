using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Player p;
    Transform obj;

    bool IsTriggerWithPlayer;
    private void Start()
    {
        p = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        //obj = transform.GetChild(0);
      

    }

    void Update()
    {
        
        transform.position += new Vector3(-p.GroundScrollSpeed * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
       
    }


    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}

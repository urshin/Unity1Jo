using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    Animator anim;
    Player p;

    private void Start()
    {
        p = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        anim = GetComponentInChildren<Animator>(); // ?inchildren

    }

    void Update()
    {
        transform.position += new Vector3(-p.GroundScrollSpeed * Time.deltaTime, 0, 0);

        if (p.mapcount == 1 && p.isMapChange)
        {
            anim.Play("B_Long_Enemy");
        }
        else if (p.mapcount == 2 && p.isMapChange)
        {
            anim.Play("y_Long_Enemy");
        }
        else if (p.mapcount == 3 && p.isMapChange)
        {

        }
    }




    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}

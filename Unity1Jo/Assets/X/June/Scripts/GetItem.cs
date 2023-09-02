using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItem : MonoBehaviour
{
    public Item item;


    Player p;
    private void Start()
    {
        p = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();    
    }

    public void FixedUpdate()
    {
        if (p.isMagnet && transform.position.x < 0)
        {

            transform.position = Vector3.MoveTowards(transform.position, p.gameObject.transform.position - new Vector3(0, 2, 0), p.MagnetSpeed);
        }
        else
            transform.position += new Vector3(-p.GroundScrollSpeed * Time.deltaTime, 0, 0);
    }

   

}
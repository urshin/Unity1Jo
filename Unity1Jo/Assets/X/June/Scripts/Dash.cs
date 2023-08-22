using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public GameObject Map;
    public GameObject[] Ground;



    private void Start()
    {
        
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            for(int i = 0; i < Ground.Length; i++)
            {
            Ground[i].GetComponent<GroundScroll>().ScrollSpeed *= 3;

            }
            Invoke("goingToOrigin", 3);
        }
    }

    void goingToOrigin()
    {
        for (int i = 0; i < Ground.Length; i++)
        {
            Ground[i].GetComponent<GroundScroll>().ScrollSpeed /= 3;

        }
        Destroy(gameObject);
    }
}

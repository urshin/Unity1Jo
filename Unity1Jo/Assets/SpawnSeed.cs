using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSeed : MonoBehaviour
{
    public GameObject Seed;
    private void Start()
    {
        p = GameObject.FindGameObjectWithTag("Player")?.GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            for (float i = -4; i < 5; i++)
            {
                for (float j = -4; j < 5; j++)
                {

                    Instantiate(Seed, transform.position + new Vector3(i/3, j/3, 0), Quaternion.identity);
                }
            }

        }
    }
    Player p;

}

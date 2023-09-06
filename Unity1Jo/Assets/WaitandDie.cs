using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitandDie : MonoBehaviour
{
    public float ScrollSpeed = 3f;


    [SerializeField] float posValue;

    Vector2 startPos;
    float newPos;
    Player p;
    private void Start()
    {
        p = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }


    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-p.GroundScrollSpeed * Time.deltaTime, 0, 0);
        
    }

    private void OnBecameInvisible()
    {
       Destroy(gameObject);
    }
}

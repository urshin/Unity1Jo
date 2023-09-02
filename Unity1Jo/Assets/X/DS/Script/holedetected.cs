using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class holedetected : MonoBehaviour
{
    private bool isHole = true; 
    private float isHoleDuration = 3f;
    BoxCollider2D box;

    void Start()
    {
         box = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isHole)
        {
            Invoke("EndHole", isHoleDuration);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && isHole)
        {
            isHole = !isHole;
            box.isTrigger = false;
        }
    }

    private void EndHole()
    {
        box.isTrigger = true;
        isHole = true;
    }

}

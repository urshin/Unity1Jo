using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TxtEffect : MonoBehaviour
{
    Player p;
    private void Start()
    {
        p = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    private void Update()
    {
        gameObject.GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, 3f * Time.deltaTime);
        transform.position += new Vector3(-p.GroundScrollSpeed * Time.deltaTime, 0, 0);
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}

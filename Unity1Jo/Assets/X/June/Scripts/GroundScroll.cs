using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScroll : MonoBehaviour
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
        if(transform.position.x < -18)
        {
            transform.position += new Vector3(54, 0, 0);
        }
    }

    private void OnBecameInvisible()
    {
        //무한 맵을 위한 자기 자신 위치에서 다음 배경 옆으로 이동 (한 배경에 x = 18)
        //transform.position += new Vector3(54, 0, 0);
    }
}

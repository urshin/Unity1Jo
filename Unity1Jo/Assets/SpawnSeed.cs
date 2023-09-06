using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSeed : MonoBehaviour
{

    int numberOfObjects = 10; // 생성할 게임 오브젝트의 수
    float radius = 1f; // 원의 반지름
    public float delay = 0.2f; // 생성 딜레이 시간 (초)
    public GameObject Seed;
    private void Start()
    {
        p = GameObject.FindGameObjectWithTag("Player")?.GetComponent<Player>();
        Invoke("CreateObjects", delay);
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        for (float i = -4; i < 5; i++)
    //        {
    //            for (float j = -4; j < 5; j++)
    //            {

    //                Instantiate(Seed, transform.position + new Vector3(i/3, j/3, 0), Quaternion.identity);
    //            }
    //        }

    //    }
    //}
    Player p;





    private void CreateObjects()
    {

        for (int j = 0; j < 3; j++)
        {
            for (int i = 0; i < numberOfObjects; i++)
            {
                // 원 모양으로 배치하기 위한 각도 계산
                float angle = i * (360f / numberOfObjects);
                float radians = angle * Mathf.Deg2Rad;

                // 원의 중심에서의 위치 계산
                float x = Mathf.Cos(radians) * radius;
                float y = Mathf.Sin(radians) * radius;

                // 게임 오브젝트 생성
                Vector3 spawnPosition = transform.position + new Vector3(x, y, 0);
                Instantiate(Seed, spawnPosition, Quaternion.identity);
            }
            radius += 0.3f;
        }
    }
}

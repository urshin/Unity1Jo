using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jelly : MonoBehaviour
{
    [SerializeField] private float JellyPoint;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.JellyPoint += JellyPoint; //GameManager�� �ִ� ���� ���� ����
            Destroy(gameObject); //������Ű��

        }
    }
}
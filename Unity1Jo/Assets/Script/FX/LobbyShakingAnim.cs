using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyShakingAnim : MonoBehaviour //code by.하은
{
    public float swingSpeed = 1.0f; // 흔들리는 속도 조절
    public float swingAmount = 1.0f; // 흔들리는 범위 조절

    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        // Sin 함수를 사용하여 좌우로 흔들리는 움직임을 생성
        float xOffset = Mathf.Sin(Time.time * swingSpeed) * swingAmount;

        // 초기 위치를 기준으로 좌우로 이동
        transform.position = initialPosition + new Vector3(xOffset, 0f, 0f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moonlight_FX_Stars : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 60; //초당 회전 각도

    void Update()
    {
        transform.RotateAround(transform.parent.position, Vector3.forward, rotationSpeed*Time.deltaTime);
    }
}

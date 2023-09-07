using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PathType
{
    Cos,
    Sin,
}
public class SkillTest : MonoBehaviour
{
    [SerializeField] [Header("이동거리")] [Range(1, 9f)] float dist = 7f;
    [SerializeField] [Header("이동 속도")] [Range(1, 50f)] float speed = 3f;
    [SerializeField] [Header("파동 빈도")] [Range(1, 40f)] float frequency = 10f;
    [SerializeField] [Header("파동 높이 ")] [Range(1, 40f)] float waveHeight = 1f;  


    Vector3 pos;
    float parentX;
    PathType pathType = PathType.Sin;

    private void Start()
    {
        pos = transform.position;
    }

    private void FixedUpdate()
    {
        if (transform.localPosition.x  < (dist + parentX))
            GoRight();  

        if (transform.localPosition.x >= (dist + parentX))
            GoVibraion(); 
    }

    //Setter
    public void SetDist(float d)
    {
        dist = d;
    }
    public void SetHeight(float h)
    {
        waveHeight = h;
    }
    public void SetSpeed(float s)
    {
        speed = s;
    }
    public void SetFrequency(float f)
    {
        frequency = f;
    }

    void GoRight()
    {
        pos += transform.right * Time.deltaTime * speed;
        if(pathType == PathType.Sin)
        {
            transform.localPosition = pos + transform.up * Mathf.Sin(Time.time * frequency) * waveHeight;
        }
        else
        {
            transform.localPosition = pos + transform.up * Mathf.Sin(-Time.time * frequency) * waveHeight;

        }
    }
    void GoVibraion()
    {
        if(pathType == PathType.Sin)
        {
            transform.localPosition = pos + transform.up * Mathf.Sin(Time.time * frequency) * waveHeight;

        }
        else
        {
            transform.localPosition = pos + transform.up * Mathf.Sin(-Time.time * frequency) * waveHeight;  

        }
    } 


    public void SetParentPosX(float x)
    {
        parentX = x;
    }
    public void SetPathType(PathType type)
    {
        pathType = type;
    }
}

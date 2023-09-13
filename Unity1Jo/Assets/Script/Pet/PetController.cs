using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetController : MonoBehaviour
{
    public Transform target; // 따라갈 타겟의 트랜스 폼

    //private float relativeHeigth = 1.0f; // 높이 즉 y값
    //private float zDistance = -1.0f;// z값 나는 사실 필요 없었다.
    //private float xDistance = 1.0f; // x값
    [SerializeField] float _speed = 8f;  // 따라가는 속도 짧으면 타겟과 같이 움직인다.    

    void Start()
    {

    }

    void Update()   
    {
        //Vector3 newPos = target.position + new Vector3(xDistance, relativeHeigth, -zDistance); // 타겟 포지선에 해당 위치를 더해.. 즉 타겟 주변에 위치할 위치를 담는다.. 일정의 거리를 구하는 방법
        Vector3 newPos = target.position ; 
        //transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * dampSpeed); //그 둘 사이의 값을 더해 보정한다. 이렇게 되면 멀어지면 따라간다.    
        //transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * dampSpeed); //그 둘 사이의 값을 더해 보정한다. 이렇게 되면 멀어지면 따라간다.    

        transform.position = Vector3.MoveTowards(transform.position, newPos, _speed * Time.deltaTime);  

    }

    public void SetSpeed(float speed)
    {
        _speed = speed;
    }  
}

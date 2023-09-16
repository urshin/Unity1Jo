using DG.Tweening;
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

    [SerializeField] bool isUpdownMoving = true;
    [SerializeField] GameObject centerMagnetPos;  

    void Start()
    {
        //StartCoroutine("CoroutineName");
        //Invoke("CoroutineStop", 3); 
    }

    void Update()   
    {
        if (isUpdownMoving)
        {
            Vector3 newPos = target.position;
            transform.position = Vector3.MoveTowards(transform.position, newPos, _speed * Time.deltaTime);

        }
        
    }

    public void SetSpeed(float speed)
    {
        _speed = speed;
    }
    public void SetIsUpdownMoving(bool flag)
    {
        isUpdownMoving = flag;
    }
    public void MoveMangetCenterPos()
    {
        transform.DOMove(centerMagnetPos.transform.position, 2).OnComplete(  
            () => {
                MoveReset();  
            });   
    }

    void MoveReset()
    {
        //GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        //Transform petMiddlePos = playerObj.GetComponent<Player>().GetPetMiddlePos();

        //transform.DOMove(petMiddlePos.transform.position, 2).OnComplete(
        //    () => {
        //        isUpdownMoving = true;    
        //    });

        // TODO : 몇초간 멈추고 난 뒤 isUpdownMoving = true로 가야됨!    
        isUpdownMoving = true;  
    }

    //IEnumerator CoroutineName()
    //{
    //    int counter = 0;

    //    while (true)
    //    {
    //        Debug.Log(counter);
    //        counter++;
    //        yield return new WaitForSeconds(1);
    //    }
    //}
    //void CoroutineStop() //시작 후 3초뒤에 호출 될 함수
    //{
    //    Debug.Log("코루틴 종료");
    //    StopCoroutine("CoroutineName");
    //}

}

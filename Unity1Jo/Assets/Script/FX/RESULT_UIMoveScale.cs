using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RESULT_UIMoveScale : MonoBehaviour //code by.하은
{
    List<GameObject> gameObjList = new List<GameObject>();
    [SerializeField] GameObject TitleTxt;
    [SerializeField] GameObject Point;
    [SerializeField] GameObject Coin;
    [SerializeField] GameObject Dialogue;
    [SerializeField] GameObject OkBtn;
    [SerializeField] Transform Player;
    [SerializeField] float animationDuration = 0.1f; //커지는 애니메이션이 진행되는 시간
    [SerializeField] float delay = 0.2f; // 각 오브젝트에 대한 딜레이 시간
    public Vector3 targetScale = new Vector3(1, 1, 1);


    private void Awake()
    {
        gameObjList.Add(TitleTxt);
        gameObjList.Add(Point);
        gameObjList.Add(Coin);
        gameObjList.Add(Dialogue);
        gameObjList.Add(Player.gameObject);
        gameObjList.Add(OkBtn);
    }
    public void Start()
    {
            StartCoroutine(MoveScaleBigger());
    }

    private IEnumerator MoveScaleBigger()  
    {
        WaitForSeconds seconds = new WaitForSeconds(delay);
        
        for(int i=0;i< gameObjList.Count; i++)
        {
            if (gameObjList[i] == null)
                continue;

            if (gameObjList[i].CompareTag("Player")) 
            {
                Vector3 changeScale = new Vector3(2.2f, 2.2f, 1f);
                gameObjList[i].transform.DOScale(changeScale, 0.3f);
            }
            else
            {
                gameObjList[i].GetComponent<RectTransform>().DOScale(targetScale, animationDuration);
            }
            yield return seconds;
        }
    }
}

using DG.Tweening;
using System.Collections;
using UnityEngine;

public class UIMoveScale : MonoBehaviour //code by.하은
{
    [SerializeField] GameObject TitleTxt;
    [SerializeField] GameObject Point;
    [SerializeField] GameObject Coin;
    [SerializeField] GameObject Dialogue;
    [SerializeField] GameObject OkBtn;
    [SerializeField] float animationDuration = 0.1f; //커지는 애니메이션이 진행되는 시간
    [SerializeField] float delay = 0.2f; // 각 오브젝트에 대한 딜레이 시간


    public void Start()
    {
        StartCoroutine(MoveScaleBigger());
    }

    private IEnumerator MoveScaleBigger()
    {
        if (TitleTxt != null)
        {
            //바꿀 스케일 
            Vector3 changeScale = new Vector3(1f, 1f, 1f);
            TitleTxt.GetComponent<RectTransform>().DOScale(changeScale, animationDuration);
        }

        yield return new WaitForSeconds(delay);

        if (Point != null)
        {
            Vector3 changeScale = new Vector3(1f, 1f, 1f);
            Point.GetComponent<RectTransform>().DOScale(changeScale, animationDuration);
        }

        yield return new WaitForSeconds(delay);

        if (Coin != null)
        {
            Vector3 changeScale = new Vector3(1f, 1f, 1f);
            Coin.GetComponent<RectTransform>().DOScale(changeScale, animationDuration);
        }

        yield return new WaitForSeconds(delay);

        if (Dialogue != null)
        {
            Vector3 changeScale = new Vector3(1f, 1f, 1f);
            Dialogue.GetComponent<RectTransform>().DOScale(changeScale, animationDuration);
        }

        yield return new WaitForSeconds(delay);

        if (OkBtn != null)
        {
            Vector3 changeScale = new Vector3(1f, 1f, 1f);
            OkBtn.GetComponent<RectTransform>().DOScale(changeScale, animationDuration);
        }
    }
}

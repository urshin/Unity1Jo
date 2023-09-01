using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UIMoveScale : MonoBehaviour
{
    [SerializeField] GameObject TitleTxt;
    [SerializeField] float animationDuration = 0.1f;

    public void Start()
    {
        MoveScaleBigger();
    }

    public void MoveScaleBigger()
    {
        if (TitleTxt != null)
        {
            // 시작 스케일 
            Vector3 startScale = new Vector3(1f, 1f, 1f);

            TitleTxt.GetComponent<RectTransform>().DOScale(startScale, animationDuration);
        }
    }
}

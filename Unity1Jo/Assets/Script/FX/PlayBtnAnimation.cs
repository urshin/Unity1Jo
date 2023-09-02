using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayBtnAnimation : MonoBehaviour //code by. 하은
{
    [SerializeField] Vector3 targetScale = new Vector3(1.1f, 1.1f, 1.1f); // 확대할 스케일 값
    [SerializeField] Vector3 originScale = new Vector3(1, 1, 1); 
    [SerializeField] float animationDuration = 0.4f;
    float delayTime = 0.5f;
    float repeatingTime = 2f;

    private void Start()
    {
        InvokeRepeating("StartScaleAnimation", delayTime, repeatingTime);
    }

    private void StartScaleAnimation()
    {
        GetComponent<RectTransform>().DOScale(targetScale, animationDuration).OnComplete(() => {
            GetComponent<RectTransform>().DOScale(originScale, animationDuration);
        });
    }
}

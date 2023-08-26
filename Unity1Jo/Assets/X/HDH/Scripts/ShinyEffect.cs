using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShinyEffect : MonoBehaviour
{
    [SerializeField] GameObject lights;

    // code by 동호
    public void StartRotateLightsEffect()
    {
        // 360도 계속 돌리기
        lights.transform.DORotate(new Vector3(0, 0, 360), 1.5f, RotateMode.FastBeyond360)  
                     .SetEase(Ease.Linear)
                     .SetLoops(-1);      
    }  



}

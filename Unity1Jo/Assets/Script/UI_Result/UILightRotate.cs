using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UILightRotate : MonoBehaviour //code by. 하은
{
    [SerializeField] GameObject Lights;

    public void RotateLightsEffect()
    {
        // 360도 계속 돌리기
        Lights.GetComponent<RectTransform>().DORotate(new Vector3(0, 0, 360), 1.5f, RotateMode.Fast)
                        .SetEase(Ease.Linear)
                        .SetLoops(-1);
    }
}

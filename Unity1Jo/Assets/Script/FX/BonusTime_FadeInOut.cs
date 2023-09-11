using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusTime_FadeInOut : MonoBehaviour
{
    // 싱글톤 대신 static 쓰기 위해, 이러한 방법 사용.

    // 인스펙터에서 수정할 값.
    [SerializeField] private Image blackBack; // 화면 꽉 채운 이미지 컴포넌트. (검은색.)
    [SerializeField] private float time = 2f;  

    // 실제 Static 메소드에서 사용할 값.
    static private Image BlackBack;
    static private float Time;

    static Sequence sequenceFadeInOut;

    private void Awake()
    {
        BlackBack = blackBack;
        Time = time;

        BlackBack.enabled = false;
        BlackBack.color = new Color(0, 0, 0, 0);     
    }

    private void Start()
    {
        // FadeInOut
        sequenceFadeInOut = DOTween.Sequence()
            .SetAutoKill(false) // DoTween Sequence는 기본적으로 일회용임. 재사용하려면 써주자.
            .OnRewind(() => // 실행 전. OnStart는 unity Start 함수가 불릴 때 호출됨. 낚이지 말자.
            {
                BlackBack.enabled = true;
            })
            .Append(BlackBack.DOFade(1.0f, 1).OnComplete(() => {

            })) // 어두워짐. 알파 값 조정.  
            .Append(BlackBack.DOFade(0.0f, 1)) // 밝아짐. 알파 값 조정.                  
            .OnComplete(() => // 실행 후.
            {
                BlackBack.enabled = false;  
            });
    }

    static public void Play(Define.Transition transition)
    {
        switch (transition)
        {
            case Define.Transition.Fade: FadeInOut(); break;
        }
    }

    static private void FadeInOut()
    {
        sequenceFadeInOut.Restart(); // Play()로 하면, 한번 밖에 실행 안 됨.
    }

}

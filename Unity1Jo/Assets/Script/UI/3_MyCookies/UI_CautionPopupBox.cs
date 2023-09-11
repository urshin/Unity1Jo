using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_CautionPopupBox : MonoBehaviour
{
    [SerializeField] GameObject CloseBtn;
    [SerializeField] string effectAudioClipPath = "E_ClickBtn";

    private void Awake()
    {
        CloseBtn.AddUIEvent(OnCloseBtnClicked);
    }

    void OnCloseBtnClicked(PointerEventData data)
    {
        Debug.Log("OnCloseBtnClicked");

        //EffectÀç»ý
        AudioClip effectAudioClip = GameManager.Instance.LoadAudioClip(effectAudioClipPath);
        if (effectAudioClip != null)
            SoundManager.Instance.Play(effectAudioClip, Define.Sound.Effect);

        gameObject.transform.parent.gameObject.SetActive(false);  
        Destroy(gameObject);
    }
}

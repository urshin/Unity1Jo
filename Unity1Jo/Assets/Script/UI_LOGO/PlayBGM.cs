using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBGM : MonoBehaviour
{
    [SerializeField] string effectAudioClipPath = "E_LOGO";
    void Start()
    {
        //BGMÀç»ý
        AudioClip bgmAudioClip = GameManager.Instance.LoadAudioClip(effectAudioClipPath);
        if (bgmAudioClip != null)
        {
            SoundManager.Instance.Play(bgmAudioClip, Define.Sound.Effect);
        }
    }
}

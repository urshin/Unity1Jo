using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScenetoMYPETS : MonoBehaviour
{
    [SerializeField] GameObject myPetsBtn;
    [SerializeField] string effectAudioClipPath = "E_ClickBtn";

    public void Awake()
    {
        myPetsBtn.GetComponent<Button>().onClick.AddListener(GotoMyPets);
    }

    public void GotoMyPets()
    {
        SceneManager.LoadScene("MYPETS");

        //EffectÀç»ý
        AudioClip effectAudioClip = GameManager.Instance.LoadAudioClip(effectAudioClipPath);
        if (effectAudioClip != null)
            SoundManager.Instance.Play(effectAudioClip, Define.Sound.Effect);
    }
}

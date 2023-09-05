using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SoundManager : SingletonBehaviour<SoundManager>
{
    [SerializeField] AudioSource[] _audioSources = new AudioSource[(int)Define.Sound.MaxCount];
    Dictionary<string, AudioClip> _audioClips = new Dictionary<string, AudioClip>();
    void Awake()
    {
        base.Awake();

    }

    private void Start()
    {

    }
    public void Clear() //DontDestroyOnLoad로 파괴되지 않게 되어있기 때문에 메모리 효율을 위해 Dictionary를 비워주는 함수 생성
    {
        //재생기 전부 재생 스탑, 음반 빼기
        foreach (AudioSource audioSource in _audioSources)
        {
            audioSource.clip = null;
            audioSource.Stop();
        }
        //효과음 Dictionary 비우기
        _audioClips.Clear();
    }

    public void Play(AudioClip audioClip, Define.Sound type = Define.Sound.Effect, float pitch = 1.0f)
    {
        if (audioClip == null)
            return;
        if(type == Define.Sound.Bgm) //BGM 재생
        {
            AudioSource audioSource = _audioSources[(int)Define.Sound.Bgm];
            if (audioSource.isPlaying)
                audioSource.Stop();

            audioSource.pitch = pitch;
            audioSource.clip = audioClip;
            audioSource.Play();
        }
        else //Effect 효과음 재생
        {
            AudioSource audioSource = _audioSources[(int)Define.Sound.Effect];
            audioSource.pitch = pitch;
            audioSource.PlayOneShot(audioClip); //한번만 재상
        }
    }

    public void Play(string path, Define.Sound type = Define.Sound.Effect, float pitch = 1.0f)
    {
        AudioClip audioClip = GetOrAddAudioClip(path, type);
        Play(audioClip, type, pitch);
    }

    AudioClip GetOrAddAudioClip(string path, Define.Sound type = Define.Sound.Effect)
    {
        AudioClip audioClip = null;

        if(type == Define.Sound.Bgm)
        {
            audioClip = GameManager.Instance.LoadAudioClip(path);
        }
        else
        {
            if(_audioClips.TryGetValue(path, out audioClip) == false)
            {
                audioClip = GameManager.Instance.LoadAudioClip(path);
                _audioClips.Add(path, audioClip);
            }
        }
        return audioClip;
    }

    public void PauseBGM() //BGM일시정지
    {
        AudioSource audioSource = _audioSources[(int)Define.Sound.Bgm];
        if (audioSource.isPlaying)
            audioSource.Pause();
    }

    public void ResumeBGM() //BGM일시정지 해제
    {
        AudioSource audioSource = _audioSources[(int)Define.Sound.Bgm];
        audioSource.UnPause();
    }

    public void PlayBGM() //BGM 처음부터 재생
    {
        AudioSource audioSource = _audioSources[(int)Define.Sound.Bgm];
        audioSource.Play();
    }
}

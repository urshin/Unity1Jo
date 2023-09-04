using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SoundManager : SingletonBehaviour<SoundManager>
{
    [SerializeField] List<AudioClip> SourceList = new List<AudioClip>();  
    void Awake()
    {
        base.Awake();
    }    

    public void PlaySound(string soundName)   
    {
        switch (soundName)
        {
            case "jelly":
                GetComponent<AudioSource>().PlayOneShot(SourceList[0]);
                break;
        }
    }
}

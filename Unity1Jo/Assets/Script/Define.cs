using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define : MonoBehaviour
{
    //code by.동호
    public enum UIEvent
    {
        Click,
        PointerDown,
        PointerUp,
    }
    public enum SceneType
    {
        Bonus,
        InGame,
        None,
    }
    public enum Sound //code by. 하은
    {
        Bgm,
        Effect,
        MaxCount, //Sound enum의 갯수
    }

    public enum Transition
    {
        Fade,  
    }
}

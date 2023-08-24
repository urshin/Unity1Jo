using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util : MonoBehaviour
{
    //code by.동호
    public static T GetOrAddComponent<T>(GameObject go) where T : UnityEngine.Component
    {
        T component = go.GetComponent<T>(); // T 타입의 컴포넌트를 얻어옴 
        if (component == null) // 컴포넌트가 없다면 
            component = go.AddComponent<T>(); // 추가하고 
        return component; // component 반환 
    }
}

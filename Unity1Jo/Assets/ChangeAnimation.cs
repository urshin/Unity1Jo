using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditorInternal.Profiling.Memory.Experimental.FileFormat;
using UnityEngine;

public class ChangeAnimation : MonoBehaviour
{
    Player p;

    private Animator currnutAnime;
    public string[] name;
    
    void Start()
    {
        p = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        currnutAnime = GetComponent<Animator>();
       
        var resourceName = "Animator Override Controller/" + name[p.mapcount].ToString();
        var animator = gameObject.GetComponent<Animator>();
        animator.runtimeAnimatorController = (RuntimeAnimatorController)Resources.Load(resourceName);

    }


    void Update()
    {

    }
}

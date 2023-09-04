using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusMap : MonoBehaviour
{
    [SerializeField] Transform BonusWallBottom;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SetBonusWallColliderEnabled(bool flag)
    {
        BonusWallBottom.GetComponent<BoxCollider2D>().enabled = flag;    
    }

}

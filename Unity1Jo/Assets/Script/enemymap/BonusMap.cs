using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusMap : MonoBehaviour
{
    [SerializeField] Transform BonusWallBottom;
    [SerializeField] Transform BonusWallTop;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SetBonusWallColliderEnabled(bool flag)
    {
        BonusWallBottom.GetComponent<BoxCollider2D>().enabled = flag;
        //BonusWallTop.GetComponent<BoxCollider2D>().enabled = flag;          
    }

}

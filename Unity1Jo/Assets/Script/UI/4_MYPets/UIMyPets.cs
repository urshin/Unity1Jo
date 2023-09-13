using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class UIMyPets : MonoBehaviour
{
    public MYPETS_UIScrollView p_UIScrollView;
    public Text coinTxt;

    public void Initialize()
    {
        p_UIScrollView.Initialize();
    }

    private void Update()
    {
        coinTxt.text = string.Format("{0:n0}", GameManager.Instance.totalCoin);
    }
}

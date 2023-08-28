using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScenetoMYCOOKIES : MonoBehaviour //code by. гою╨
{
    [SerializeField] GameObject myCookiesBtn;

    public void Awake()
    {
        myCookiesBtn.GetComponent<Button>().onClick.AddListener(GotoMyCookies);
    }

    public void GotoMyCookies()
    {
        SceneManager.LoadScene("MYCOOKIES");
    }
}

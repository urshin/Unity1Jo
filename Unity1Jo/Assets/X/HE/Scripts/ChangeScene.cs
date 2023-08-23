using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] GameObject startBtn;
    [SerializeField] GameObject myCookiesBtn;

    //public void Awake()
    //{
    //    startBtn.GetComponent<Button>().onClick.AddListener(GotoLobby);
    //}
    public void GotoLobby()
    {
        SceneManager.LoadScene("LOBBY");
    }

    public void GotoMyCookies()
    {
        SceneManager.LoadScene("MYCOOKIES");
    }
}

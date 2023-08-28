using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GobacktoLOBBY : MonoBehaviour //code by. гою╨
{
    [SerializeField] GameObject gobackBtn;

    public void Awake()
    {
        gobackBtn.GetComponent<Button>().onClick.AddListener(GotoLobby);
    }

    public void GotoLobby()
    {
        SceneManager.LoadScene("LOBBY");
    }
}

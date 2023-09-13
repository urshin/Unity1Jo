using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScenetoLOBBY : MonoBehaviour //code by. гою╨
{
    [SerializeField] GameObject backBtn;

    public void Awake()
    {
        backBtn.GetComponent<Button>().onClick.AddListener(GotoLobby);
    }

    public void GotoLobby()
    {
        SceneManager.LoadScene("LOBBY");
    }
}

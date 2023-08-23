using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScenetoLOBBY : MonoBehaviour
{
    [SerializeField] GameObject startBtn;

    public void Awake()
    {
        startBtn.GetComponent<Button>().onClick.AddListener(GotoLobby);
    }

    public void GotoLobby()
    {
        SceneManager.LoadScene("LOBBY");
    }
}

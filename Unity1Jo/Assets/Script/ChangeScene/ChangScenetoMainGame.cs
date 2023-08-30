using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangScenetoMainGame : MonoBehaviour
{
    [SerializeField] GameObject playBtn;

    public void Awake()
    {
        playBtn.GetComponent<Button>().onClick.AddListener(GotoLobby);
    }

    public void GotoLobby()
    {
        SceneManager.LoadScene("MainScene");
    }
}

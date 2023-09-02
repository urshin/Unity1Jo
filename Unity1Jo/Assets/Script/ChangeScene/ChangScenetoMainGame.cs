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
        playBtn.GetComponent<Button>().onClick.AddListener(GotoMainScene);
    }

    public void GotoMainScene()
    {
        SceneManager.LoadScene("MainScene");  
        //SceneManager.LoadScene("DH_MainScene2");      

        if(FindObjectOfType<Spawnanager>() != null)
            Spawnanager.Instance.gameObject.GetComponent<Spawnanager>().enabled = true;              


    }
}

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
        if (Spawnanager.Instance == null)
            return;  
        //Spawnanager.Instance.ChangeJellyPrefab(Spawnanager.Instance.whatjelly[0], Spawnanager.Instance.image0);
        //Spawnanager.Instance.ChangeEnemy(Spawnanager.Instance.whatobstacle[0], Spawnanager.Instance.Short0);
        //Spawnanager.Instance.ChangeEnemy(Spawnanager.Instance.whatobstacle[1], Spawnanager.Instance.Long0);
        //Spawnanager.Instance.ChangeEnemy(Spawnanager.Instance.whatobstacle[2], Spawnanager.Instance.Slide0);
        //Spawnanager.Instance.ChangeEnemy(Spawnanager.Instance.whatobstacle[3], Spawnanager.Instance.LongSlide0);
        ////SceneManager.LoadScene("DH_MainScene2");      

        //if (FindObjectOfType<Spawnanager>() != null)
        //    Spawnanager.Instance.gameObject.GetComponent<Spawnanager>().enabled = true;              


    }
}

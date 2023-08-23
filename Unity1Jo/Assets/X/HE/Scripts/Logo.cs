using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Logo : MonoBehaviour
{
    [SerializeField] GameObject startBtn;
    [SerializeField] Image panel;
    [SerializeField] float fadeSpeed = 2.0f;
    float alpha = 0;

    public void GameStart()
    {
        alpha += Time.deltaTime * fadeSpeed;
        panel.color = new Color(0, 0, 0, alpha);
        if (Mathf.Approximately(panel.color.a, 1f))
        {
            SceneManager.LoadScene("LOBBY");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOutLOGO : MonoBehaviour
{
    [SerializeField] float fadeSpeed = 1.5f;
    float alpha = 0;

    public Image panel;

    private void Awake()
    {
        //작업을 위해 유니티 인스펙터에서는 꺼놔서 Awake()로 켜줌
        panel.gameObject.SetActive(true);
    }
    void Start()
    {
        StartCoroutine("FadeOut");
    }

    IEnumerator FadeOut()
    {
        while (panel.color.a < 1)
        {
            alpha += Time.deltaTime * fadeSpeed;
            panel.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
    }
}

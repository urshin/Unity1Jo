using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFX : MonoBehaviour
{
    //code by. 하은
    SpriteRenderer sr;

    [Header("Flash FX")]
    [SerializeField] float flashDuration;
    [SerializeField] Material hitMat;
    Material originalmat;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>(); //Player하위로 Animator넣을 경우 InChildren으로 변경
        originalmat = sr.material;
    }

    IEnumerator FlashFX()
    {
        sr.material = hitMat;
        yield return new WaitForSeconds(flashDuration);
        sr.material = originalmat;
    }
}

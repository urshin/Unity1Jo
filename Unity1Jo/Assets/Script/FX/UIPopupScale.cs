using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class UIPopupScale : MonoBehaviour //code by. 하은
{
    [SerializeField] GameObject backPanel;
    [SerializeField] GameObject checkPopup;
    [SerializeField] GameObject cautionPopup;
    [SerializeField] public Button buyBtn;
    [SerializeField] Button closeBtnCheck; //checkPopup창에 있는 닫기 버튼
    [SerializeField] Button closeBtnCaution; //cautionPopup창에 있는 닫기 버튼
    [SerializeField] float animationDuration = 0.1f; //커지는 애니메이션이 진행되는 시간
    public bool isBuy;

    void Start()
    {
        // DOTween 초기화 및 tweens capacity 설정
        DOTween.Init();
        DOTween.SetTweensCapacity(1000, 100); 
    }
    private void Update()
    {
        //닫기 버튼을 누르면 Hide() 메소드 실행
        closeBtnCheck.onClick.AddListener(() => {
            backPanel?.SetActive(false);
            checkPopup?.SetActive(false); 
        });

        //닫기 버튼을 누르면 Hide() 메소드 실행
        closeBtnCaution.onClick.AddListener(() => {
            backPanel?.SetActive(false);
            cautionPopup?.SetActive(false); 
        });

        //구매하기 버튼을 눌렀을 경우
        buyBtn.onClick.AddListener(() => { isBuy = true; });
    }
    public void ShowCheckPopup()
    {
        backPanel.SetActive(true);
        checkPopup.SetActive(true);
        if (checkPopup != null)
        {
            //바꿀 스케일 
            Vector3 changeScale = new Vector3(1f, 1f, 1f);
            checkPopup.GetComponent<RectTransform>().DOScale(changeScale, animationDuration);
        }
    }

    public void ShowCautionPopup()
    {
        backPanel.SetActive(true);
        cautionPopup.SetActive(true);
        if (cautionPopup != null)
        {
            //바꿀 스케일 
            Vector3 changeScale = new Vector3(1f, 1f, 1f);
            cautionPopup.GetComponent<RectTransform>().DOScale(changeScale, animationDuration);
        }
    }

    //public void HideCheckPopup()
    //{
    //    if (checkPopup != null)
    //    {
    //        //바꿀 스케일 
    //        Vector3 changeScale = new Vector3(0.1f, 0.1f, 1f);
    //        checkPopup.GetComponent<RectTransform>().DOScale(changeScale, animationDuration)
    //        .OnComplete(() =>
    //        {
    //            // 애니메이션 완료 후 팝업 닫기
    //            checkPopup.SetActive(false);
    //        });
    //    }
    //}

    //public void HideCautionPopup()
    //{
    //    if (cautionPopup != null)
    //    {
    //        cautionPopup.SetActive(false);
    //        //Vector3 changeScale = new Vector3(0.1f, 0.1f, 1f);
    //        //cautionPopup.GetComponent<RectTransform>().DOScale(changeScale, animationDuration)
    //        //.OnComplete(() =>
    //        //{
    //        //    // 애니메이션 완료 후 팝업 닫기
    //        //    cautionPopup.SetActive(false);
    //        //});
    //    }
    //}
}

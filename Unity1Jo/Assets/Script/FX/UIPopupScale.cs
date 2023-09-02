using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class UIPopupScale : MonoBehaviour //code by. ����
{
    [SerializeField] GameObject checkPopup;
    [SerializeField] GameObject cautionPopup;
    [SerializeField] public Button buyBtn;
    [SerializeField] Button closeBtnCheck; //checkPopupâ�� �ִ� �ݱ� ��ư
    [SerializeField] Button closeBtnCaution; //cautionPopupâ�� �ִ� �ݱ� ��ư
    [SerializeField] float animationDuration = 0.1f; //Ŀ���� �ִϸ��̼��� ����Ǵ� �ð�
    public bool isBuy;

    void Start()
    {
        // DOTween �ʱ�ȭ �� tweens capacity ����
        DOTween.Init();
        DOTween.SetTweensCapacity(1000, 100); 
    }
    private void Update()
    {
        //�ݱ� ��ư�� ������ Hide() �޼ҵ� ����
        closeBtnCheck.onClick.AddListener(() => { HideCheckPopup(); });

        //�ݱ� ��ư�� ������ Hide() �޼ҵ� ����
        closeBtnCaution.onClick.AddListener(() => { HideCautionPopup(); });

        //�����ϱ� ��ư�� ������ ���
        buyBtn.onClick.AddListener(() => { isBuy = true; });
    }
    public void ShowCheckPopup()
    {
        checkPopup.SetActive(true);
        if (checkPopup != null)
        {
            //�ٲ� ������ 
            Vector3 changeScale = new Vector3(1f, 1f, 1f);
            checkPopup.GetComponent<RectTransform>().DOScale(changeScale, animationDuration);
        }
    }

    public void ShowCautionPopup()
    {
        cautionPopup.SetActive(true);
        if (cautionPopup != null)
        {
            //�ٲ� ������ 
            Vector3 changeScale = new Vector3(1f, 1f, 1f);
            cautionPopup.GetComponent<RectTransform>().DOScale(changeScale, animationDuration);
        }
    }

    public void HideCheckPopup()
    {
        if (checkPopup != null)
        {
            //�ٲ� ������ 
            Vector3 changeScale = new Vector3(0.1f, 0.1f, 1f);
            checkPopup.GetComponent<RectTransform>().DOScale(changeScale, animationDuration)
            .OnComplete(() =>
            {
                // �ִϸ��̼� �Ϸ� �� �˾� �ݱ�
                checkPopup.SetActive(false);
            });
        }
    }

    public void HideCautionPopup()
    {
        if (cautionPopup != null)
        {
            Vector3 changeScale = new Vector3(0.1f, 0.1f, 1f);
            cautionPopup.GetComponent<RectTransform>().DOScale(changeScale, animationDuration)
            .OnComplete(() =>
            {
                // �ִϸ��̼� �Ϸ� �� �˾� �ݱ�
                cautionPopup.SetActive(false);
            });
        }
    }
}
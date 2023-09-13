using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MYPETS_Main : MonoBehaviour
{
    public UIMyPets uiMyPets;
    public MYPETS_UIScrollView petScrollView;

    [Header("Popup Data")]
    [SerializeField] GameObject UI_BuyPopup;
    [SerializeField] GameObject ui_CheckPopupBox;
    [SerializeField] GameObject ui_CautionPopupBox;
    [SerializeField] private Vector3 targetScale = new Vector3(1.2f, 1.2f, 1.2f); // 확대할 스케일 값
    [SerializeField] private Vector3 originScale = new Vector3(1, 1, 1); // 확대할 스케일 값
    [SerializeField] private float animationDuration = 0.2f; // 애니메이션 지속 시간  

    [Header("Audio Sound ")]
    //[SerializeField] string bgmAudioClipPath = "";
    [SerializeField] string effectAudioClipPath = "E_ClickBtn";
    private void Start()
    {
        UI_DataManager.instance.LoadPetsData();

        //선택버튼 클릭 시,
        EventManager.instance.onSelectBtnClick = (id) =>
        {
            var data = UI_DataManager.instance.GetPetsData(id);

            //뒤로가기 누르면 LOBBY씬으로 바뀌면서 해당 캐릭터가 출력
            if (UserDataManager.Instance.GetHasPet(id) == 0) // 펫 안가지고 있으면 리턴 
                return;

            UserDataManager.Instance.SetSelectPetID(id);
            UIScrollViewPetsSelect beforeCheckpetComponent = petScrollView.GetPetComponentList()?.Find(item => item.GetCheck() == true); // 현재 체크되어있는 펫 컴포넌트 가져옴 
            UIScrollViewPetsSelect afterCheckpetComponent = petScrollView.GetPetComponentList()?.Find(item => item.GetID() == data.id);  // 선택된 펫 컴포넌트 가져옴 
            beforeCheckpetComponent?.RefreshCheck(); // 선택 refresh 
            afterCheckpetComponent?.RefreshCheck();  // 선택 refresh 


            //Effect재생
            AudioClip effectAudioClip = GameManager.Instance.LoadAudioClip(effectAudioClipPath);
            if (effectAudioClip != null)
            {
                SoundManager.Instance.Play(effectAudioClip, Define.Sound.Effect);
            }
        };

        //구매버튼 클릭 시,
        EventManager.instance.onBuyBtnClick = (id) =>
        {
            var data = UI_DataManager.instance.GetPetsData(id);
            Debug.LogFormat("{0},{1},{2}", data.id, data.name, data.price);

            float totCoin = GameManager.Instance.totalCoin; // total coin 가져옴 
            Debug.Log($"totCoin : {totCoin}");

            if (totCoin >= data.price)
            {
                UI_BuyPopup.gameObject.SetActive(true);

                GameObject checkPopupBox = Instantiate(ui_CheckPopupBox);   // 동적으로 popup 생성 (해당 프리팹 위치 : Asset/Prefabs/UI/Popup)
                checkPopupBox.transform.SetParent(UI_BuyPopup.transform);   // 부모 설정 
                checkPopupBox.GetComponent<RectTransform>().localPosition = Vector2.zero;   // position 설정 
                checkPopupBox.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1); // scale 설정 

                // ID, price, view 설정해줌   
                UI_CheckPopupBox checkComponent = checkPopupBox.GetComponent<UI_CheckPopupBox>();
                checkComponent.SetPetID(data.id);
                checkComponent.SetPetPrice(data.price);
                checkComponent.SetPetScrollView(petScrollView);
                checkComponent.SetPopupType(Define.PopupType.Pet);  

                // popup animation 
                checkPopupBox.GetComponent<RectTransform>().DOScale(targetScale, animationDuration).OnComplete(() =>
                {
                    checkPopupBox.GetComponent<RectTransform>().DOScale(originScale, animationDuration);
                });

            }
            else
            {
                UI_BuyPopup.gameObject.SetActive(true);

                GameObject cautionPopupBox = Instantiate(ui_CautionPopupBox);   // 동적으로 popup 생성  (해당 프리팹 위치 : Asset/Prefabs/UI/Popup)
                cautionPopupBox.transform.SetParent(UI_BuyPopup.transform);     // 부모 설정 
                cautionPopupBox.GetComponent<RectTransform>().localPosition = Vector2.zero; // position 설정 
                cautionPopupBox.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1); // scale 설정 

                // popup animation 
                cautionPopupBox.GetComponent<RectTransform>().DOScale(targetScale, animationDuration).OnComplete(() =>
                {
                    cautionPopupBox.GetComponent<RectTransform>().DOScale(originScale, animationDuration);
                });

                Debug.Log("코인이 부족합니다.");
            }

            //Effect재생
            AudioClip effectAudioClip = GameManager.Instance.LoadAudioClip(effectAudioClipPath);
            if (effectAudioClip != null)
            {
                SoundManager.Instance.Play(effectAudioClip, Define.Sound.Effect);
            }
        };

        uiMyPets.Initialize();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScrollViewPetsSelect : MonoBehaviour
{
    public Text petName;
    public Image petImg;
    public Button selectBtn;
    [SerializeField] GameObject SelectPanel;
    [SerializeField] GameObject BuyPanel;
    public Button buyBtn;
    public Text priceTxt;
    [SerializeField] int id;
    [SerializeField] GameObject lockIcon;
    [SerializeField] GameObject checkIcon;

    public void Initialize(MyPetsData data)
    {
        id = data.id;
        petName.text = data.name;
        var atlas = AtlasManager.Instance.GetAtlasByName("Pets");
        petImg.sprite = atlas.GetSprite(data.sprite_name);
        petImg.SetNativeSize();
        petImg.GetComponent<RectTransform>().sizeDelta = new Vector2(430, 328); //Sprite 사이즈 고정
        priceTxt.text = string.Format("{0}", data.price);

        SetActivePanel();
        RefreshCheck();  
    }

    public int GetID()
    {
        return id;
    }
    public void SetActivePanel()
    {
        if (id == 100)
        {
            SelectPanel.SetActive(true);
            BuyPanel.SetActive(false);

        }
        else
        { 
            if (UserDataManager.Instance.GetHasPet(id) == 1)
            {
                SelectPanel.SetActive(true);
                BuyPanel.SetActive(false);
            }
            else
            {
                SelectPanel.SetActive(false);
                BuyPanel.SetActive(true);
            }
        }
    }
    public void RefreshLock()
    {
        if (UserDataManager.Instance.GetHasPet(id) == 0) // 펫 안가지고 있음 
        {
            SetLock(true);
        }
        else
        {
            SetLock(false);
        }
    }
    public void SetLock(bool flag)
    {
        lockIcon.SetActive(flag);
    }
    public void SetCheck(bool flag)
    {
        checkIcon.SetActive(flag);
    }
    public bool GetCheck()
    {
        return checkIcon.activeSelf;
    }
    public void RefreshCheck()
    {
        if (UserDataManager.Instance.GetHasPet(id) == 1)
        {
            if (UserDataManager.Instance.GetSelectPetID() == id)
            {
                SetCheck(true);
            }
            else
            {
                SetCheck(false);
            }
        }
        else // 펫 안가지고 있다.
        {
            SetCheck(false);
        }
    }
}

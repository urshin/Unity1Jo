using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MYPETS_UIScrollView : MonoBehaviour
{
    [SerializeField] Transform contentTrans;
    [SerializeField] GameObject petsPrefab;
    [SerializeField] List<UIScrollViewPetsSelect> PetsComponentList = new List<UIScrollViewPetsSelect>();

    private void Awake()
    {
        foreach (Transform child in contentTrans.transform)
            GameObject.Destroy(child.gameObject);   
    }
    public void Initialize()
    {
        List<MyPetsData> list = UI_DataManager.instance.GetMypetsDatas();

        foreach (MyPetsData data in list)
        {
            //create
            AddPets(data);
            Debug.Log("펫 프리팹들 생성");
        }
    }
    public void AddPets(MyPetsData data)
    {
        var go = Instantiate(petsPrefab, contentTrans);
        UIScrollViewPetsSelect pets = go.GetComponent<UIScrollViewPetsSelect>();  
        pets.Initialize(data);

        //각 버튼을 누르면 해당 pets의 id를 EventManager에게 전달
        pets.selectBtn.onClick.AddListener(() => {
            EventManager.instance.onSelectBtnClick(pets.GetID());
        });
        pets.buyBtn.onClick.AddListener(() => {
            EventManager.instance.onBuyBtnClick(pets.GetID());
        });

        // 장금처리 
        if (UserDataManager.Instance.GetHasPet(data.id) == 0) // 쿠키 안가지고 있음 
        {
            pets.SetLock(true);
        }
        else
        {
            pets.SetLock(false);
        }

        PetsComponentList.Add(pets);  

    }
    public List<UIScrollViewPetsSelect> GetPetComponentList()
    {
        return PetsComponentList;
    }
}

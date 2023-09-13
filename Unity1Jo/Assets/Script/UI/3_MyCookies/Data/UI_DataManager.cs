using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.Linq;

public class UI_DataManager //code by. 하은
{
    public static readonly UI_DataManager instance = new UI_DataManager();

    //arrMycookiesDatas가 key(id)-value로 되어있어서 Dictionary 컬렉션 사용
    private Dictionary<int, MycookiesData> dicMycookiesData;// = new Dictionary<int, MycookiesData>(); -> using System.Linq를 사용해서 초기화 필요없음
    private Dictionary<int, MyPetsData> dicPetsData;

    private UI_DataManager() { }

    public MycookiesData GetCookiesData(int id)
    {
        return dicMycookiesData[id];
    }

    public MyPetsData GetPetsData(int id)
    {
        return dicPetsData[id];
    }
    public void LoadCookiesData()
    {
        //TextAsset을 로드(Resources폴더-data폴더-Mycookies_data파일을 Load)
        TextAsset asset = Resources.Load<TextAsset>("data/MyCookies_data");
        //asset의 문자열 출력
        var json = asset.text;

        //역직렬화
        MycookiesData[] arrMycookiesDatas = JsonConvert.DeserializeObject<MycookiesData[]>(json);

        //key를 id로 해서 새로운 사전 객체가 생성되어 반환됨(for문에서 dicMycookiesData(data.id, data)해준 것과 같은 기능)
        dicMycookiesData = arrMycookiesDatas.ToDictionary(x => x.id); 
    }

    public void LoadPetsData()
    {
        TextAsset asset = Resources.Load<TextAsset>("data/MyPets_data");
        var json = asset.text;
        MyPetsData[] arrMypetsDatas = JsonConvert.DeserializeObject<MyPetsData[]>(json);
        dicPetsData = arrMypetsDatas.ToDictionary(x => x.id);

        Debug.LogFormat("shop data loaded:{0}", dicPetsData.Count);
    }

    //dicMycookiesData의 Values를 List로 반환
    public List<MycookiesData> GetMycookiesDatas()
    {
        return dicMycookiesData.Values.ToList();
    }

    //public Dictionary<int, MycookiesData> GetMyCookiesData()
    //{
    //    return dicMycookiesData;
    //}

    //dicPetsData Values를 List로 반환
    public List<MyPetsData> GetMypetsDatas()
    {
        return dicPetsData.Values.ToList();
    }

    //public Dictionary<int, MyPetsData> GetMypetsData()
    //{
    //    return dicPetsData;
    //}
}

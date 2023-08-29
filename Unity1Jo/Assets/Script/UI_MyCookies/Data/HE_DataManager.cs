using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.Linq;

public class HE_DataManager //혹시 DataManager를 쓴 사람이 있을까봐 충돌방지로 HE 달아둠. 나중에 DataManager로 이름 수정예정 //code by. 하은
{
    public static readonly HE_DataManager instance = new HE_DataManager();

    //arrMycookiesDatas가 key(id)-value로 되어있어서 Dictionary 컬렉션 사용
    private Dictionary<int, MycookiesData> dicMycookiesData;// = new Dictionary<int, MycookiesData>(); -> using System.Linq를 사용해서 초기화 필요없음

    private HE_DataManager() { }

    public MycookiesData GetData(int id)
    {
        return dicMycookiesData[id];
    }
    public void LoadData()
    {
        //TextAsset을 로드(Resources폴더-Data폴더-Mycookies_data파일을 Load)
        TextAsset asset = Resources.Load<TextAsset>("Data/MyCookies_data");
        //asset의 문자열 출력
        var json = asset.text;

        //역직렬화
        MycookiesData[] arrMycookiesDatas = JsonConvert.DeserializeObject<MycookiesData[]>(json);

        //key를 id로 해서 새로운 사전 객체가 생성되어 반환됨(for문에서 dicMycookiesData(data.id, data)해준 것과 같은 기능)
        dicMycookiesData = arrMycookiesDatas.ToDictionary(x => x.id); 
    }

    //dicMycookiesData의 Values를 List로 반환
    public List<MycookiesData> GetMycookiesDatas()
    {
        return dicMycookiesData.Values.ToList();
    }

    public Dictionary<int, MycookiesData> GetMyCookiesData()
    {
        return dicMycookiesData;
    }
}

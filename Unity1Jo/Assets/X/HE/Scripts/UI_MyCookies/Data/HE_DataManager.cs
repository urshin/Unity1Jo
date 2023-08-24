using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.Linq;

public class HE_DataManager //혹시 DataManager를 쓴 사람이 있을까봐 충돌방지로 HE 달아둠. 나중에 DataManager로 이름 수정예정
{
    public static readonly HE_DataManager instance = new HE_DataManager();

    //컬렉션 초기화
    private Dictionary<int, MycookiesData> dicMycookiesData;// = new Dictionary<int, MycookiesData>(); -> 네임스페이스에 using System.Linq해줘서 필요없어짐

    private HE_DataManager() { }

    public MycookiesData GetData(int id)
    {
        return dicMycookiesData[id];
    }
    public void LoadData()
    {
        //TextAsset을 로드
        TextAsset asset = Resources.Load<TextAsset>("Data/Mycookies_data"); //Resources폴더-Data폴더-Mycookies_data파일을 Load해라
        //asset의 문자열 출력
        var json = asset.text;
        Debug.Log(asset.text);

        //역직렬화
        MycookiesData[] arrMycookiesDatas = JsonConvert.DeserializeObject<MycookiesData[]>(json);

        dicMycookiesData = arrMycookiesDatas.ToDictionary(x => x.id); //새로운 사전 객체가 생성 반환

        Debug.LogFormat("Mycookies data loaded! :{0}", dicMycookiesData.Count);
    }

    public List<MycookiesData> GetMycookiesDatas()
    {
        return dicMycookiesData.Values.ToList();
    }
}

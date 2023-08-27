using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MycookiesData 
{
    //json 파일에 있는 데이터를 한 줄씩 역직렬화하기 위해 바인딩클래스로 MycookiesData 클래스 만듦

    public int id;
    public string name;
    public string sprite_name;
    public int price;
    public int type;
}

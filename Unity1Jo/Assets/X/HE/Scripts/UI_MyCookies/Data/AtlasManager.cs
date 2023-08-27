using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class AtlasManager : MonoBehaviour //code by. 하은
{
    public static AtlasManager instance;

    public SpriteAtlas[] arrAtlas; //혹시 장애물도 SpriteAtlas로 쓸 수 있으니 배열로 해놨음
    public Dictionary<string, SpriteAtlas> dicAtlas = new Dictionary<string, SpriteAtlas>();

    private void Awake()
    {
        AtlasManager.instance = this;

        //Debug.LogFormat("arrAtlas.Length: {0}", arrAtlas.Length);

        for(int i = 0; i < arrAtlas.Length; i++)
        {
            var atlas = arrAtlas[i];

            //현재 atlas파일명을 (이름)Atlas로 해놔서, 파일명에서 Atlas를 제거된 '이름'을 Key로 사용함
            var atlasName = atlas.name.Replace("Atlas", "");
            dicAtlas.Add(atlasName, atlas);
            
        }
    }

    public SpriteAtlas GetAtlasByName(string name) //Key
    {
        if (dicAtlas.ContainsKey(name))
        {
            return dicAtlas[name];
        }
        else
        {
            Debug.LogFormat("<color=red> key: {0}를 찾을 수 없습니다.</color>", name);
            return null;
        }
    }
}

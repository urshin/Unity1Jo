using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class AtlasManager : SingletonBehaviour<AtlasManager> //code by. 하은
{
    public SpriteAtlas[] arrAtlas;
    public Dictionary<string, SpriteAtlas> dicAtlas = new Dictionary<string, SpriteAtlas>();

    private void Awake()
    {
        base.Awake();

        for(int i = 0; i < arrAtlas.Length; i++)
        {
            var atlas = arrAtlas[i];
            var atlasName = atlas.name.Replace("Atlas", ""); //현재 atlas파일명을 (이름)Atlas로 해놔서, 파일명에서 Atlas를 제거된 '이름'을 Key로 사용함
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

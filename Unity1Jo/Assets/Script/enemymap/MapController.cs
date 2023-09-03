using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public static MapController Instance;
    private void Awake()
    {
        Instance = this;
    }

    // 오븐 안 (시작 맵)
    public Material[] mat_ovenIn;  
    public Material[] mat_map; // 오븐 밖
    public Material[] mat_map1;  // 신준씨 맵
    public Material[] mat_map2; // 아무거나 넣음
    public Material[] mat_map3; // 아무거나 넣음
    //public Material[] mat_map4; // 얼음맵?
                               
    Player p;

    public string CurrentMap;

    void Start()
    {
        p = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        GameObject Mbonus = GameObject.Find("BonusMap").gameObject;
        Mbonus?.SetActive(false);  
    }

   
    void Update()
    {
        //if (p.mapcount == 0)
        //{
        //    //CurrentMap = Spawnanager.Instance.map1; //게임 시작 시 현재 맵 == map1

        //}
        //else if (p.mapcount == 1 && p.isMapChange && !p.isBonusTime)
        //{
        //   // CurrentMap = Spawnanager.Instance.map2;
        //    ChangeMaterial(mat_map);
        //   // p.isMapChange = false;
        //}
        //else if (p.mapcount == 2 && p.isMapChange && !p.isBonusTime)
        //{
        //    //CurrentMap = Spawnanager.Instance.map3;
        //    ChangeMaterial(mat_map1);
        //    //p.isMapChange = false;
        //}
        //else if (p.mapcount == 3 && p.isMapChange && !p.isBonusTime)
        //{
        //    ChangeMaterial(mat_map2);
        //    //CurrentMap = Spawnanager.Instance.map4;
        //    // p.isMapChange = false;
        //}
        //else if (p.mapcount == 4 && p.isMapChange && !p.isBonusTime)  
        //{
        //    ChangeMaterial(mat_map3);
        //    //CurrentMap = Spawnanager.Instance.map4;
        //    // p.isMapChange = false;
        //}
        //else if (p.mapcount == 5 && p.isMapChange && !p.isBonusTime)
        //{
        //    //ChangeMaterial(mat_map4);
        //    //CurrentMap = Spawnanager.Instance.map4;
        //    // p.isMapChange = false;
        //}
    }
    public void ChangeMaterial(Material[] mat_map)
    {
        //Transform[] children = transform.GetComponentsInChildren<Transform>();
        Transform[] children = GameObject.Find("Map").transform.GetComponentsInChildren<Transform>();
    
        foreach (Transform child in children)
        {
            if (child.gameObject.name == "BackGround1")
            {
                MeshRenderer meshRenderer = child.gameObject.GetComponent<MeshRenderer>();
                if (meshRenderer != null && mat_map != null) // mat_map.Length을 쓸 필요가 있는가?
                {
                    meshRenderer.sharedMaterials = new Material[] { mat_map[0] };
                }
            }
            if (child.gameObject.name == "BackGround2")
            {
                MeshRenderer meshRenderer = child.gameObject.GetComponent<MeshRenderer>();
                if (meshRenderer != null && mat_map != null && mat_map.Length > 0)
                {
                    meshRenderer.sharedMaterials = new Material[] { mat_map[1] };
                }
            }
            if (child.gameObject.name == "BackGround3")
            {
                MeshRenderer meshRenderer = child.gameObject.GetComponent<MeshRenderer>();
                if (meshRenderer != null && mat_map != null && mat_map.Length > 0)
                {
                    meshRenderer.sharedMaterials = new Material[] { mat_map[2] };
                }
            }
            if (child.gameObject.name == "Ground")
            {
                MeshRenderer meshRenderer = child.gameObject.GetComponent<MeshRenderer>();
                if (meshRenderer != null && mat_map != null && mat_map.Length > 0)
                {
                    meshRenderer.sharedMaterials = new Material[] { mat_map[3] };
                }
            }
        }
    }
}

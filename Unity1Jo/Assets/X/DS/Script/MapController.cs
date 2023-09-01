using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{

    public Material[] mat_map; // 두번째 맵 머테리얼
    public Material[] mat_map1; // 세번째 맵 머테리얼
                               
    Player p;

    public string CurrentMap;

    void Start()
    {
        p = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

   
    void Update()
    {
        if (p.mapcount == 0)
        {
            CurrentMap = Spawnanager.Instance.map1; //게임 시작 시 현재 맵 == map1

        }
        else if (p.mapcount == 1 && p.isMapChange)
        {
            CurrentMap = Spawnanager.Instance.map2;
            ChangeMaterial(mat_map);
            p.isMapChange = false;
        }
        else if (p.mapcount == 2 && p.isMapChange)
        {
            CurrentMap = Spawnanager.Instance.map3;
            ChangeMaterial(mat_map1);
            p.isMapChange = false;
        }
        else if (p.mapcount == 3 && p.isMapChange)
        {
            CurrentMap = Spawnanager.Instance.map4;
            p.isMapChange = false;
        }
    }
    void ChangeMaterial(Material[] mat_map)
    {
        Transform[] children = transform.GetComponentsInChildren<Transform>();

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

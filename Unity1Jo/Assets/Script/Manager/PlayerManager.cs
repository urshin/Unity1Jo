//플레이어 생성하게 해주는 매니저
//플레이어 생성하게 해주는 매니저
//플레이어 생성하게 해주는 매니저
//플레이어 생성하게 해주는 매니저

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : SingletonBehaviour<PlayerManager>
{
    [SerializeField] private GameObject player;
    void Awake()
    {
        base.Awake();
    }

    public GameObject GetPlayer()
    {
        return player;
    }

    [SerializeField] Transform OriginPlayerPos;

    public void SetOriginPlayerPosition()
    {
        player.transform.position = OriginPlayerPos.position;
        player.GetComponent<Player>().rb.velocity = Vector2.zero;

        //OriginPlayerPos.position = new Vector3(0,0,0);
    }

    

}

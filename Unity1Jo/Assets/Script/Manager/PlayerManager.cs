//플레이어 생성하게 해주는 매니저
//플레이어 생성하게 해주는 매니저
//플레이어 생성하게 해주는 매니저
//플레이어 생성하게 해주는 매니저

using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class PlayerManager : SingletonBehaviour<PlayerManager>
{
    [SerializeField] private GameObject player;
    Player p;

    void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        p = player.GetComponent<Player>();
        
    }
    public GameObject GetPlayer()
    {
        return player;
    }

    [SerializeField] Transform OriginPlayerPos;

    public void SetOriginPlayerPosition()
    {
        if (player.transform.localScale.y > p.OriginalSize.y)
        {
            player.transform.position = OriginPlayerPos.position+new Vector3(0,4,0);
            player.GetComponent<Player>().rb.velocity = Vector2.zero;
        }
        else
        player.transform.position = OriginPlayerPos.position;
        player.GetComponent<Player>().rb.velocity = Vector2.zero;

        //OriginPlayerPos.position = new Vector3(0,0,0);
    }

    

}

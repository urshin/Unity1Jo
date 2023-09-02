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
    [SerializeField] Dictionary<int, GameObject> PlayerGameObjectDict = new Dictionary<int, GameObject>();
    [SerializeField] GameObject cookie_100;
    [SerializeField] GameObject cookie_101;
    [SerializeField] GameObject cookie_102;
    [SerializeField] GameObject cookie_103;
    [SerializeField] GameObject cookie_104;

    void Awake()
    {
        base.Awake();

        PlayerGameObjectDict.Add(100, cookie_100);
        PlayerGameObjectDict.Add(101, cookie_101);
        PlayerGameObjectDict.Add(102, cookie_102);
        PlayerGameObjectDict.Add(103, cookie_103);
        PlayerGameObjectDict.Add(104, cookie_104);

        CreatePlayer();

    }

    private void Start()
    {

    }

    [SerializeField] Transform OriginPlayerPos;

    public void SetOriginPlayerPositi2on()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player").gameObject;
        if (player == null )
            return;

        Player p = player.GetComponent<Player>();

        if (player.transform.localScale.y > p.OriginalSize.y)
        {
            player.transform.position = OriginPlayerPos.position+new Vector3(0,4,0);  
            player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;  
        }
        else
        player.transform.position = OriginPlayerPos.position;
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;  

    }

    public void CreatePlayer()
    {

        int id = UserDataManager.Instance.GetSelectCookieID();
        Debug.Log($"id : {id}");

        if (PlayerGameObjectDict.ContainsKey(id))
        {
            Instantiate(PlayerGameObjectDict[id]);  
            SetOriginPlayerPositi2on();  
        }
    }

    public void DestroyPlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player").gameObject;
        if(player != null)
            Destroy(player);  

    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanCake : MonoBehaviour
{
    public float DotoriJellyCount;
    public float Jelly;
    public bool isSkillon;

    [SerializeField] Image SkillBar;


    public GameObject DotoriJelly;
    public GameObject SunflowerJelly;

    public Transform[] dotoriSpawnPos;
    public float SpawnSpeed;
    float LastSpawnTime;
    Player p;
    public int i;
    int m;


    bool setmap;
    void Start()
    {
        DotoriJellyCount = 0;
        isSkillon = false;
        p = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        setmap = true;
        m = 1;
    }

    void FixedUpdate()
    {
        if (setmap)
        {

            for (int j = 0; j < 5; j++)
            {
                dotoriSpawnPos[j] = Spawnanager.Instance.SpawnPos[j * 2];

            }
            setmap = false;
        }

        //��Ű ��ų ���°�
        if (!isSkillon)
        {
            SkillBar.fillAmount = DotoriJellyCount / 20;
            if (Time.time > LastSpawnTime + SpawnSpeed / p.GroundScrollSpeed)
            {
                LastSpawnTime = Time.time;
                i += 1 * m;
                Instantiate(DotoriJelly, dotoriSpawnPos[i].position, Quaternion.identity);

                if (i <= 0)
                {

                    m *= -1;
                }
                if (i >= 4)
                {
                    Instantiate(SunflowerJelly, dotoriSpawnPos[i].position, Quaternion.identity);
                    m *= -1;

                }


            }
        }
        if (DotoriJellyCount >= 20)
        {
            isSkillon = true;
        }
        if (isSkillon)
        {
            SkillBar.fillAmount -= Time.deltaTime;
            if (SkillBar.fillAmount <= 0)
            {
                DotoriJellyCount = 0;
                isSkillon = false;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == DotoriJelly)
        {
            DotoriJellyCount++;
            
        }
        if (collision.gameObject == SunflowerJelly)
        {
            Jelly++;
        }
    }
}
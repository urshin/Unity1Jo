using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Spawnanager;

public class PanCake : MonoBehaviour
{
    public float DotoriJellyCount;
    public float Jelly;
    public bool isSkillon;


    [SerializeField] Image SkillBar;


    public GameObject DotoriJelly;
    public GameObject SunflowerJelly;
    public GameObject SunflowerSeedJelly;

    public Transform[] dotoriSpawnPos;
    public float SpawnSpeed;
    float LastSpawnTime;
    Player p;
    public int i;
    int m;

    public float OriginalGravity;

    public Animator anim { get; private set; }
    public Rigidbody2D rb { get; private set; }

    GameObject dotori;
    bool setmap;
    void Start()
    {
        anim = GetComponentInChildren<Animator>(); //자식의 <Animator>()가져옴
        rb = GetComponent<Rigidbody2D>();
        OriginalGravity = rb.gravityScale;
        DotoriJellyCount = 0;
        isSkillon = false;
        p = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        setmap = true;
        m = 1;

        for (int i = 0; i < Spawnanager.Instance.SpawnPos.Length / 2; i++)
        {
            dotoriSpawnPos[i] = Spawnanager.Instance.SpawnPos[i * 2];
        }
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
        if (DotoriJellyCount >= 20)

        {
            isSkillon = true;
            
        }
        if (isSkillon && !p.isBonusTime)
        {

            if (SkillBar.fillAmount <= 0)
            {
                DotoriJellyCount = 0;
                
                isSkillon = false;
            }

            SkillBar.fillAmount -= 0.002f;


            if (anim.GetBool("Slide"))
            {
                if (Time.time > LastSpawnTime + SpawnSpeed / p.GroundScrollSpeed)
                {
                    LastSpawnTime = Time.time;
                    Instantiate(SunflowerSeedJelly, p.transform.position + new Vector3(2,2,0), Quaternion.identity);
                }
            }


        }
        //쿠키 스킬 쓰는곳
        if (!isSkillon && !p.isBonusTime)
        {

            SkillBar.fillAmount = DotoriJellyCount / 20;
            if (Time.time > LastSpawnTime + SpawnSpeed / p.GroundScrollSpeed)
            {
                LastSpawnTime = Time.time;
                i += 1 * m;
                dotori = Instantiate(DotoriJelly, dotoriSpawnPos[i].position, Quaternion.identity);

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

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DotoriJelly"))
        {
            DotoriJellyCount++;

        }
        if (collision.gameObject == SunflowerJelly)
        {
            Jelly++;
        }
    }
}

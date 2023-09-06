using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoonLight : MonoBehaviour
{
    public float StarJellyCount;
    public float Jelly;
    public bool isSkillon;


    [SerializeField] Image SkillBar;


    public GameObject StarJelly;
    public GameObject SunflowerJelly;

    public Transform[] StarSpawnPos;  
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
        StarJellyCount = 0;
        isSkillon = false;
        p = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        setmap = true;
        m = 1;

        for (int i = 0; i < Spawnanager.Instance.SpawnPos.Length / 2; i++)
        {
            StarSpawnPos[i] = Spawnanager.Instance.SpawnPos[i * 2];
        }
    }

    void FixedUpdate()
    {


        if (setmap)
        {

            for (int j = 0; j < 5; j++)
            {
                StarSpawnPos[j] = Spawnanager.Instance.SpawnPos[j * 2];

            }
            setmap = false;
        }
        if (StarJellyCount >= 20 && transform.position.y >= 2.5f)

        {
            isSkillon = true;
        }
        if (isSkillon && !p.isBonusTime)  
        {


            SkillBar.fillAmount -= 0.002f;
            //anim.SetBool("Fly", true);
            //anim.SetFloat("PanCakeyVelocity", SkillBar.fillAmount * 2);  
            //p.isDashing = true;



            if (SkillBar.fillAmount <= 0)
            {
                StarJellyCount = 0;
                isSkillon = false;
            }

        }
        //쿠키 스킬 쓰는곳
        if (!isSkillon && !p.isBonusTime)
        {
            //anim.SetBool("Fly", false);

            SkillBar.fillAmount = StarJellyCount / 20;
            if (Time.time > LastSpawnTime + SpawnSpeed / p.GroundScrollSpeed)  
            {
                LastSpawnTime = Time.time;
                i += 1 * m;
                
                dotori = Instantiate(StarJelly, StarSpawnPos[i].position, Quaternion.identity);
                Debug.Log($"{dotori.gameObject.name} 생성 ");

                if (i <= 0)
                {

                    m *= -1;
                }
                if (i >= 4)
                {
                    Instantiate(SunflowerJelly, StarSpawnPos[i].position, Quaternion.identity);
                    Debug.Log($"{dotori.gameObject.name} 생성 ");  

                    m *= -1;

                }


            }
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("StarJelly"))  
        {
            StarJellyCount++;

        }
        if (collision.gameObject == SunflowerJelly)
        {
            Jelly++;
        }
    }


}

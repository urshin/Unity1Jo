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
    [SerializeField] GameObject moonLightStars;
    [SerializeField] Transform moonlightStarPos;
    [SerializeField] GameObject RotateStars;  

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

    bool isStarSkill = false;

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

        //for (int i = 0; i < Spawnanager.Instance.SpawnPos.Length / 2; i++)
        //{
        //    StarSpawnPos[i] = Spawnanager.Instance.SpawnPos[i * 2];
        //}

        for (int i = 0; i < StarSpawnPos.Length; i++)
        {
            StarSpawnPos[i] = SpawnManager.Instance.SpawnPos[i];  
        }
    }

    void FixedUpdate()
    {


        if (setmap)
        {

            for (int j = 0; j < 5; j++)
            {
                StarSpawnPos[j] = SpawnManager.Instance.SpawnPos[j * 2];

            }

            setmap = false;
        }



        if (StarJellyCount > 20 )  

        {
            isSkillon = true;
        }
        if (isSkillon && !p.isBonusTime)  
        {


            SkillBar.fillAmount -= 0.008f;
            //anim.SetBool("Fly", true);
            //anim.SetFloat("PanCakeyVelocity", SkillBar.fillAmount * 2);  
            //p.isDashing = true;

            if (isStarSkill == false && !p.isBonusTime && !p.isBonusStart)      
            {
                if(p.stateMachine.currentState == p.highState 
                    || p.stateMachine.currentState == p.downState
                    || p.stateMachine.currentState == p.bonusDownState
                    || p.stateMachine.currentState == p.bonusUpState
                    || p.stateMachine.currentState == p.fallingState)  
                {
                    return;  
                }
               StarSkillActivate();

                isStarSkill = true;    
            }

            if (SkillBar.fillAmount <= 0)
            {

                StarJellyCount = 0;
                isSkillon = false;
                isStarSkill = false;
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


                dotori = Instantiate(StarJelly, StarSpawnPos[i].position + new Vector3(0, -1f, 0), Quaternion.identity);       
                Debug.Log($"{dotori.gameObject.name} 생성 ");

                if (i <= 0)
                {

                    m *= -1;
                }
                if (i >= 3)     
                {
                    Instantiate(SunflowerJelly, StarSpawnPos[i].position + new Vector3(0, -3f, 0), Quaternion.identity);      
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
    void StarSkillActivate()
    {
        RotateStars.SetActive(false);
        CreateMonLightStars();
        //StartCoroutine(CreateMonLightStars());

    }
    public void SetActiveRotateStars(bool flag)
    {
        RotateStars.SetActive(flag);
    }
    //IEnumerator CreateMonLightStars()
    //{
    //    WaitForSeconds seconds = new WaitForSeconds(1);    
    //    for(int i = 0; i < 2; i++)
    //    {
    //        GameObject go = Instantiate(moonLightStars, moonlightStarPos.position, Quaternion.identity);  
    //        GenerateStar component = go.GetComponent<GenerateStar>();
    //        component.SetParentPosX(transform.position.x);
    //        if (i == 1)
    //            component.pathType = PathType.Cos;

    //        //Debug.Log($"x : {transform.position.x}");    
    //        yield return seconds;
    //    }
    //}  
    void CreateMonLightStars()
    {
        for (int i = 0; i < 4; i++)
        {
            GameObject go = Instantiate(moonLightStars, moonlightStarPos.position, Quaternion.identity);
            GenerateStar component = go.GetComponent<GenerateStar>();
            component.SetParentPosX(transform.position.x);
            if (i == 0)
            {
                component.pathType = PathType.Cos;
                component.SetHeight(1);
                component.MaxFrequency(5);  
            }
            else if (i == 1)
            {
                component.pathType = PathType.Sin;
                component.SetHeight(1);
                component.MaxFrequency(5);
            }
            else if (i == 2)
            {
                component.pathType = PathType.Cos;
                component.SetHeight(2);
                component.MaxFrequency(10);
            }
            else if (i == 3)
            {
                component.pathType = PathType.Sin;
                component.SetHeight(2);
                component.MaxFrequency(10);          
            } 

            //Debug.Log($"x : {transform.position.x}");    
        }
    }
}

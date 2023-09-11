using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//using static UnityEditor.Progress;
using static Item;

public class Player : MonoBehaviour
{
    #region States
    public PlayerStateMachine stateMachine { get; private set; }
    public PlayerIdleState idleState { get; private set; }
    public PlayerJumpState jumpState { get; private set; }
    public PlayerSlideState slideState { get; private set; }
    public PlayerDashState dashState { get; private set; }
    public PlayerGiganticState giganticState { get; private set;}
    public PlayerHighState highState { get; private set; } // code by.동호
    public PlayerAirState airState { get; private set; }
    public PlayerDownState downState { get; private set; } // code by.동호
    public PlayerHitState hitState { get; private set; }

    public PlayerDoubleJumpState doubleJumpState { get; private set; } // code by 대석

    public PlayerDeathState deathState { get; private set; } // code by.동호

    public PlayerBonusDownState bonusDownState { get; private set; }// code by.동호
    public PlayerBonusUpState bonusUpState { get; private set; } // code by.동호
    
    public PlayerFallingState fallingState { get; private set; } // code by.동호



    #endregion

    public Camera mainCamera;
    Vector3 cameraPos;
   


    [Header("player")]
    [SerializeField] float hp;
    [SerializeField] float originSpeed;
    [SerializeField] float dashSpeed;
    [SerializeField] Transform originSize;
    //[SerializeField] float giganticSize;
    [SerializeField] public float jumpPower; // code by. 대석
    

    [Header("Bonus Map Info")]      // code by. 동호
    public float topTime;           // 최대로 올라갈 떄의 시간  
    public GameObject topPos;       // 쿠키가 보너스 타임으로 갈 때 최대로 올라 갈 수 있는 위치
    public float downTime;          // 중앙 위치로 갈 때의 시간 
    public GameObject middlePos;    // 쿠키가 최대로 올라간 후 중앙 위치로 가는 위치 
    public float bonusJumpPower = 1; // 쿠키가 점프버튼 클릭 시 올라갈 속도 파워 설정    
    [SerializeField] GameObject shinyEffect;
    public GameObject screenOutTopPos;  


    [Header("Collision Info")]
    [SerializeField] Transform groundCheck;
    [SerializeField] float groundCheckDistance;
    [SerializeField] LayerMask whatIsGround;
    [SerializeField] Transform wallCheck; // code by. 대석
    [SerializeField] float wallCheckDistance; // code by. 대석
    [SerializeField] LayerMask whatIsWall; // code by. 대석

    public float jellyScore; // code by. 대석 (임시)
    public float coinScore ; // code by. 대석 (임시)
    public float totalCoinScore; //code by. 하은

    #region Components 
    public Animator anim { get; private set; }
    public Rigidbody2D rb { get; private set; }

    public BoxCollider2D collider1 { get; private set; } // code by. 대석
    public UI_InGame gameUIManager { get; private set; } // code by. 대석

   
    

    #endregion

    public bool isBusy { get; private set; }
    public bool ishitted = false;
    public bool isBlinking = false;

    //[SerializeField] string bgmAudioClipPath = "BGM_Map2";
    [SerializeField] string effectAudioClipPath = "SoundEff_Large_Energy";


    /// /////////////////////////////////////////////////////////////////////////// code by. 


    [Header("대쉬 관련")]
    [SerializeField] public bool isDashing;
    [SerializeField] public float DashDuration; //대쉬 남아있는 시간
    [SerializeField] public float GroundScrollSpeed; //현재 진행중인 스피드
    [SerializeField] public float OriginalGroundScrollSpeed; //원래 초기값 스피드
    public float DashTime; //대쉬 지속 시간


    [Header("거대화 관련")]
    [SerializeField] public bool isGigantic;
    [SerializeField] public float GiganticSize; //얼마나 커질지
    [SerializeField] float giganticMaxSize; //jump,slide 시에 거대 크기 유지
    [SerializeField] public Vector3 OriginalSize; //원래의 크기
    [SerializeField] public float GiganticDuration; //거대화 남아있는 시간
    public float GiganticTime; //거대화 지속 시간


    [Header("자석 관련")]
    [SerializeField] public bool isMagnet;
    [SerializeField] public float MagnetDuration; //대쉬 남아있는 시간
    public float MagnetTime; //거대화 지속 시간
    public float MagnetSpeed; //거대화 지속 시간

    [Header("MAP")]
    public int mapcount;
    public bool isMapChange;

    [Header("보너스 타임 관련")]
    
    public float BonusTimeDuration;
    public bool isBonusTime;
    public bool isBonusStart ;
    public int BonusJellyCount;
    public Image BonusTimeGage; //보너스타임 게이지
    public Image BonusTimeGage_Prefab;
    public float gValue = 0; //게이지 값
        

    private void Start()
    {
        mainCamera = Camera.main;
        cameraPos = mainCamera.transform.localPosition;
        BonusTimeGage = GameObject.Find("InGameUI").transform.GetChild(2).transform.GetChild(9).GetComponent<Image>();
        gValue = 0;
        BonusJellyCount = 0;
        mapcount = 0;
        isMapChange = false;
        OriginalGroundScrollSpeed = GroundScrollSpeed; //원래 속도값 넣어주기
        DashDuration = DashTime; //삭제해도 무방
        GameManager.Instance.currentJellyPoint = 0; //현재 게임 jellyPoint점수 초기화 //code by. 하은
        GameManager.Instance.currentCoin = 0; //현재 게임 coin점수 초기화 //code by. 하은
        OriginalSize = transform.localScale; //원래 플레이어의 사이즈 저장
        GiganticDuration = GiganticTime; //삭제해도 무방

        anim = GetComponentInChildren<Animator>(); //자식의 <Animator>()가져옴
        rb = GetComponent<Rigidbody2D>();
        collider1 = GetComponent<BoxCollider2D>(); // code by. 대석

       

        SetActiveShinyEffect(false);  // code by.동호      

        gameUIManager = GameObject.Find("InGameUI").GetComponent<UI_InGame>(); // code by. 대석
        

        stateMachine.Initialize(idleState); //처음에는 idle상태로      
    }
    private void FixedUpdate()
    {
        DashDuration -= Time.deltaTime; //시간에 따라서 값 감소
        GiganticDuration -= Time.deltaTime;//시간에 따라서 값 감소
        MagnetDuration -= Time.deltaTime; ; //시간에 따라서 값 감소

        if(DashDuration<0)
            isDashing = false;
        if(GiganticDuration< 0)
            isGigantic = false;
        if(MagnetDuration< 0)
            isMagnet = false;

        hp = gameUIManager.GetHpValue(); // code by 대석

        //보너스 타임 UI스크롤

        gValue -= Time.deltaTime / BonusTimeDuration;
        if (gValue <= 0)
        {
            //gValue = 0;
            isBonusTime = false;
        }
        BonusTimeGage.fillAmount = gValue;  




    }



    /// ///////////////////////////////////////////////////////////////////////////

    private void Awake()
    {
        stateMachine = new PlayerStateMachine();
        idleState = new PlayerIdleState(this, stateMachine, "Idle"); //this : 자기참조(Player)
        jumpState = new PlayerJumpState(this, stateMachine, "Jump");
        doubleJumpState = new PlayerDoubleJumpState(this, stateMachine, "DoubleJump"); // code by. 대석
        slideState = new PlayerSlideState(this, stateMachine, "Slide");
        airState = new PlayerAirState(this, stateMachine, "DoubleJump");
        dashState = new PlayerDashState(this, stateMachine, "Dash");
        hitState = new PlayerHitState(this, stateMachine, "Hit");
        giganticState = new PlayerGiganticState(this, stateMachine, "Gigantic");
        highState = new PlayerHighState(this, stateMachine, "High"); // code by.동호
        downState = new PlayerDownState(this, stateMachine, "Down"); // code by.동호
        deathState = new PlayerDeathState(this, stateMachine, "Death");
        bonusDownState = new PlayerBonusDownState(this, stateMachine, "BonusDown"); // code by.동호
        bonusUpState = new PlayerBonusUpState(this, stateMachine, "BonusUp"); // code by.동호
        fallingState = new PlayerFallingState(this, stateMachine, "Falling"); // code by.동호 
    }


    //private void Start()
    //{
    //    anim = GetComponentInChildren<Animator>(); //자식의 <Animator>()가져옴
    //    rb = GetComponent<Rigidbody2D>();
    //    fx = GetComponent<PlayerFX>();
    //    collider1 = GetComponent<BoxCollider2D>(); // code by. 대석
    //    SetActiveShinyEffect(false);  // code by.동호      


    //    stateMachine.Initialize(idleState); //처음에는 idle상태로      
    //}

    public void Update()
    {
        stateMachine.currentState.Update();

       
    }

   

    public IEnumerator BusyFor(float _second)
    {
        isBusy = true;
        yield return new WaitForSeconds(_second);
        isBusy = false;
    }

    public IEnumerator isHitted(float _second)
    {
        ishitted = true;
        yield return new WaitForSeconds(_second);
        ishitted = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && !isDashing && !isGigantic && !ishitted)
        {
            StartCoroutine(isHitted(1f)); // 한 번 부딪쳤을때 잠시 무적
            Damage(5);
        }

        if (collision.gameObject.CompareTag("Air"))
        {
            Transform oriPos = GameObject.Find("OriginPos").GetComponent<Transform>();
            transform.position = oriPos.position;
            Damage(20);
            StartCoroutine(isHitted(3));
        }

        if (collision.gameObject.CompareTag("Item") && collision.gameObject.GetComponent<GetItem>().item.itemName == "HealBig")
        {
            AudioClip effectAudioClip = GameManager.Instance.LoadAudioClip(effectAudioClipPath);
            if (effectAudioClip != null)
                SoundManager.Instance.Play(effectAudioClip, Define.Sound.Effect);

            mapcount++;
            if (mapcount >= 1)
                mapcount = 1;
            isMapChange = true;
            
        }

        if ((collision.gameObject.CompareTag("Enemy") && (isGigantic || isDashing)) && !isBonusTime)
        {
            if (collision.gameObject.transform.parent != null)
                StartCoroutine(FlyObstacle(collision.gameObject.transform.parent));
            //else
            //{
            //    StopCoroutine(FlyObstacle(collision.gameObject.transform.parent));
            //}

            
            
            //Transform enemy = collision.gameObject.transform;
            //string name = enemy.transform.root.name ;
        }
    }
     public void DestrtoyObject()
    {
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] Items = GameObject.FindGameObjectsWithTag("Item");
        GameObject[] jellys = GameObject.FindGameObjectsWithTag("Jelly");
        GameObject[] coins = GameObject.FindGameObjectsWithTag("Coin");
        GameObject[] SpawnGrounds = GameObject.FindGameObjectsWithTag("SpawnGround");  
        // GameObject[] StarJellys = GameObject.FindGameObjectsWithTag("StarJelly");

        foreach (GameObject item in Items)
        {
            Destroy(item);
        }

        foreach (GameObject jelly in jellys)
        {
            Destroy(jelly);
        }
        foreach (GameObject coin in coins)
        {
            Destroy(coin);
        }
        foreach (GameObject enemy in enemys)
        {
            Destroy(enemy);
        }
        foreach (GameObject SpawnGround in SpawnGrounds)
        {
            Destroy(SpawnGround);
        }
        //foreach (GameObject starJelly in StarJellys)
        //{
        //    Destroy(starJelly);  
        //}  
    }

    IEnumerator FlyObstacle(Transform _enemy)
    {


        string name = _enemy.name;

        //GameObject[] Enemy = GameObject.FindGameObjectsWithTag("Enemy");
        //if(Enemy.Length == 0)
        //{
        //    yield break;
        //}
         
       
        while (true)
        {
            //Debug.Log("FlyObstacle");
            if (_enemy == null)
                yield break ;    

            switch (name)
            {
                case "EnemyShort(Clone)":
                    if(name != null && !isBonusTime)
                    {
                       _enemy.position += new Vector3(40 * Time.deltaTime, -40 * Time.deltaTime, 0);
                       _enemy.Rotate(Vector3.forward*270f*Time.deltaTime);
                    }
                    break;
                case "EnemyLong(Clone)":
                    if (name != null && !isBonusTime)
                    {
                        _enemy.position += new Vector3(40 * Time.deltaTime, -40 * Time.deltaTime, 0);
                        _enemy.Rotate(Vector3.forward * 270f * Time.deltaTime);
                    }
                    break;
                case "EnemyLongUp(Clone)":
                    if (name != null && !isBonusTime)
                    {
                        _enemy.position += new Vector3(40 * Time.deltaTime, 40 * Time.deltaTime, 0);
                        _enemy.Rotate(Vector3.forward * 270f * Time.deltaTime);
                    }
                    break;
                case "SlideEnemy(Clone)":
                    if (name != null && !isBonusTime)
                    {
                        _enemy.position += new Vector3(40 * Time.deltaTime, 40 * Time.deltaTime, 0);
                        _enemy.Rotate(Vector3.forward * 270f * Time.deltaTime);
                    }
                    break;
            }
            yield return null;
        }
    }

    public void Damage(int damage)
    {
        gameUIManager.HpValue -= damage;
        //Debug.Log("적과 충돌했습니다");
    }
    public void vibrate()  //Code by.준 //지진효과
    {
        if(IsGroundDetected() && isGigantic)
        {
            StartCoroutine(Shake(0.1f, 0.2f));
        }
    }

    public IEnumerator Shake(float _amount, float _duration)
    {
        float timer = 0;
        while (timer <= _duration)
        {
            mainCamera.transform.localPosition = (Vector3)Random.insideUnitCircle * _amount + cameraPos;

            timer += Time.deltaTime;
            yield return null;
        }
        mainCamera.transform.localPosition = cameraPos;

    }
    // code by. 대석
    public bool IsGroundDetected()
        => Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, whatIsGround);

    // code by. 대석
    public bool IsWallDetected()
        => Physics2D.Raycast(wallCheck.position, Vector2.right, wallCheckDistance, whatIsWall);

    // code by. 대석
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(groundCheck.position, new Vector3(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
        Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + wallCheckDistance, wallCheck.position.y));
    }
    // code by. 동호
    public void SetVelocity(float _xVelocity, float _yVelocity)
    {
        rb.velocity = new Vector2(_xVelocity, _yVelocity);  
    }  
    public float GetJumpPower()
    {
        return jumpPower;
    }

    public float GetGiganticMaxSize()
    {
        return giganticMaxSize;
    }
    public void SetActiveShinyEffect(bool flag)
    {
        shinyEffect.SetActive(flag);      
    }
    public GameObject GetShinyEffect()
    {
        return shinyEffect;
    }
    public float GetHP()
    {
        return hp;
    }

   
    public float AddHP(float howmuchheal)
    {
        gameUIManager.HpValue += howmuchheal;
        //hp += howmuchheal;
        return hp;
        
    }

    public float GetTotalCoin() //code by.하은
    {
        return totalCoinScore;
    }

    public void CallResultWindow() // code by. 대석
    {
        StartCoroutine("WaitGameover");
    }

    IEnumerator WaitGameover() // code by. 대석
    {
        GroundScrollSpeed = 0;
        yield return new WaitForSeconds(3);
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("ResultScene");
        SoundManager.Instance.Clear();
    }
    IEnumerator CoSetPlayerScreenOutTopPos()
    {
        yield return new WaitForSeconds(1f);
        EnvironmentManager.Instance.SetActiveInGameEnvironment(true);
        EnvironmentManager.Instance.SetActiveBonusTimeEnvironment(false);


        transform.localPosition = new Vector2(transform.position.x, screenOutTopPos.transform.position.y);        
        //rb.velocity = Vector2.zero;    
        rb.gravityScale = 30;            
    }
}


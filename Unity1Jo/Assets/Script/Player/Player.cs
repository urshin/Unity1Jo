using System.Collections;
using System.Collections.Generic;

using UnityEngine;
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

    [Header("player")]
    [SerializeField] float hp;
    [SerializeField] float originSpeed;
    [SerializeField] float dashSpeed;
    [SerializeField] Transform originSize;
    [SerializeField] float giganticSize;
    [SerializeField] public float jumpPower; // code by. 대석

    [Header("Bonus Map Info")]      // code by. 동호
    public float topTime;           // 최대로 올라갈 떄의 시간  
    public GameObject topPos;       // 쿠키가 보너스 타임으로 갈 때 최대로 올라 갈 수 있는 위치
    public float downTime;          // 중앙 위치로 갈 때의 시간 
    public GameObject middlePos;    // 쿠키가 최대로 올라간 후 중앙 위치로 가는 위치 
    public float bonusJumpPower = 1; // 쿠키가 점프버튼 클릭 시 올라갈 속도 파워 설정    
    [SerializeField] GameObject shinyEffect;  


    [Header("Collision Info")]
    [SerializeField] Transform groundCheck;
    [SerializeField] float groundCheckDistance;
    [SerializeField] LayerMask whatIsGround;

    public float jellyScore; // code by. 대석 (임시)
    public float coinScore; // code by. 대석 (임시)

    #region Components 
    public Animator anim { get; private set; }
    public Rigidbody2D rb { get; private set; }
    public PlayerFX fx { get; private set; } //code by. 하은_Damage()에 사용

    public BoxCollider2D collider1 { get; private set; } // code by. 대석
    

    #endregion

    public bool isBusy { get; private set; }

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
    private void Start()
    {
        mapcount = 0;
        isMapChange = false;
        OriginalGroundScrollSpeed = GroundScrollSpeed; //원래 속도값 넣어주기
        DashDuration = DashTime; //삭제해도 무방

        OriginalSize = transform.localScale; //원래 플레이어의 사이즈 저장
        GiganticDuration = GiganticTime; //삭제해도 무방

        anim = GetComponentInChildren<Animator>(); //자식의 <Animator>()가져옴
        rb = GetComponent<Rigidbody2D>();
        fx = GetComponent<PlayerFX>();
        collider1 = GetComponent<BoxCollider2D>(); // code by. 대석
        SetActiveShinyEffect(false);  // code by.동호      


        stateMachine.Initialize(idleState); //처음에는 idle상태로      
    }
    private void FixedUpdate()
    {
        DashDuration -= Time.deltaTime; //시간에 따라서 값 감소
        GiganticDuration -= Time.deltaTime;//시간에 따라서 값 감소
        MagnetDuration -= Time.deltaTime; ; //시간에 따라서 값 감소

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

    //code by. 하은
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("적!!!!!!!!!!!!!!!!!!!"); //code by. 준 적 충돌 확인용
            Damage();
        }

        if (collision.gameObject.CompareTag("Item")) // code by. 대석 (임시)
        {
           
            if (GameManager.Instance == null) return;
            jellyScore += GameManager.Instance.JellyPoint; //itemds.value;
            coinScore += GameManager.Instance.Coin;
            //Destroy(collision.gameObject);
            
        }
        if(collision.gameObject.CompareTag("Item") && collision.gameObject.GetComponent<GetItem>().item.itemName == "HealBig")
        {
            mapcount++;
            isMapChange = true;
        }
    }

    // code by. 하은
    public void Damage()
    {
       // fx.StartCoroutine("FlashFX"); //오류나서 일단 주석처리했습니다 .준
    }

    // code by. 대석
    public bool IsGroundDetected()
        => Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, whatIsGround);

    // code by. 대석
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(groundCheck.position, new Vector3(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
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
    public float HealHP(float howmuchheal)
    {
        hp += howmuchheal;
        return hp;
        
    }
}


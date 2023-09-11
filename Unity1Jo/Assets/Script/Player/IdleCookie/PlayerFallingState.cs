using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallingState : PlayerState
{
    Player p;
    //사운드
    string bgmAudioClipPath1 = "BGM_Map1";
    string bgmAudioClipPath2 = "BGM_Map2";
    public PlayerFallingState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
        p= _player;
    }
    //public void Awake()
    //{
    //    p = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    //}

    public override void Enter()
    {
        base.Enter(); // 부모의 Enter 함수 실행 
        rb.gravityScale = 5; // 중력을 1으로 반듬  //중력값 바뀐 중력값인 5로 만들었습니다.

        player.isBonusStart = false;

        EnvironmentManager.Instance.GetBonusMap().GetComponent<BonusMap>().SetBonusWallColliderEnabled(false);  // 보너스 맵의 밑의 collider enabled false
        BonusTime_FadeInOut.Play(Define.Transition.Fade);    //fade in out 

        
        //EnvironmentManager.Instance.GetInGameMap().transform.position = new Vector2(-25, 0);          
        //EnvironmentManager.Instance.GetBonusMap().transform.position = new Vector2(-20, 0);          
        player.StartCoroutine("CoSetPlayerScreenOutTopPos");
        //player.transform.GetComponent<Rigidbody2D>().gravityScale = 5;
        GameObject.Find("InGameUI").GetComponent<UI_IngameBtn>().SetButtonPush(false);

        // bonus 알파벳 초기화 
        player.GetComponent<PlayerBonusTimeCount>().ClearBonusAlphaBetCount();  

        //BGM재생
        if (p.mapcount == 0)
        {
            Debug.Log("1의 노래");
            AudioClip bgmAudioClip1 = GameManager.Instance.LoadAudioClip(bgmAudioClipPath1);
            if (bgmAudioClip1 != null)
                SoundManager.Instance.Play(bgmAudioClip1, Define.Sound.Bgm);
        }
        else if(p.mapcount == 1)
        {
            Debug.Log("2의 노래");
            AudioClip bgmAudioClip2 = GameManager.Instance.LoadAudioClip(bgmAudioClipPath2);
            if (bgmAudioClip2 != null)
                SoundManager.Instance.Play(bgmAudioClip2, Define.Sound.Bgm);
        }


    }


    public override void Exit()
    {
        base.Exit(); // 부모의 Exit 함수 실행 
        
        EnvironmentManager.Instance.GetBonusMap().GetComponent<BonusMap>().SetBonusWallColliderEnabled(true);
        rb.gravityScale = 5; // 중력을 1으로 반듬  //중력값 바뀐 중력값인 5로 만들었습니다.
        PlayerManager.Instance.SetOriginPlayerPositi2on();
        //player.isBonusStart = false;

    }

    public override void Update()
    {
        base.Update();// 부모의 Update 함수 실행 

        //player.DestrtoyObject(); 

        if (player.IsGroundDetected())
        {
            player.stateMachine.ChangeState(player.idleState);
        }
        

        player.rb.velocity = Vector2.down * Time.deltaTime * 3f;            

        if (!player.isBonusTime)
            return;

    }
}

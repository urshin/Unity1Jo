using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallingState : PlayerState
{
    public PlayerFallingState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {

    }

    public override void Enter()
    {
        base.Enter(); // 부모의 Enter 함수 실행 
        rb.gravityScale = 5; // 중력을 1으로 반듬  //중력값 바뀐 중력값인 5로 만들었습니다.

        player.isBonusStart = false;

        EnvironmentManager.Instance.GetBonusMap().GetComponent<BonusMap>().SetBonusWallColliderEnabled(false);  // 보너스 맵의 밑의 collider enabled false
        TransitionController.Play(Define.Transition.Fade);    //fade in out 

        
        //EnvironmentManager.Instance.GetInGameMap().transform.position = new Vector2(-25, 0);          
        //EnvironmentManager.Instance.GetBonusMap().transform.position = new Vector2(-20, 0);          
        player.StartCoroutine("CoSetPlayerScreenOutTopPos");
        //player.transform.GetComponent<Rigidbody2D>().gravityScale = 5;
        GameObject.Find("InGameUI").GetComponent<UITest>().SetButtonPush(false);

        player.GetComponent<PlayerBonusTimeCount>().ClearBonusAlphaBetCount(); // 보너스 알파벳 초기화   
        
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

        player.DestrtoyObject(); 

        if (player.IsGroundDetected())
        {
            player.stateMachine.ChangeState(player.idleState);
        }
        

        player.rb.velocity = Vector2.down * Time.deltaTime * 3f;            

        if (!player.isBonusTime)
            return;

    }
}

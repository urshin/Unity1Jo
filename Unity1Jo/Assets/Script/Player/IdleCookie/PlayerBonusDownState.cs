using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBonusDownState : PlayerState
{
    public PlayerBonusDownState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {

    }
    // code by 동호
    public override void Enter()
    {
        base.Enter(); // 부모의 Enter 함수 실행 
        player.SetActiveShinyEffect(false);  // 빛나는 이펙트 꺼주기   

        player.SetVelocity(0, -player.bonusJumpPower);

    }
    // code by 동호
    public override void Exit()
    {
        base.Exit(); // 부모의 Exit 함수 실행 
    }
    // code by 동호
    public override void Update()
    {
        base.Update();  // 부모의 Update 함수 실행 
        if (player.isGigantic || (player.isGigantic && player.isDashing))
        {
            player.transform.localScale = player.OriginalSize * player.GetGiganticMaxSize();
        }


        if (player.gValue <= 0 && player.isBonusTime == false && player.isBonusStart)
        {
            stateMachine.ChangeState(player.fallingState);      
        }
    }
}

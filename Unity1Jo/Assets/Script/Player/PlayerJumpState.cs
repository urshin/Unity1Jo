using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerState
{
    public PlayerJumpState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        Vector2 jumpVec = new Vector2(rb.velocity.x, player.GetJumpPower());
        rb.AddForce(jumpVec, ForceMode2D.Impulse);
    }

    public override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.Space) && !player.IsGroundDetected())
        {
            stateMachine.ChangeState(player.doubleJumpState);
        }

        if (player.IsGroundDetected() && rb.velocity.y == 0)
        {
            stateMachine.ChangeState(player.idleState);
        }

        if (Input.GetKey(KeyCode.S))
        {
            stateMachine.ChangeState(player.slideState);
        }
        

        if (player.IsWallDetected() && !player.isDashing && !player.isGigantic)
        {
            player.stateMachine.ChangeState(player.hitState);  
        }

        if (player.isBonusTime)
        {

            player.stateMachine.ChangeState(player.highState);
            player.SetActiveShinyEffect(true);
            player.GetShinyEffect()?.GetComponent<ShinyEffect>().StartRotateLightsEffect();
        }
        //if (Input.GetKey(KeyCode.S) && player.IsGroundDetected())
        //{
        //    stateMachine.ChangeState(player.slideState);
        //}
    }

    public override void Exit()
    {
        base.Exit();
        player.vibrate();
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDoubleJumpState : PlayerState
{
    public PlayerDoubleJumpState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

            rb.velocity = Vector2.zero;

            rb.AddForce(new Vector2(rb.velocity.x, player.GetJumpPower()), ForceMode2D.Impulse);
    } 

    public override void Update()
    {
        base.Update();

        if(rb.velocity.y < 0)
        {
            stateMachine.ChangeState(player.airState);
        }
        if (Input.GetKey(KeyCode.S))
        {
            stateMachine.ChangeState(player.slideState);
        }
       
        if (player.IsWallDetected())
        {
            player.stateMachine.ChangeState(player.hitState);
        }
        else return;
    }

    public override void Exit()
    {
        base.Exit();

    }

}

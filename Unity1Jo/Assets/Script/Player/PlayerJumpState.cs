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

            Vector2 jumpVec = new Vector2(rb.velocity.x, 5);

            rb.AddForce(jumpVec, ForceMode2D.Impulse);
    }

    public override void Update()
    {
        base.Update();

        //if(rb.velocity.y < 0)
        //{
        //    stateMachine.ChangeState(player.airState);
        //}
    }

    public override void Exit()
    {
        base.Exit();
    }

}

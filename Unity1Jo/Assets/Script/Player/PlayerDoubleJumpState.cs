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


        Vector2 jumpVec = new Vector2(rb.velocity.x, player.jumpPower);

        rb.velocity = jumpVec; // AddForce말고 벡터로 값을 주니 연속으로 눌러도 더 높이 올라가지 않았음.
    }

    public override void Update()
    {
        base.Update();

        if(rb.velocity.y < 0)
        {
            stateMachine.ChangeState(player.airState);
        }
    }

    public override void Exit()
    {
        base.Exit();

    }

}

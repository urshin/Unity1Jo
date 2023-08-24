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
        base.Enter();
        rb.gravityScale = 1;

    }
    // code by 동호
    public override void Exit()
    {
        base.Exit();
        rb.gravityScale = 0;

    }
    // code by 동호
    public override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.Q))
            player.stateMachine.ChangeState(player.bonusUpState);    
    }
}

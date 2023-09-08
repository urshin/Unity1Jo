using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitState : PlayerState
{
    public PlayerHitState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }
    public override void Update()
    {
        base.Update();


        if (player.IsGroundDetected() && !player.ishitted)
        {
            stateMachine.ChangeState(player.idleState);
        }

        if (player.isBonusTime)
        {

            player.stateMachine.ChangeState(player.highState);
            player.SetActiveShinyEffect(true);
            player.GetShinyEffect()?.GetComponent<ShinyEffect>().StartRotateLightsEffect();
        }
    }

    public override void Exit()
    {
        base.Exit();
    }

   
}

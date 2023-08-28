using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerState
{
    public PlayerDashState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
    }

    public override void Enter()
    {
        base.Enter();
        //GameObject.FindGameObjectWithTag("Player").transform.position += new Vector3(3 * Time.deltaTime, 0, 0);
    }

    public override void Exit()
    {
        base.Exit();
        
        //GameObject.FindGameObjectWithTag("Player").transform.position += new Vector3(-3 * Time.deltaTime, 0, 0);
    }

    public override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.Space) && player.IsGroundDetected()) // 수정
            player.stateMachine.ChangeState(player.jumpState);

        if (Input.GetKeyDown(KeyCode.Space) && !player.IsGroundDetected()) // 추가
            player.stateMachine.ChangeState(player.doubleJumpState);

        if (Input.GetKeyDown(KeyCode.S) && player.IsGroundDetected()) // 수정
            player.stateMachine.ChangeState(player.slideState);

        //if (Input.GetKeyDown(KeyCode.D))
        //    player.stateMachine.ChangeState(player.dashState);

        //if (Input.GetKeyDown(KeyCode.G))
        //    player.stateMachine.ChangeState(player.giganticState);

        if (Input.GetKeyDown(KeyCode.D))
            player.stateMachine.ChangeState(player.deathState);

        if (Input.GetKeyDown(KeyCode.H))
        {
            player.stateMachine.ChangeState(player.highState);
            player.SetActiveShinyEffect(true);
            player.GetShinyEffect()?.GetComponent<ShinyEffect>().StartRotateLightsEffect();
        }

        if (Input.GetKeyDown(KeyCode.F))
            player.stateMachine.ChangeState(player.fallingState);

        if (player.OriginalGroundScrollSpeed == player.GroundScrollSpeed)
        {
            player.stateMachine.ChangeState(player.idleState);
        }

    }
}
